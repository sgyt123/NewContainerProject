using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseDAL;
using System.Windows.Forms;
using System.Drawing;
using ConfigManager;
using Model;

namespace BillManager
{
    public class CountManager
    {
        /// <summary>
        /// 删除明细单及索引记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteBills(string id)
        {
            return new BillFindService().DeleteBill(id);
        }
        /// <summary>
        /// 初始化汇总表格
        /// </summary>
        /// <param name="stru"></param>
        /// <param name="cond"></param>
        /// <param name="dgv"></param>
        public void SearchInitDataGridView(Dictionary<string, string> stru, string[] cond, DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;   //选择模式为整行 
            dgv.MultiSelect = true;                                       //不可以多选
            dgv.RowHeadersVisible = false;                                 //隐藏头一列
            dgv.AllowUserToResizeRows = false;                             //设置行是否可以调整大小
            dgv.BackgroundColor = Color.White;                               //设置背景颜色
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;      //设置列头不能自动高度
            dgv.ColumnHeadersHeight = 24;                                  //列头部高
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DeepSkyBlue };
            dgv.GridColor = Color.Black;
            //序号ckSequence 	箱号	 封号	重量	 箱型	状态 	船公司	目的港	货种 	作业地点	代理	 船名/航次	运单号	来源地
            foreach (string item in cond)
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = item, Width = 70, Name = "dgvCount" + stru[item], SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            }
            //这里是明细 进出方向
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = item_InOut + item_2040 + item_State, Width = 70, Name = "dgvCount" + item_InOut + item_2040 + item_State, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                    }
                }
            }
            //这里是行 小计 
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "小计(自然箱)", Width = 90, Name = "dgvCount" + "小计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter ,BackColor = Color.Gray }});
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //插入 进口 出口 合计
                dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = item_InOut + "(TEU)", Width = 70, Name = "dgvCount" + item_InOut, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DarkCyan } });
            }
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "总计(TEU)", Width = 70, Name = "dgvCount" + "总计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Gray } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "停泊艘次", Width = 70, Name = "dgvCount" + "ShipNumber", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Goldenrod } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "作业艘次", Width = 70, Name = "dgvCount" + "ShipNumber1", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Goldenrod } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "总重量", Width = 70, Name = "dgvCount" + "TotalWeight", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Goldenrod } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "货物重量", Width = 70, Name = "dgvCount" + "GoodsWeight", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Goldenrod } });
            dgv.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "详情", Width = 60, Name = "dgvCountDetail", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DarkCyan }, Text = "点击查询" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "SQL语句", Width = 60, Name = "dgvCount" + "SQL", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }, Visible = false });
        }

        public List<Bill> GetGroupByTotal(string where)
        {
            return new BillService().GetGroupByContent(where);
        }
        /// <summary>
        /// 循环计算表格内小计 及消除相同项
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cond"></param>
        public void AddSmallTotal(DataGridView dgv, string[] cond, Dictionary<string, string> stru)
        {
            ///先存储第一行内容
            Dictionary<string, string> context = new Dictionary<string, string>();    //这里是记录上次存储的内容
            Dictionary<string, int> rowsNumber = new Dictionary<string, int>();      //这是记录没列出现内容的次数
            Dictionary<string, int> samllCount = new Dictionary<string, int>();      //小计的数量
            Dictionary<string, int> InOut2040 = new Dictionary<string, int>();       //进出 20 40 重空
            int j = 0;
            for (j = 0; j < cond.Count(); j++)
            {
                context.Add(cond[j], dgv.Rows[0].Cells["dgvCount" + stru[cond[j]]].Value.ToString());
                rowsNumber.Add(cond[j], 1);
                samllCount.Add(cond[j] + "dgvCount小计", (dgv.Rows[0].Cells["dgvCount小计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[0].Cells["dgvCount小计"].Value.ToString())));   //自然箱数量
                samllCount.Add(cond[j] + "dgvCount进口", (dgv.Rows[0].Cells["dgvCount进口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[0].Cells["dgvCount进口"].Value.ToString())));   //进口总数TEU
                samllCount.Add(cond[j] + "dgvCount出口", (dgv.Rows[0].Cells["dgvCount出口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[0].Cells["dgvCount出口"].Value.ToString())));   //出口总数TEU
                samllCount.Add(cond[j] + "dgvCount总计", (dgv.Rows[0].Cells["dgvCount总计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[0].Cells["dgvCount总计"].Value.ToString())));   //总计TEU
                //这里是明细 进出方向  第一条记录
                foreach (string item_InOut in CommValue.BoxInOut)
                {
                    //20 40类型
                    foreach (string item_2040 in CommValue.BoxSize)
                    {
                        // 重 空
                        foreach (string item_State in CommValue.BoxState)   //列+进出+20+状态
                        {
                            InOut2040.Add(stru[cond[j]]+item_InOut + item_2040 + item_State, (dgv.Rows[0].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[0].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value.ToString())));
                        }
                    }
                }
            }
            //循环从第二条记录开始 到倒数第二条记录结束
            for (int i = 1; i < dgv.Rows.Count; i++)
            {
                //循环比较内容 不计算最后一个
                for (j = cond.Count() - 2; j >= 0; j--)
                {
                    //此列先跟上方比较
                    if (dgv.Rows[i].Cells["dgvCount" + stru[cond[j]]].Value.ToString() != context[cond[j]])
                    {
                        context[cond[j]] = dgv.Rows[i].Cells["dgvCount" + stru[cond[j]]].Value.ToString();
                        if (rowsNumber[cond[j]] > 1)
                        {
                            #region 这里是输出 小计
                            //显示小计
                            rowsNumber[cond[j]] = 1;
                            dgv.Rows.Insert(i, new DataGridViewRow());
                            //=============================================小计的样式
                            dgv.Rows[i].DefaultCellStyle.Font = new Font("宋体", 10, FontStyle.Bold);    //行文字加粗
                            //=============================================
                            dgv.Rows[i].Cells["dgvCount" + stru[cond[j]]].Value = "小计";
                            for (int columnIndex = dgv.Columns["dgvCount" + stru[cond[j]]].Index; columnIndex < dgv.Columns.Count; columnIndex++)
                            {
                                dgv.Rows[i].Cells[columnIndex].Style.BackColor = Color.Silver;
                                dgv.Rows[i].Cells["dgvCount小计"].Value = (samllCount[cond[j] + "dgvCount小计"] == 0 ? "" : samllCount[cond[j] + "dgvCount小计"].ToString());
                                dgv.Rows[i].Cells["dgvCount进口"].Value = (samllCount[cond[j] + "dgvCount进口"] == 0 ? "" : samllCount[cond[j] + "dgvCount进口"].ToString());
                                dgv.Rows[i].Cells["dgvCount出口"].Value = (samllCount[cond[j] + "dgvCount出口"] == 0 ? "" : samllCount[cond[j] + "dgvCount出口"].ToString());
                                dgv.Rows[i].Cells["dgvCount总计"].Value = (samllCount[cond[j] + "dgvCount总计"] == 0 ? "" : samllCount[cond[j] + "dgvCount总计"].ToString());
                            }
                            //显示分类20 40 进出项目
                            foreach (string item_InOut in CommValue.BoxInOut)
                            {
                                //20 40类型
                                foreach (string item_2040 in CommValue.BoxSize)
                                {
                                    // 重 空
                                    foreach (string item_State in CommValue.BoxState)
                                    {
                                        if (InOut2040[stru[cond[j]]+item_InOut + item_2040 + item_State] == 0)
                                            dgv.Rows[i].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = "";
                                        else
                                            dgv.Rows[i].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = InOut2040[stru[cond[j]]+item_InOut + item_2040 + item_State].ToString();  //这里计算各个 进出箱子数
                                    }
                                }
                            } 
                            #endregion
                            i++;
                        }

                        #region 这里是头一条记录的 记录上初值
                        //只要是不相同的内容  就记录下当前的值
                        samllCount[cond[j] + "dgvCount小计"] = (dgv.Rows[i].Cells["dgvCount小计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount小计"].Value.ToString()));   //自然箱数量
                        samllCount[cond[j] + "dgvCount进口"] = (dgv.Rows[i].Cells["dgvCount进口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount进口"].Value.ToString()));   //进口总数TEU
                        samllCount[cond[j] + "dgvCount出口"] = (dgv.Rows[i].Cells["dgvCount出口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount出口"].Value.ToString()));   //出口总数TEU
                        samllCount[cond[j] + "dgvCount总计"] = (dgv.Rows[i].Cells["dgvCount总计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount总计"].Value.ToString()));   //总计TEU
                        //显示分类20 40 进出项目
                        foreach (string item_InOut in CommValue.BoxInOut)
                        {
                            //20 40类型
                            foreach (string item_2040 in CommValue.BoxSize)
                            {
                                // 重 空
                                foreach (string item_State in CommValue.BoxState)
                                {
                                    string num = dgv.Rows[i].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value.ToString();
                                    if (num != "")
                                        InOut2040[stru[cond[j]]+item_InOut + item_2040 + item_State] = int.Parse(num);
                                    else
                                        InOut2040[stru[cond[j]]+item_InOut + item_2040 + item_State] = 0;
                                }
                            }
                        } 
                        #endregion
                    }
                    else
                    {
                        #region 这里大于一条记录的 统计数
                        //这里是相等的时候  最后一项不可能一样 这里应该设置内容为空的
                        rowsNumber[cond[j]]++;
                        //这里是相同项
                        //dgv.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        dgv.Rows[i].Cells[j].Value = "";
                        //计算小计数量
                        samllCount[cond[j] + "dgvCount小计"] += (dgv.Rows[i].Cells["dgvCount小计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount小计"].Value.ToString()));   //自然箱数量
                        samllCount[cond[j] + "dgvCount进口"] += (dgv.Rows[i].Cells["dgvCount进口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount进口"].Value.ToString()));   //进口总数TEU
                        samllCount[cond[j] + "dgvCount出口"] += (dgv.Rows[i].Cells["dgvCount出口"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount出口"].Value.ToString()));   //出口总数TEU
                        samllCount[cond[j] + "dgvCount总计"] += (dgv.Rows[i].Cells["dgvCount总计"].Value.ToString() == "" ? 0 : int.Parse(dgv.Rows[i].Cells["dgvCount总计"].Value.ToString()));   //总计TEU
                        foreach (string item_InOut in CommValue.BoxInOut)
                        {
                            //20 40类型
                            foreach (string item_2040 in CommValue.BoxSize)
                            {
                                // 重 空
                                foreach (string item_State in CommValue.BoxState)
                                {
                                    string num = dgv.Rows[i].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value.ToString();
                                    if (num != "")
                                        InOut2040[stru[cond[j]]+item_InOut + item_2040 + item_State] += int.Parse(num);    //这里计算各个 进出箱子数
                                }
                            }
                        } 
                        #endregion

                    }
                }
            }
        }


        public List<BillIndex> FindBillIndexsBySQL(string sql)
        {
            return new BillIndexService().GetRecordByGroupBy(sql);
        }


    }
}
