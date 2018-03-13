using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ExcelManager
{
    public class SystemMenuExcelManager
    {
        public DataGridView GetSystemMenu(string fileName,DataGridView dgv,ref string error)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;    //创建excel实例
            Range rContent = null;       //选择内容对象
            Dictionary<string, int> stru =new Dictionary<string,int>();    //取出结构字典
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;           //关闭是否提示
                excel.Workbooks.Open(fileName);                      //打开文件
                //选取第一个工作表
                excel.SheetsInNewWorkbook = 1;
                //头部信息
                rContent = excel.Cells[1, 9] as Range;    //1.1标题的位置
                if (rContent.Text.ToString().Trim() == "箱 信 息 查 询 清 单")    //是系统清单吗
                {
                    stru.Clear();
                    stru.Add("箱号", 0);
                    stru.Add("尺寸", 0);
                    stru.Add("箱型", 0);
                    stru.Add("持箱人", 0);
                    stru.Add("状态", 0);
                    stru.Add("船名", 0);
                    stru.Add("航次", 0);
                    stru.Add("I/E", 0);
                    stru.Add("流向", 0);
                    stru.Add("来源", 0);
                    stru.Add("重量", 0);
                    stru.Add("目的港", 0);
                    stru.Add("卸货港", 0);
                    stru.Add("装货港", 0);
                    stru.Add("提单号", 0);
                    stru.Add("货名", 0);

                    rContent = excel.Cells[4, 1] as Range;    //4,n 第四行是结构字段名
                    int col = 0;
                    while (rContent.Text.ToString().Trim() != "")
                    {
                        for (int i = 0; i < stru.Keys.Count; i++)
                        {
                            var item = stru.ElementAt(i);       //取出i个字典位置
                            string itemKey = item.Key;          //取出i位置字典Key的名称
                            if (itemKey == Convert.ToString(rContent.Text.ToString().Trim()))
                            {
                                stru[itemKey] = col + 1;                  //把位置存上
                            }
                        }
                        col++;
                        rContent = excel.Cells[4,col+1] as Range;
                    }
                    //开始写入GataGridView中
                    int seq = 1;      //序号
                    int row = 5;      //从第5行开始读取内容
                    col = 1;          //从第0列开始读列内容
                    rContent = excel.Cells[row, 9] as Range;    //5,1 如果没有内容直接越过
                    dgv.Rows.Clear();
                    //1.循环获取表格列的名称
                    while (rContent.Text.ToString().Trim() != "")
                    {
                        //2.如果对应上则读取字典中对应的位置
                        //表格列循环
                        int index = dgv.Rows.Add();      //先增加一行
                        for (int i = 0; i < dgv.Columns.Count; i++)   
                        {
                            string name = dgv.Columns[i].HeaderText;
                            if (name == "序号")
                            {
                                dgv.Rows[index].Cells[i].Value = (row - 4).ToString();     //序号的内容
                                continue;
                            }
                            //循环字典对应位置
                            for (int j= 0; j < stru.Keys.Count; j++)
                            {
                                var item = stru.ElementAt(j);       //取出i个字典位置
                                string itemKey = item.Key;          //取出i位置字典Key的名称
                                if (itemKey == name)
                                {
                                    if (itemKey == "重量")
                                    {
                                        rContent = excel.Cells[row, stru[itemKey]] as Range;
                                        dgv.Rows[index].Cells[i].Value = rContent.Value==null?"0":rContent.Value.ToString();
                                    }
                                    else
                                    {
                                        rContent = excel.Cells[row, stru[itemKey]] as Range;
                                        dgv.Rows[index].Cells[i].Value = Convert.ToString(rContent.Text.ToString().Trim());     //相应内容写上
                                    }
                                }
                                //3.一个特殊的来源与流向字段
                                if (itemKey == "流向" && name == "流向/来源")
                                {
                                    if (stru[itemKey] > 0)    //只有对应位置能找到的
                                    {
                                        rContent = excel.Cells[row, stru[itemKey]] as Range;
                                        dgv.Rows[index].Cells[i].Value = Convert.ToString(rContent.Text.ToString().Trim());     //相应内容写上
                                        
                                    }
                                }
                                if (itemKey == "来源" && name == "流向/来源")
                                {
                                    if (stru[itemKey] > 0)    //只有对应位置能找到的
                                    {
                                        rContent = excel.Cells[row, stru[itemKey]] as Range;
                                        dgv.Rows[index].Cells[i].Value = Convert.ToString(rContent.Text.ToString().Trim());     //相应内容写上
                                        
                                    }
                                }
                            }
                        }
                       

                        //4.循环完毕
                        row++;
                        col = 1;
                        rContent = excel.Cells[row, 9] as Range;    //n,1 如果没有内容直接跳出循环
                    }
                }
                
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                //垃圾回收
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(rContent);

                excel = null;
                rContent = null;

                GC.Collect();

            }
            return dgv;
        }


        /// <summary>
        /// 把改变后的结果的datagridview装入到Excel表格内  columnNumber展示列的数量
        /// </summary>
        /// <param name="dgv"></param>
        public string DataToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                return "没有要输出的内容";
            }
            string title = dgv.Rows[0].Cells["dgvExcelShipName"].Value.ToString() + "/" + dgv.Rows[0].Cells["dgvExcelHangChi"].Value.ToString() + (dgv.Rows[0].Cells["dgvExcelInOut"].Value.ToString()=="进口"?"卸船":"装船") + "清单";
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;
                int rows = dgv.Rows.Count;
                int cols = 17;     //这里指定列的数量
                int startRow = 1;
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excel.Cells[startRow, 1] = title;
                startRow++;
                excel.Cells[startRow, 1] = "";
                startRow++;
                //行标题
                //序号	箱号 	封号 	重量	 箱型	状态	 船公司	目的港	货种	 作业地点	代理	 船名/航次	运单号	来源地	流向	 发往地	备注
                excel.Cells[startRow, 1] = "序号";
                excel.Cells[startRow, 2] = "箱号";
                excel.Cells[startRow, 3] = "封号";
                excel.Cells[startRow, 4] = "重量";
                excel.Cells[startRow, 5] = "箱型";
                excel.Cells[startRow, 6] = "状态	";
                excel.Cells[startRow, 7] = "船公司";
                excel.Cells[startRow, 8] = "目的港";
                excel.Cells[startRow, 9] = "货种	";
                excel.Cells[startRow, 10] = "作业地点";
                excel.Cells[startRow, 11] = "代理";
                excel.Cells[startRow, 12] = "船名/航次";
                excel.Cells[startRow, 13] = "运单号";
                excel.Cells[startRow, 14] = "来源地";
                excel.Cells[startRow, 15] = "流向";
                excel.Cells[startRow, 16] = "发往地";
                excel.Cells[startRow, 17] = "备注";
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                startRow++;
                //循环具体内容
                foreach (DataGridViewRow item in dgv.Rows)
                {

                    excel.Cells[startRow, 1] = item.Cells["dgvExcelSequence"].Value.ToString();
                    excel.Cells[startRow, 2] = item.Cells["dgvExcelBoxNo"].Value.ToString();
                    excel.Cells[startRow, 3] = "";
                    excel.Cells[startRow, 4] = item.Cells["dgvExcelWeight"].Value.ToString();
                    excel.Cells[startRow, 5] = item.Cells["dgvExcelBoxSize"].Value.ToString();
                    excel.Cells[startRow, 6] = item.Cells["dgvExcelBoxState"].Value.ToString();
                    excel.Cells[startRow, 7] = item.Cells["dgvExcelCompany"].Value.ToString();
                    excel.Cells[startRow, 8] = item.Cells["dgvExcelAim"].Value.ToString();
                    excel.Cells[startRow, 9] = item.Cells["dgvExcelGoodsType"].Value.ToString();
                    excel.Cells[startRow, 10] = "";
                    excel.Cells[startRow, 11] = "";
                    excel.Cells[startRow, 12] = item.Cells["dgvExcelShipName"].Value.ToString() +"/"+ item.Cells["dgvExcelHangChi"].Value.ToString();
                    excel.Cells[startRow, 13] = item.Cells["dgvExcelWayBillNo"].Value.ToString();
                    excel.Cells[startRow, 14] = "";
                    excel.Cells[startRow, 15] = "";
                    excel.Cells[startRow, 16] = "";
                    excel.Cells[startRow, 17] = "";
                    startRow++;
                }
                error = "";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                //垃圾回收
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(range);

                excel = null;
                range = null;

                GC.Collect();

            }
            return error;
        }
    }
}
