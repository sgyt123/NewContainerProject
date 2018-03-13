using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using Model;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace ExcelManager
{
    public class ExcelHelper
    {
        /*
         *  stru.Add("序号", 0);
            stru.Add("箱号", 0);
            stru.Add("封号", 0);
            stru.Add("重量", 0);
            stru.Add("箱型", 0);
            stru.Add("状态", 0);
            stru.Add("船公司", 0);
            stru.Add("目的港", 0);
            stru.Add("货种", 0);
            stru.Add("作业地点", 0);
            stru.Add("代理", 0);
            stru.Add("船名/航次", 0);
            stru.Add("运单号", 0);
            stru.Add("来源地", 0);
            stru.Add("流向", 0);
            stru.Add("发往地", 0);
            stru.Add("备注", 0);
         * 
         * 
         */
        /// <summary>
        /// 获取excel文件的头部信息
        /// </summary>
        /// <param name="filename">excel 文件   errorstr错误信息字符串</param>
        /// <returns></returns>
        public BillIndex GetExcelBillTopInfomation(string filename, ref string errorstr)
        {
            BillIndex bi = new BillIndex();            //excel头部
            Dictionary<string, int> stru = bi.Stru;    //取出结构字典
            Microsoft.Office.Interop.Excel.Application excel = null;    //创建excel实例
            Range rContent = null;       //选择内容对象
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;           //关闭是否提示
                excel.Workbooks.Open(filename);                      //打开文件
                //选取第一个工作表
                excel.SheetsInNewWorkbook = 1;

                //头部信息
                rContent = excel.Cells[1, 1] as Range;    //1.1位置是标题
                bi.Title = Convert.ToString(rContent.Text.ToString().Trim());
                if (bi.Title == "盘锦港集团有限公司集装箱分公司")    //说明是EDI数据
                {
                    stru.Clear();
                    stru.Add("序号", 0);
                    stru.Add("箱号", 0);
                    stru.Add("封号", 0);
                    stru.Add("重量", 0);
                    stru.Add("箱型", 0);
                    stru.Add("状态", 0);
                    stru.Add("船公司", 0);
                    stru.Add("目的港", 0);
                    stru.Add("货种", 0);
                    stru.Add("作业地点", 0);
                    stru.Add("持箱人", 0);
                    stru.Add("船名/航次", 0);
                    stru.Add("提单号", 0);
                    stru.Add("来源", 0);
                    stru.Add("流向", 0);
                    stru.Add("发往地", 0);
                    stru.Add("备注", 0);


                    errorstr = "EDI数据";
                }
                else
                {
                    rContent = excel.Cells[2, 1] as Range;    //2,1位置是时间
                    rContent.NumberFormatLocal = "yyyy-m-d;@";
                    bi.Reg_Date = Convert.ToDateTime(rContent.Text.ToString().Trim());
                    rContent = excel.Cells[2, 2] as Range;    //2,2位置是航线
                    bi.Voyage = rContent.Text.ToString().Trim();
                    //以前容易错误的
                    for (int i = 0; i < stru.Keys.Count; i++)
                    {
                        rContent = excel.Cells[3, i + 1] as Range;    //3,n 第三行是结构字段名
                        for (int j = 0; j < stru.Keys.Count; j++)
                        {
                            var item = stru.ElementAt(j);
                            string itemKey = item.Key;
                            if (itemKey == Convert.ToString(rContent.Text.ToString().Trim()))       //如果当前内容与结构体的keys对应上 
                            {
                                stru[itemKey] = i + 1;                  //把位置存上
                            }
                        }
                    }

                    if (stru["流向"] > 0)
                    {
                        bi.InOut = "进口";
                    }
                    if (stru["目的港"] > 0)
                    {
                        bi.InOut = "出口";
                    }
                    errorstr = "手动数据";
                }
                excel.Visible = false;
                //关闭WorkBook
                excel.Workbooks.Close();
                //关闭Excel
                excel.Quit();

            }
            catch (Exception ex)
            {
                errorstr = ex.Message;

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
            return bi;
        }

        /// <summary>
        /// 读出明细
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="errorstr"></param>
        /// <param name="stru"></param>
        /// <returns></returns>
        public List<Bill> GetBills(string filename, ref string errorstr, Dictionary<string, int> stru)
        {
            //检查stru有没有效
            int total = 0;
            foreach (int item in stru.Values)
            {
                total += item;
            }
            if (total == 0)
            {
                errorstr = "调入Excel文件无法找到读取字段";
                return new List<Bill>();
            }
            //开始读入
            List<Bill> bi = new List<Bill>();           //excel头部
            Microsoft.Office.Interop.Excel.Application excel = null;    //创建excel实例
            Range rContent = null;       //选择内容对象
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;           //关闭是否提示
                excel.Workbooks.Open(filename);                      //打开文件
                //选取第一个工作表
                excel.SheetsInNewWorkbook = 1;

                int row = 4;                               //从第三行开始读出数据
                rContent = excel.Cells[row, 1] as Range;    //判断是否有内容
                while (rContent.Text.ToString().Trim() != "")     //不为空则往下读
                {
                    Bill b = new Bill();
                    foreach (string item in stru.Keys)
                    {
                        if (stru[item] > 0)     //判断是否存在此列数据
                        {
                            rContent = excel.Cells[row, stru[item]] as Range;    //读出内容
                            switch (item)
                            {
                                case "序号":
                                    b.Sequence = rContent.Text.ToString().Trim();
                                    break;
                                case "箱号":
                                    b.BoxNo = rContent.Text.ToString().Trim();
                                    break;
                                case "封号":
                                    b.SealNo = rContent.Text.ToString().Trim();
                                    break;
                                case "重量":
                                    b.Weight = rContent.Text.ToString().Trim();
                                    break;
                                case "箱型":
                                    b.BoxSize = rContent.Text.ToString().Trim();
                                    break;
                                case "状态":
                                    b.BoxState = rContent.Text.ToString().Trim();
                                    break;
                                case "船公司":
                                    b.Company = rContent.Text.ToString().Trim();
                                    break;
                                case "目的港":
                                    b.Aim = rContent.Text.ToString().Trim();
                                    break;
                                case "货种":
                                    b.GoodsType = rContent.Text.ToString().Trim();
                                    break;
                                case "作业地点":
                                    b.WorkPlace = rContent.Text.ToString().Trim();
                                    break;
                                case "代理":
                                    b.Proxy = rContent.Text.ToString().Trim();
                                    break;
                                case "船名/航次":
                                    b.ShipName = rContent.Text.ToString().Trim();
                                    break;
                                case "运单号":
                                    b.WayBillNo = rContent.Text.ToString().Trim();
                                    break;
                                case "来源地":
                                    b.Source = rContent.Text.ToString().Trim();
                                    break;
                                case "流向":
                                    b.Direction = rContent.Text.ToString().Trim();
                                    break;
                                case "发往地":
                                    b.SendPlace = rContent.Text.ToString().Trim();
                                    break;
                                case "备注":
                                    b.Demo = rContent.Text.ToString().Trim(); ;
                                    break;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(b.Demo))
                        b.Demo = "";
                    bi.Add(b);
                    row++;
                    rContent = excel.Cells[row, 1] as Range;    //判断是否有内容
                }

                excel.Visible = false;
                //关闭WorkBook
                excel.Workbooks.Close();
                //关闭Excel
                excel.Quit();

            }
            catch (Exception ex)
            {
                errorstr = ex.Message;

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
            return bi;

        }
        /// <summary>
        /// 把表格内容输出到excel里
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="opmodel"></param>
        public void OutPutExcel(DataGridView dgv, OutPutExcelModel opmodel, int columnsNumber)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add();
            excel.SheetsInNewWorkbook = 1;
            //显示当前窗口
            excel.Visible = true;

            Range range = null;
            int RowMax = dgv.Rows.Count + 1;      //一共需要多少条记录行 +1个标题行
            int Columnmax = columnsNumber;     //一共需要多少列
            int StartRow = 1;                //开始行
            int StartColumn = 1;              //开始列
            //标题
            range = excel.Range[excel.Cells[StartRow, StartColumn], excel.Cells[StartRow, Columnmax]];
            range.Merge();
            range.Font.Size = 22;
            //设置对齐方式
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //设置行高
            range.RowHeight = 25;
            excel.Cells[StartRow, StartColumn] = opmodel.Name;
            //时间
            StartRow++;
            range = excel.Range[excel.Cells[StartRow, StartColumn], excel.Cells[StartRow, Columnmax]];
            range.Merge();
            range.Font.Size = 12;
            //设置对齐方式
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //设置行高
            range.RowHeight = 20;
            excel.Cells[StartRow, StartColumn] = opmodel.StartDay.ToLongDateString() + " 至 " + opmodel.EndDay.ToLongDateString();

            //标题行
            StartRow++;
            range = excel.Range[excel.Cells[StartRow, StartColumn], excel.Cells[StartRow, Columnmax]];
            range.Font.Size = 12;
            range.Font.Bold = true;
            range.Interior.ColorIndex = 15;    //设置背景样式
            range.ColumnWidth = 12;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            for (int i = 0; i < columnsNumber; i++)
            {
                range = excel.Range[excel.Cells[StartRow, i + 1], excel.Cells[StartRow, i + 1]];
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Font.Size = 10;
                excel.Cells[StartRow, i + 1] = dgv.Columns[i].HeaderText;
            }

            //内容行
            StartRow++;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < columnsNumber; j++)
                {
                    range = excel.Range[excel.Cells[StartRow + i, j + 1], excel.Cells[StartRow + i, j + 1]];
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                    range.Font.Size = 10;
                    excel.Cells[StartRow + i, j + 1] = (dgv.Rows[i].Cells[j].Value == null ? "" : dgv.Rows[i].Cells[j].Value.ToString());
                    range.Interior.Color = (dgv.Rows[i].Cells[j].InheritedStyle.BackColor.Name == "Window" ? Color.White : dgv.Rows[i].Cells[j].InheritedStyle.BackColor);
                }
            }


        }

        /// <summary>
        /// 把查询结果的datagridview装入到Excel表格内  columnNumber展示列的数量
        /// </summary>
        /// <param name="dgv"></param>
        public string FindDataToExcel(DataGridView dgv, BillIndex b, int columnNumber)
        {
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
                int cols = columnNumber;     //这里指定列的数量
                int startRow = 1;
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excel.Cells[startRow, 1] = b.Title;
                startRow++;
                excel.Cells[startRow, 1] = b.ID;   //借用ID字段 存储时间
                excel.Cells[startRow, 2] = b.Voyage;   //航线
                startRow++;
                //列内容
                for (int i = 0; i < cols; i++)
                {
                    excel.Cells[startRow, i + 1] = dgv.Columns[i + 1].HeaderText;
                }
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                startRow++;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        excel.Cells[startRow, j + 1] = item.Cells[j + 1].Value.ToString();
                    }
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
        /// <summary>
        /// 导出基础数据到Excel
        /// </summary>
        /// <returns></returns>
        public string SaveToBaseData(DataGridView dgv, string baseName)
        {
            string result = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;
                int rows = dgv.Rows.Count;
                int cols = dgv.Columns.Count - 1;
                int startRow = 1;
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excel.Cells[startRow, 1] = baseName + "基础数据表";
                startRow++;
                //列内容
                for (int i = 0; i < cols; i++)
                {
                    excel.Cells[startRow, i + 1] = dgv.Columns[i].HeaderText;
                }
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, cols]];
                range.ColumnWidth = 30;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                startRow++;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        excel.Cells[startRow, j + 1] = item.Cells[j].Value.ToString();
                    }
                    startRow++;
                }
                result = "";
            }
            catch (Exception ex)
            {
                result = ex.Message;
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
            return result;
        }


        /// <summary>
        /// 导入Excel到基础数据库
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="columns"></param>
        /// <param name="baseContent"></param>
        /// <returns></returns>
        public string LoadToBaseDB(string filename, int columns, ref List<string> baseContent)
        {
            string result = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range rContent = null;
            baseContent = new List<string>();   //重新记录
            try
            {
                excel.DisplayAlerts = false;           //关闭是否提示
                excel.Workbooks.Open(filename);                      //打开文件
                //选取第一个工作表
                excel.SheetsInNewWorkbook = 1;
                //不显示当前窗口
                excel.Visible = false;

                int row = 3;                               //从第三行开始读出数据
                rContent = excel.Cells[row, 2] as Range;    //判断是否有内容
                while (rContent.Text.ToString().Trim() != "")     //不为空则往下读
                {
                    //一行对应一个string 中间每列用 ,分割
                    string rowContent = "";
                    for (int i = 1; i < columns + 1; i++)
                    {
                        rContent = excel.Cells[row, i] as Range;
                        rowContent += rContent.Text.ToString().Trim() + ",";
                    }
                    baseContent.Add(rowContent.Substring(0, rowContent.Length - 1));    //加入元素
                    row++;
                    rContent = excel.Cells[row, 2] as Range;    //判断是否有内容
                }
                result = "";
            }
            catch (Exception ex)
            {
                result = ex.Message;
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
            return result;
        }

        /// <summary>
        /// 按货种快速汇总
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string QuickCountByGoodsType(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> goodstype = new Dictionary<string, int>();    // 进口货物名  int 为第几列
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少货种
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountGoodsTypeUp"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountGoodsTypeUp"].Value.ToString();
                    if (item.Cells["dgvCountGoodsTypeUp"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!goodstype.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的货种
                            goodstype.Add("进口" + context, 0);
                        }
                        if (!goodstype.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的货种
                            goodstype.Add("出口" + context, 0);
                        }
                    }
                }


                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分货种";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";
                int colums = 2;     //从第三列开始
                string gName = "";     //货种名称
                //这里是进口的列  第5行是 货种名称  第4行是进口 出口
                for (int i = 0; i < goodstype.Keys.Count; i++)
                {
                    if (goodstype.Keys.ElementAt(i).Contains("进口"))
                    {
                        goodstype[goodstype.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = goodstype.Keys.ElementAt(i).Substring(2);   //货种名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口货种小计  上面行写如进口
                goodstype.Add("进口小计", colums);
                excel.Cells[5, colums] = "小计";
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                colums++;
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < goodstype.Keys.Count; i++)
                {
                    if (goodstype.Keys.ElementAt(i).Contains("出口"))
                    {
                        goodstype[goodstype.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = goodstype.Keys.ElementAt(i).Substring(2);   //货种名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口货种小计
                goodstype.Add("出口小计", colums);
                excel.Cells[5, colums] = "小计";
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的船次和船公司 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计")  //只计算不是小计项目的
                        continue;
                    //if (item.Cells["dgvCountShipInfo"].Value.ToString() != "") 
                    //{
                    //    //计算行小计
                    //    excel.Cells[startRow, goodstype["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                    //    excel.Cells[startRow, goodstype["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                    //    intotal = 0;
                    //    outtotal = 0;
                    //    //增加一行
                    //    startRow++;
                    //    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")   //如果更换代理了
                    //    {
                    //        company = item.Cells["dgvCountCompany"].Value.ToString();
                    //        excel.Cells[startRow, 1] = company;
                    //    }

                    //}
                    //else
                    //{
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")   //如果更换代理了
                    {
                        if (item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        {
                            break;
                        }
                        else
                        {
                            //计算行小计
                            excel.Cells[startRow, goodstype["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                            excel.Cells[startRow, goodstype["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                            intotal = 0;
                            outtotal = 0;
                            //增加一行
                            company = item.Cells["dgvCountCompany"].Value.ToString();
                            startRow++;
                            excel.Cells[startRow, 1] = company;
                        }
                    }

                    //这里写入货种的数量
                    //检索货种在
                    gName = item.Cells["dgvCountGoodsTypeUp"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, goodstype["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, goodstype["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, goodstype["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, goodstype["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 1; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;    //居中
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;


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

        /// <summary>
        /// 船公司分类汇总
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByCompany(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;

                //标题及时间
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, 13]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, 13]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;

                excel.Cells[3, 1] = "分船公司";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 12;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 1] = "船公司";
                //进口
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, 5]];   //进口
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 12;
                excel.Cells[4, 2] = "进口";
                excel.Cells[5, 2] = "20重";
                excel.Cells[5, 3] = "20空";
                excel.Cells[5, 4] = "40重";
                excel.Cells[5, 5] = "40空";
                range = excel.Range[excel.Cells[5, 2], excel.Cells[5, 5]];
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //出口
                range = excel.Range[excel.Cells[4, 6], excel.Cells[4, 9]];   //进口
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 12;
                excel.Cells[4, 6] = "出口";
                excel.Cells[5, 6] = "20重";
                excel.Cells[5, 7] = "20空";
                excel.Cells[5, 8] = "40重";
                excel.Cells[5, 9] = "40空";
                range = excel.Range[excel.Cells[5, 6], excel.Cells[5, 9]];
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //小计自然箱
                range = excel.Range[excel.Cells[4, 10], excel.Cells[5, 10]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 10] = "小计\n（自然箱）";
                //进口TEU
                range = excel.Range[excel.Cells[4, 11], excel.Cells[5, 11]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 11] = "进口(TEU)";
                //出口TEU
                range = excel.Range[excel.Cells[4, 12], excel.Cells[5, 12]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 12] = "出口(TEU)";
                //总计TEU
                range = excel.Range[excel.Cells[4, 13], excel.Cells[5, 13]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 13] = "总计(TEU)";
                //修饰
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 13]];
                range.Interior.ColorIndex = 15;    //设置背景样式

                //循环加入记录
                int startRow = 6;    //起始行号
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    excel.Cells[startRow, 1] = item.Cells["dgvCountCompany"].Value.ToString();     //这是船公司
                    excel.Cells[startRow, 2] = item.Cells["dgvCount进口20重"].Value.ToString();     //进口20重
                    excel.Cells[startRow, 3] = item.Cells["dgvCount进口20空"].Value.ToString();     //进口20空
                    excel.Cells[startRow, 4] = item.Cells["dgvCount进口40重"].Value.ToString();     //进口40重
                    excel.Cells[startRow, 5] = item.Cells["dgvCount进口40空"].Value.ToString();     //进口40空
                    excel.Cells[startRow, 6] = item.Cells["dgvCount出口20重"].Value.ToString();     //出口20重
                    excel.Cells[startRow, 7] = item.Cells["dgvCount出口20空"].Value.ToString();     //出口20空
                    excel.Cells[startRow, 8] = item.Cells["dgvCount出口40重"].Value.ToString();     //出口40重
                    excel.Cells[startRow, 9] = item.Cells["dgvCount出口40空"].Value.ToString();     //出口40空
                    excel.Cells[startRow, 10] = item.Cells["dgvCount小计"].Value.ToString();     //小计自然箱
                    excel.Cells[startRow, 11] = item.Cells["dgvCount进口"].Value.ToString();     //进口TEU
                    excel.Cells[startRow, 12] = item.Cells["dgvCount出口"].Value.ToString();     //出口TEU
                    excel.Cells[startRow, 13] = item.Cells["dgvCount总计"].Value.ToString();     //总计TEU
                    startRow++;
                }
                //最后一行 字体修饰
                range = excel.Range[excel.Cells[startRow - 1, 1], excel.Cells[startRow - 1, 13]];
                range.Font.Bold = true;
                //整个表格字体样式 表格线
                range = excel.Range[excel.Cells[6, 1], excel.Cells[startRow - 1, 13]];
                range.Font.Size = 10;
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow - 1, 13]];
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
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
        /// <summary>
        /// 快速汇总 分目的港
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByAim(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> aims = new Dictionary<string, int>();    //目的港
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少目的港
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountAim"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountAim"].Value.ToString();
                    if (item.Cells["dgvCountAim"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!aims.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的目的港
                            aims.Add("进口" + context, 0);
                        }
                        if (!aims.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的目的港
                            aims.Add("出口" + context, 0);
                        }
                    }

                }
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分目的港";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";

                int colums = 2;     //从第二列开始
                string gName = "";     //货种名称
                //这里是进口的列  第5行是 目的港名称  第4行是进口 出口
                for (int i = 0; i < aims.Keys.Count; i++)
                {
                    if (aims.Keys.ElementAt(i).Contains("进口"))
                    {
                        aims[aims.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = aims.Keys.ElementAt(i).Substring(2);   //货种名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口上标题
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < aims.Keys.Count; i++)
                {
                    if (aims.Keys.ElementAt(i).Contains("出口"))
                    {
                        aims[aims.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = aims.Keys.ElementAt(i).Substring(2);   //货种名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口上标题
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                aims.Add("进口小计", colums);
                excel.Cells[4, colums] = "进口";
                colums++;
                aims.Add("出口小计", colums);
                excel.Cells[4, colums] = "出口";
                colums++;
                aims.Add("小计", colums);
                excel.Cells[4, colums] = "小计";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, colums]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的目的港 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value == null)
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")    //如果更换船舶名称
                    {
                        //计算行小计
                        excel.Cells[startRow, aims["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                        excel.Cells[startRow, aims["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                        excel.Cells[startRow, aims["小计"]] = (intotal + outtotal).ToString();
                        intotal = 0;
                        outtotal = 0;
                        //增加一行
                        company = item.Cells["dgvCountCompany"].Value.ToString();
                        startRow++;
                        excel.Cells[startRow, 1] = company;
                    }
                    //检索目的港
                    gName = item.Cells["dgvCountAim"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, aims["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, aims["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, aims["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, aims["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                excel.Cells[startRow, aims["小计"]] = (intotal + outtotal).ToString();
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 2; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //自然箱的文字
                range = excel.Range[excel.Cells[3, aims["进口小计"]], excel.Cells[3, aims["小计"]]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excel.Cells[3, aims["进口小计"]] = "单位：自然箱";
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;
                //最后汇总粗体
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, colums]];
                range.Font.Bold = true;

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


        /// <summary>
        /// 快速汇总 分代理
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByProxy(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> proxys = new Dictionary<string, int>();    //目的港
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少代理
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountProxy"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountProxy"].Value.ToString();
                    if (item.Cells["dgvCountProxy"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!proxys.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的代理
                            proxys.Add("进口" + context, 0);
                        }
                        if (!proxys.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的代理
                            proxys.Add("出口" + context, 0);
                        }
                    }

                }
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分代理";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";

                int colums = 2;     //从第二列开始
                string gName = "";     //代理名称
                //这里是进口的列  第5行是 代理名称  第4行是进口 出口
                for (int i = 0; i < proxys.Keys.Count; i++)
                {
                    if (proxys.Keys.ElementAt(i).Contains("进口"))
                    {
                        proxys[proxys.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = proxys.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口上标题
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < proxys.Keys.Count; i++)
                {
                    if (proxys.Keys.ElementAt(i).Contains("出口"))
                    {
                        proxys[proxys.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = proxys.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口上标题
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                proxys.Add("进口小计", colums);
                excel.Cells[4, colums] = "进口";
                colums++;
                proxys.Add("出口小计", colums);
                excel.Cells[4, colums] = "出口";
                colums++;
                proxys.Add("小计", colums);
                excel.Cells[4, colums] = "小计";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, colums]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的目的港 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value == null)
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")    //如果更换船舶名称
                    {
                        //计算行小计
                        excel.Cells[startRow, proxys["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                        excel.Cells[startRow, proxys["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                        excel.Cells[startRow, proxys["小计"]] = (intotal + outtotal).ToString();
                        intotal = 0;
                        outtotal = 0;
                        //增加一行
                        company = item.Cells["dgvCountCompany"].Value.ToString();
                        startRow++;
                        excel.Cells[startRow, 1] = company;
                    }
                    //检索目的港
                    gName = item.Cells["dgvCountProxy"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, proxys["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, proxys["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, proxys["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, proxys["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                excel.Cells[startRow, proxys["小计"]] = (intotal + outtotal).ToString();
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 2; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //自然箱的文字
                range = excel.Range[excel.Cells[3, proxys["进口小计"]], excel.Cells[3, proxys["小计"]]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excel.Cells[3, proxys["进口小计"]] = "单位：自然箱";
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;
                //最后汇总粗体
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, colums]];
                range.Font.Bold = true;

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

        /// <summary>
        /// 快速汇总 分来源地
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountBySource(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> sources = new Dictionary<string, int>();    //目的港
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少来源地
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountSource"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountSource"].Value.ToString();
                    if (item.Cells["dgvCountSource"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!sources.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的来源地
                            sources.Add("进口" + context, 0);
                        }
                        if (!sources.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是出口的来源地
                            sources.Add("出口" + context, 0);
                        }
                    }

                }
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分来源地";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";

                int colums = 2;     //从第二列开始
                string gName = "";     //代理名称
                //这里是进口的列  第5行是 代理名称  第4行是进口 出口
                for (int i = 0; i < sources.Keys.Count; i++)
                {
                    if (sources.Keys.ElementAt(i).Contains("进口"))
                    {
                        sources[sources.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = sources.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口上标题
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < sources.Keys.Count; i++)
                {
                    if (sources.Keys.ElementAt(i).Contains("出口"))
                    {
                        sources[sources.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = sources.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口上标题
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                sources.Add("进口小计", colums);
                excel.Cells[4, colums] = "进口";
                colums++;
                sources.Add("出口小计", colums);
                excel.Cells[4, colums] = "出口";
                colums++;
                sources.Add("小计", colums);
                excel.Cells[4, colums] = "小计";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, colums]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的目的港 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value == null)
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")    //如果更换船舶名称
                    {
                        //计算行小计
                        excel.Cells[startRow, sources["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                        excel.Cells[startRow, sources["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                        excel.Cells[startRow, sources["小计"]] = (intotal + outtotal).ToString();
                        intotal = 0;
                        outtotal = 0;
                        //增加一行
                        company = item.Cells["dgvCountCompany"].Value.ToString();
                        startRow++;
                        excel.Cells[startRow, 1] = company;
                    }
                    //检索目的港
                    gName = item.Cells["dgvCountSource"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, sources["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, sources["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, sources["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, sources["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                excel.Cells[startRow, sources["小计"]] = (intotal + outtotal).ToString();
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 2; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //自然箱的文字
                range = excel.Range[excel.Cells[3, sources["进口小计"]], excel.Cells[3, sources["小计"]]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excel.Cells[3, sources["进口小计"]] = "单位：自然箱";
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;
                //最后汇总粗体
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, colums]];
                range.Font.Bold = true;

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



        /// <summary>
        /// 快速汇总 分流向
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByDirection(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> direction = new Dictionary<string, int>();    //目的港
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少流向
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountDirection"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountDirection"].Value.ToString();
                    if (item.Cells["dgvCountDirection"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!direction.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的流向
                            direction.Add("进口" + context, 0);
                        }
                        if (!direction.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是出口的流向
                            direction.Add("出口" + context, 0);
                        }
                    }

                }
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分流向";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";

                int colums = 2;     //从第二列开始
                string gName = "";     //代理名称
                //这里是进口的列  第5行是 流向名称  第4行是进口 出口
                for (int i = 0; i < direction.Keys.Count; i++)
                {
                    if (direction.Keys.ElementAt(i).Contains("进口"))
                    {
                        direction[direction.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = direction.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口上标题
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < direction.Keys.Count; i++)
                {
                    if (direction.Keys.ElementAt(i).Contains("出口"))
                    {
                        direction[direction.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = direction.Keys.ElementAt(i).Substring(2);   //流向名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口上标题
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                direction.Add("进口小计", colums);
                excel.Cells[4, colums] = "进口";
                colums++;
                direction.Add("出口小计", colums);
                excel.Cells[4, colums] = "出口";
                colums++;
                direction.Add("小计", colums);
                excel.Cells[4, colums] = "小计";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, colums]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的目的港 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value == null)
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")    //如果更换船舶名称
                    {
                        //计算行小计
                        excel.Cells[startRow, direction["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                        excel.Cells[startRow, direction["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                        excel.Cells[startRow, direction["小计"]] = (intotal + outtotal).ToString();
                        intotal = 0;
                        outtotal = 0;
                        //增加一行
                        company = item.Cells["dgvCountCompany"].Value.ToString();
                        startRow++;
                        excel.Cells[startRow, 1] = company;
                    }
                    //检索目的港
                    gName = item.Cells["dgvCountDirection"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, direction["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, direction["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, direction["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, direction["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                excel.Cells[startRow, direction["小计"]] = (intotal + outtotal).ToString();
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 2; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //自然箱的文字
                range = excel.Range[excel.Cells[3, direction["进口小计"]], excel.Cells[3, direction["小计"]]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excel.Cells[3, direction["进口小计"]] = "单位：自然箱";
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;
                //最后汇总粗体
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, colums]];
                range.Font.Bold = true;

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


        /// <summary>
        /// 快速汇总 分发往地
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountBySendPlace(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> sendplace = new Dictionary<string, int>();    //目的港
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                //计算一共有多少流向
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountSendPlace"].Value == null)
                        continue;
                    string context = item.Cells["dgvCountSendPlace"].Value.ToString();
                    if (item.Cells["dgvCountSendPlace"].Style.BackColor.ToArgb() == 0)   //判断是否有小计
                    {
                        if (!sendplace.Keys.Contains("进口" + context) && (item.Cells["dgvCount进口20空"].Value.ToString() != "" || item.Cells["dgvCount进口20重"].Value.ToString() != "" || item.Cells["dgvCount进口40空"].Value.ToString() != "" || item.Cells["dgvCount进口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是进口的流向
                            sendplace.Add("进口" + context, 0);
                        }
                        if (!sendplace.Keys.Contains("出口" + context) && (item.Cells["dgvCount出口20空"].Value.ToString() != "" || item.Cells["dgvCount出口20重"].Value.ToString() != "" || item.Cells["dgvCount出口40空"].Value.ToString() != "" || item.Cells["dgvCount出口40重"].Value.ToString() != ""))   //不包括内容
                        {
                            //这是出口的流向
                            sendplace.Add("出口" + context, 0);
                        }
                    }

                }
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;


                excel.Cells[3, 1] = "分发往地";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 1] = "船公司";

                int colums = 2;     //从第二列开始
                string gName = "";     //代理名称
                //这里是进口的列  第5行是 流向名称  第4行是进口 出口
                for (int i = 0; i < sendplace.Keys.Count; i++)
                {
                    if (sendplace.Keys.ElementAt(i).Contains("进口"))
                    {
                        sendplace[sendplace.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = sendplace.Keys.ElementAt(i).Substring(2);   //代理名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //进口上标题
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, 2] = "进口";
                int tmpColumns = colums;
                //这里是出口的列
                for (int i = 0; i < sendplace.Keys.Count; i++)
                {
                    if (sendplace.Keys.ElementAt(i).Contains("出口"))
                    {
                        sendplace[sendplace.Keys.ElementAt(i)] = colums;  //存上相应的列数
                        gName = sendplace.Keys.ElementAt(i).Substring(2);   //流向名称
                        excel.Cells[5, colums] = gName;
                        colums++;    //增加数量
                    }
                }
                //出口上标题
                range = excel.Range[excel.Cells[4, tmpColumns], excel.Cells[4, colums - 1]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[4, tmpColumns] = "出口";

                sendplace.Add("进口小计", colums);
                excel.Cells[4, colums] = "进口";
                colums++;
                sendplace.Add("出口小计", colums);
                excel.Cells[4, colums] = "出口";
                colums++;
                sendplace.Add("小计", colums);
                excel.Cells[4, colums] = "小计";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, colums]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;    //设置背景样式

                int startRow = 6;    //存储记录行列
                string company = dgv.Rows[0].Cells["dgvCountCompany"].Value.ToString();     //存储起始的目的港 
                int intotal = 0, outtotal = 0;    //进出小计
                excel.Cells[startRow, 1] = company;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //这里看是否有小计
                    if (item.Cells["dgvCountCompany"].Value == null)
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    if (item.Cells["dgvCountCompany"].Value.ToString() != company && item.Cells["dgvCountCompany"].Value.ToString() != "")    //如果更换船舶名称
                    {
                        //计算行小计
                        excel.Cells[startRow, sendplace["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                        excel.Cells[startRow, sendplace["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                        excel.Cells[startRow, sendplace["小计"]] = (intotal + outtotal).ToString();
                        intotal = 0;
                        outtotal = 0;
                        //增加一行
                        company = item.Cells["dgvCountCompany"].Value.ToString();
                        startRow++;
                        excel.Cells[startRow, 1] = company;
                    }
                    //检索目的港
                    gName = item.Cells["dgvCountSendPlace"].Value.ToString();
                    //计算 出口自然箱  进口自然箱
                    int ins = 0, outs = 0;
                    if (item.Cells["dgvCount进口40重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口40空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20空"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount进口20重"].Value.ToString() != "")
                    {
                        ins += int.Parse(item.Cells["dgvCount进口20重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40重"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口40空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口40空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20空"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20空"].Value.ToString());
                    }
                    if (item.Cells["dgvCount出口20重"].Value.ToString() != "")
                    {
                        outs += int.Parse(item.Cells["dgvCount出口20重"].Value.ToString());
                    }
                    if (ins != 0)
                    {
                        excel.Cells[startRow, sendplace["进口" + gName]] = ins.ToString();
                    }
                    if (outs != 0)
                    {
                        excel.Cells[startRow, sendplace["出口" + gName]] = outs.ToString();
                    }
                    intotal += ins;
                    outtotal += outs;
                }
                //计算行小计 最后一个
                excel.Cells[startRow, sendplace["进口小计"]] = (intotal == 0 ? "" : intotal.ToString());
                excel.Cells[startRow, sendplace["出口小计"]] = (outtotal == 0 ? "" : outtotal.ToString());
                excel.Cells[startRow, sendplace["小计"]] = (intotal + outtotal).ToString();
                //计算总计
                startRow++;
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < colums + 2; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //自然箱的文字
                range = excel.Range[excel.Cells[3, sendplace["进口小计"]], excel.Cells[3, sendplace["小计"]]];
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                excel.Cells[3, sendplace["进口小计"]] = "单位：自然箱";
                //最后处理字体 及标题
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, colums]];
                range.Font.Size = 10;
                range.ColumnWidth = 10;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, colums]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, colums]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;
                //最后汇总粗体
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, colums]];
                range.Font.Bold = true;

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




        /// <summary>
        /// 快速汇总 分主船
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByMain(DataGridView dgv, string time)
        {
            if (dgv.Rows.Count < 2)
                return "汇总数据不全";
            Dictionary<string, int> sources = new Dictionary<string, int>();    //主船
            string error = "";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;

                //标题及时间
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, 13]];
                range.Merge();
                range.Font.Size = 20;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[1, 1] = "船舶分类汇总信息表";
                range = excel.Range[excel.Cells[2, 1], excel.Cells[2, 13]];
                range.Merge();
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                excel.Cells[2, 1] = time;

                excel.Cells[3, 1] = "直航线船";
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 1]];   //船公司
                range.Merge();
                //range.Interior.ColorIndex = 15;    //设置背景样式
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 12;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 1] = "船公司";
                //进口
                range = excel.Range[excel.Cells[4, 2], excel.Cells[4, 5]];   //进口
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 12;
                excel.Cells[4, 2] = "进口";
                excel.Cells[5, 2] = "20重";
                excel.Cells[5, 3] = "20空";
                excel.Cells[5, 4] = "40重";
                excel.Cells[5, 5] = "40空";
                range = excel.Range[excel.Cells[5, 2], excel.Cells[5, 5]];
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //出口
                range = excel.Range[excel.Cells[4, 6], excel.Cells[4, 9]];   //进口
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Size = 12;
                excel.Cells[4, 6] = "出口";
                excel.Cells[5, 6] = "20重";
                excel.Cells[5, 7] = "20空";
                excel.Cells[5, 8] = "40重";
                excel.Cells[5, 9] = "40空";
                range = excel.Range[excel.Cells[5, 6], excel.Cells[5, 9]];
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //小计自然箱
                range = excel.Range[excel.Cells[4, 10], excel.Cells[5, 10]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 10] = "小计\n（自然箱）";
                //进口TEU
                range = excel.Range[excel.Cells[4, 11], excel.Cells[5, 11]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 11] = "进口(TEU)";
                //出口TEU
                range = excel.Range[excel.Cells[4, 12], excel.Cells[5, 12]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 12] = "出口(TEU)";
                //总计TEU
                range = excel.Range[excel.Cells[4, 13], excel.Cells[5, 13]];   //船公司
                range.Merge();
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //居中
                range.ColumnWidth = 10;
                range.Font.Size = 10;
                range.Font.Bold = true;
                excel.Cells[4, 13] = "总计(TEU)";
                //修饰
                range = excel.Range[excel.Cells[4, 1], excel.Cells[5, 13]];
                range.Interior.ColorIndex = 15;    //设置背景样式

                //循环加入记录
                int startRow = 6;    //起始行号
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells["dgvCountCompany"].Value.ToString() == "小计" || item.Cells["dgvCountShipType"].Value.ToString() == "驳船" || item.Cells["dgvCountCompany"].Value.ToString() == "总计")
                        continue;
                    excel.Cells[startRow, 1] = item.Cells["dgvCountCompany"].Value.ToString();     //这是船公司
                    excel.Cells[startRow, 2] = item.Cells["dgvCount进口20重"].Value.ToString();     //进口20重
                    excel.Cells[startRow, 3] = item.Cells["dgvCount进口20空"].Value.ToString();     //进口20空
                    excel.Cells[startRow, 4] = item.Cells["dgvCount进口40重"].Value.ToString();     //进口40重
                    excel.Cells[startRow, 5] = item.Cells["dgvCount进口40空"].Value.ToString();     //进口40空
                    excel.Cells[startRow, 6] = item.Cells["dgvCount出口20重"].Value.ToString();     //出口20重
                    excel.Cells[startRow, 7] = item.Cells["dgvCount出口20空"].Value.ToString();     //出口20空
                    excel.Cells[startRow, 8] = item.Cells["dgvCount出口40重"].Value.ToString();     //出口40重
                    excel.Cells[startRow, 9] = item.Cells["dgvCount出口40空"].Value.ToString();     //出口40空
                    excel.Cells[startRow, 10] = item.Cells["dgvCount小计"].Value.ToString();     //小计自然箱
                    excel.Cells[startRow, 11] = item.Cells["dgvCount进口"].Value.ToString();     //进口TEU
                    excel.Cells[startRow, 12] = item.Cells["dgvCount出口"].Value.ToString();     //出口TEU
                    excel.Cells[startRow, 13] = item.Cells["dgvCount总计"].Value.ToString();     //总计TEU
                    startRow++;
                }
                //计算总计
                excel.Cells[startRow, 1] = "合计";
                for (int i = 2; i < 14 + 1; i++)     //列循环计算合计
                {
                    int total = 0;
                    for (int j = 6; j < startRow; j++)
                    {
                        range = excel.Range[excel.Cells[j, i], excel.Cells[j, i]];
                        if (range.Text.ToString() != "")
                            total += int.Parse(range.Text.ToString());
                    }
                    excel.Cells[startRow, i] = (total == 0 ? "" : total.ToString());
                }
                //最后一行 字体修饰
                range = excel.Range[excel.Cells[startRow, 1], excel.Cells[startRow, 13]];
                range.Font.Bold = true;
                //整个表格字体样式 表格线
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, 13]];
                range.Font.Size = 10;
                range = excel.Range[excel.Cells[3, 1], excel.Cells[startRow, 13]];
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;

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

        /// <summary>
        /// 快速汇总货种流向
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string QuickCountByGoodsAim(DataGridView dgv, string time,List<string> goodsNames)
        {
            if (dgv.Rows.Count ==0)
                return "汇总数据不全";
            string error = "";
            int totalColumns = dgv.Columns.Count;
            int rows = 1;
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();    //创建excel实例
            Range range = null;
            try
            {
                excel.Workbooks.Add();
                excel.SheetsInNewWorkbook = 1;
                //显示当前窗口
                excel.Visible = true;

                //标题及时间
                range = excel.Range[excel.Cells[rows, 1], excel.Cells[rows, totalColumns]];
                range.Merge();
                range.Font.Name = @"仿宋";
                range.Font.Size = 16;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //标题居中
                range.ColumnWidth = 6;
                excel.Cells[rows, 1] = "集装箱分流向吞吐量";
                rows++;
                range = excel.Range[excel.Cells[rows, 1], excel.Cells[rows, totalColumns - 2]];
                range.Font.Size = 10;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //日期文字
                excel.Cells[rows, totalColumns - 2] = "日期：";
                range = excel.Range[excel.Cells[rows, 1], excel.Cells[rows, totalColumns-1]];
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;    //日期内容
                excel.Cells[rows, totalColumns-1] = time;
                rows++;
                //设置标题行
                range = excel.Range[excel.Cells[rows, 1], excel.Cells[rows+1, 1]];
                range.Merge();
                range = excel.Range[excel.Cells[rows, 2], excel.Cells[rows + 1, 2]];
                range.Merge();
                for (int i = 0; i < goodsNames.Count; i++)
                {
                    range = excel.Range[excel.Cells[rows, i+3], excel.Cells[rows + 1, i+3]];
                    range.Merge();
                    range.Font.Size = 10;
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    range.Font.Bold = true;
                    excel.Cells[rows, i+3] = goodsNames[i];
                }
                //结尾汇总
                range = excel.Range[excel.Cells[rows, goodsNames.Count + 3], excel.Cells[rows + 1, goodsNames.Count + 3]];
                range.Merge();
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Bold = true;
                excel.Cells[rows, goodsNames.Count + 3] = "合计（TEU)";
                range = excel.Range[excel.Cells[rows, goodsNames.Count + 4], excel.Cells[rows + 1, goodsNames.Count + 4]];
                range.Merge();
                range.Font.Size = 10;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.Font.Bold = true;
                excel.Cells[rows, goodsNames.Count + 4] = "吞吐量（吨）";

                rows += 2;
                int startRows = rows;   //开始计入起始行 为以后的公式准备
                //开始循环输出表格内容
                for (int i = 0; i < dgv.Rows.Count+1; i++)
                {
                    //检测是否已经到记录结尾
                    if (i == dgv.Rows.Count)
                    {
                        //输出另一个小计
                        excel.Cells[rows, 2] = "小计";
                        for (int j = 2; j < dgv.Columns.Count; j++)
                        {
                            excel.Cells[rows, j + 1] = "=SUM(" + IndexToColumn(j + 1) + startRows + ":" + IndexToColumn(j + 1) + (rows - 1).ToString() + ")";
                        }
                        range = excel.Range[excel.Cells[rows, 2], excel.Cells[rows, totalColumns]];
                        range.Interior.Color = Color.FromArgb(255,255,153);
                        //画线
                        range = excel.Range[excel.Cells[3, 1], excel.Cells[rows, totalColumns]];
                        range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = 1;
                        range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                        range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                        range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = 1;
                        range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                        range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = 1;
                        continue;
                    }

                    //检测是否为红色背景 输出小计
                    if (dgv.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                    {
                        excel.Cells[rows, 2] = "小计";
                        
                        for (int j = 2; j < dgv.Columns.Count; j++)
                        {
                            excel.Cells[rows, j + 1] = "=SUM(" + IndexToColumn(j+1) + startRows + ":" + IndexToColumn(j+1)+(rows-1).ToString()+")";
                        }
                        range = excel.Range[excel.Cells[rows, 2], excel.Cells[rows, totalColumns]];
                        range.Interior.Color = Color.FromArgb(255, 255, 153);
                        startRows = rows + 1;     //新的计算起始行
                    }
                    else
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (dgv.Rows[i].Cells[j].Value == null)
                            {
                                excel.Cells[rows, j + 1] = "";
                            }
                            else
                            {
                                excel.Cells[rows, j + 1] = (dgv.Rows[i].Cells[j].Value.ToString() == "0" ? "" : dgv.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                    }
                    rows++;
                }
                //输出总计

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
        /// <summary>
        /// 用于将excel表格中列索引转成列号字母，从A对应1开始
        /// </summary>
        /// <param name="index">列索引</param>
        /// <returns>列号</returns>
        public static string IndexToColumn(int index)
        {
            if (index <= 0)
            {
                throw new Exception("Invalid parameter");
            }
            index--;
            string column = string.Empty;
            do
            {
                if (column.Length > 0)
                {
                    index--;
                }
                column = ((char)(index % 26 + (int)'A')).ToString() + column;
                index = (int)((index - index % 26) / 26);
            } while (index > 0);
            return column;
        }
    }
}
