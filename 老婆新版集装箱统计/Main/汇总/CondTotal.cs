using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillManager;
using Model;
using ConfigManager;
using ExcelManager;

namespace Main
{
    public partial class CondTotal : Form
    {
        //设置单例模式
        #region 单例模式
        private static CondTotal _single;

        public static CondTotal CreateForm()
        {
            if (_single == null)
                _single = new CondTotal();
            else
                _single.Activate();
            return _single;
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion


        //这个汇总条件 借用BoxState类
        Dictionary<string, string> Filter = new Dictionary<string, string>();

        private CondTotal()
        {
            InitializeComponent();
            Init();
        }

        #region 初始化操作
        private void Init()
        {
            Filter.Add("箱型", "BoxSize");
            Filter.Add("箱状态", "BoxState");
            Filter.Add("船公司", "Company");
            Filter.Add("小货种", "GoodsType");
            Filter.Add("大货种", "GoodsTypeUp");
            Filter.Add("代理", "Proxy");
            Filter.Add("目的港", "Aim");
            Filter.Add("来源地", "Source");
            Filter.Add("流向", "Direction");
            Filter.Add("发往地", "SendPlace");
            Filter.Add("船舶名称", "ShipInfo");
            Filter.Add("进出港", "InOut");
            Filter.Add("备注", "Demo");
            Filter.Add("主船驳船", "ShipType");
            Filter.Add("作业地点", "WorkPlace");
            Filter.Add("航线", "Voyage");
            BindingSource bs = new BindingSource();
            bs.DataSource = Filter.Keys;
            lbFilter1.DataSource = bs;
        }
        #endregion

        #region 查询
        //查询按钮
        private void btnFind_Click(object sender, EventArgs e)
        {
            new DataInputManager().FindsToDgv(dgvFindList, dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), cbInout.Text);
            lblNumber.Text = "共" + dgvFindList.Rows.Count + "条";
            dgvFindList.Columns[2].ReadOnly = true;
            dgvFindList.Columns[3].ReadOnly = true;
        }
        //全选
        private void ckAllSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvFindList.Rows)
            {
                item.Cells["dgvFindListCheck"].Value = ckAllSelect.Checked;
            }
        }
        //这是删除
        private void LlblDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你是要删除当前所选择的数据库记录吗？", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dgvFindList.Rows)
                {
                    if ((bool)item.Cells["dgvFindListCheck"].FormattedValue)
                    {
                        lblNumber.Text = new CountManager().DeleteBills(item.Cells["dgvFindListID"].Value.ToString());
                    }
                }
                btnFind_Click(new object(), new EventArgs());
            }
        }
        #endregion

        #region 条件修改部分
        private void btnFilterInsert_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BorderStyle = BorderStyle.None;
        }

        private void btnFilterInsert_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BorderStyle = BorderStyle.Fixed3D;
        }
        //选择加入条件中
        private void lbFilter1_DoubleClick(object sender, EventArgs e)
        {
            if (lbFilter1.SelectedItems.Count <= 0)
            {
                return;
            }
            //判断是否有存在的
            foreach (string item in lbFilter2.Items)
            {
                if (item.Contains(lbFilter1.SelectedItems[0].ToString()))
                {
                    return;
                }
            }
            string name = (lbFilter2.Items.Count + 1).ToString() + "." + lbFilter1.SelectedItems[0].ToString();
            lbFilter2.Items.Add(name);
        }
        //选择除去条件
        private void lbFilter2_DoubleClick(object sender, EventArgs e)
        {
            //如果没有选择的
            if (lbFilter2.SelectedItems.Count <= 0)
                return;
            //把数值减一
            for (int i = lbFilter2.SelectedIndex + 1; i < lbFilter2.Items.Count; i++)
            {
                string temp = lbFilter2.Items[i].ToString();
                lbFilter2.Items[i] = (int.Parse(temp.Substring(0, temp.IndexOf('.'))) - 1).ToString() + "." + temp.Substring(temp.IndexOf('.') + 1);
            }
            //先除去内容
            lbFilter2.Items.Remove(lbFilter2.SelectedItems[0]);

        }
        #endregion

        #region 条件汇总
        private void btnCountLook_Click(object sender, EventArgs e)
        {
            if (lbFilter2.Items.Count <= 0)
            {
                lblFilterError.Text = "没有可汇总的选项";
                return;
            }
            string[] cond = new string[lbFilter2.Items.Count];
            Dictionary<string, int> rowNumber = new Dictionary<string, int>();
            for (int i = 0; i < lbFilter2.Items.Count; i++)
            {
                cond[i] = lbFilter2.Items[i].ToString().Substring(lbFilter2.Items[i].ToString().IndexOf('.') + 1);
                rowNumber.Add(cond[i], 0);     //行记录的数量 清0 开始
            }
            //安装汇总结构
            new CountManager().SearchInitDataGridView(Filter, cond, dgvCountList);
            //设置条件
            string idwhere = CountWhereBillIndex();
            //设置Group by 分组的字符串
            string group = "";
            for (int i = 0; i < cond.Count(); i++)
            {
                group += Filter[cond[i]] + ",";
            }
            List<Bill> bills = new CountManager().GetGroupByTotal(idwhere + " group by " + group.Substring(0, group.Length - 1) + " order by " + group.Replace("InOut", "InOut desc").Substring(0, group.Replace("InOut", "InOut desc").Length - 1));   //这是拿到一个总的记录集合 分类汇总的
            foreach (Bill item in bills)
            {

                //===========================下方是行数据==========================================
                string where = "";
                int index = dgvCountList.Rows.Add();                   //表格操作
                foreach (string item_cond in cond)
                {
                    string context = item.GetType().GetProperty(Filter[item_cond]).GetValue(item, null).ToString();
                    dgvCountList.Rows[index].Cells["dgvCount" + Filter[item_cond]].Value = context;   //表格操作 插入选择项内容
                    if (context == "")
                    {
                        where += " " + "(typeof(" + Filter[item_cond] + ")='null' or " + Filter[item_cond] + "='')" + " and";
                    }
                    else
                    {
                        where += " " + Filter[item_cond] + "='" + item.GetType().GetProperty(Filter[item_cond]).GetValue(item, null).ToString() + "' and";
                    }
                }
                where = "(" + where.Substring(0, where.Length - 3) + ")";
                //计算箱子数量  涉及的艘次
                List<Total> total = new BaseService<Total>().GetRecords(where + " and " + idwhere);
                Total countNumber = new BaseService<Total>().GetRecord(where + " and " + idwhere);    //这个是停泊艘次和作业艘次的统计
                //插入SQL到表格中
                dgvCountList.Rows[index].Cells["dgvCountSQL"].Value = where + " and " + idwhere;             //表格操作 插入条件SQL
                dgvCountList.Rows[index].Cells["dgvCountDetail"].Value = "点击详情";                          //这里需要显示 几条船记录
                double s1 = 0;    //货物重量
                double s2 = 0;    //总重量
                foreach (Total weightTotal in total)
                {
                    s1 += weightTotal.GoodsWeight;
                    s2 += weightTotal.TotalWeight;
                }
                dgvCountList.Rows[index].Cells["dgvCountTotalWeight"].Value = s2.ToString();
                dgvCountList.Rows[index].Cells["dgvCountGoodsWeight"].Value = s1.ToString();
                //插入到表格控件里
                //这里是明细 进出方向
                //设置一个计数器
                CaleRowNumber(index, total,countNumber);

                //=================行记录到此结束============================================================

            }
            //添加总计项目
            List<Total> countTotal = new BaseService<Total>().GetRecords(idwhere);
            Total countNumber2 = new BaseService<Total>().GetRecord(idwhere);
            int countIndex = dgvCountList.Rows.Add();
            //=============================================小计的样式
            dgvCountList.Rows[countIndex].DefaultCellStyle.Font = new Font("宋体", 10, FontStyle.Bold);    //行文字加粗
            dgvCountList.Rows[countIndex].DefaultCellStyle.BackColor = Color.Peru;    //行背景颜色
            //=============================================
            dgvCountList.Rows[countIndex].Cells[0].Value = "总计";                    //行标题 
            for (int i = 1; i < cond.Count(); i++)                                    //其它内容全部是""
            {
                dgvCountList.Rows[countIndex].Cells[i].Value = "";
            }
            //填充箱子数量
            CaleRowNumber(countIndex, countTotal, countNumber2);
            new CountManager().AddSmallTotal(dgvCountList, cond, Filter);
        }
        /// <summary>
        /// 计算行的箱子数量
        /// </summary>
        /// <param name="index"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private void CaleRowNumber(int index, List<Total> total,Total countnumber)
        {
            Dictionary<string, int> cale = new Dictionary<string, int>();   //行计数
            cale.Add("小计", 0);
            cale.Add("TEU", 0);
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                cale.Add(item_InOut, 0);
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        List<Total> t = total.Where(q => q.InOut == item_InOut && q.BoxSize == item_2040 && q.BoxState == item_State).ToList();
                        if (t.Count == 0)
                        {
                            dgvCountList.Rows[index].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = "";
                        }
                        else
                        {
                            dgvCountList.Rows[index].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = t[0].Number;
                            cale["小计"] += int.Parse(t[0].Number);
                            if (item_2040 == "40")
                            {
                                cale["TEU"] += int.Parse(t[0].Number) * 2;
                                cale[item_InOut] += int.Parse(t[0].Number) * 2;
                            }
                            else
                            {
                                cale["TEU"] += int.Parse(t[0].Number);
                                cale[item_InOut] += int.Parse(t[0].Number);
                            }
                        }
                    }
                }
            }
            //这里是小计
            dgvCountList.Rows[index].Cells["dgvCount小计"].Value = (cale["小计"] == 0 ? "" : cale["小计"].ToString());
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                dgvCountList.Rows[index].Cells["dgvCount" + item_InOut].Value = (cale[item_InOut] == 0 ? "" : cale[item_InOut].ToString());
            }
            dgvCountList.Rows[index].Cells["dgvCount总计"].Value = (cale["TEU"] == 0 ? "" : cale["TEU"].ToString());
            //这里是停泊艘次
            if (!string.IsNullOrEmpty(countnumber.TBShouChi))
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber"].Value = countnumber.TBShouChi;
            }
            else
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber"].Value ="";
            }
            //这里是作业艘次
            if (!string.IsNullOrEmpty(countnumber.ZYShouChi))
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber1"].Value = countnumber.ZYShouChi;
            }
            else
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber1"].Value = "";
            }
        }
        /// <summary>
        /// 左侧条件
        /// </summary>
        /// <returns></returns>
        private string CountWhereBillIndex()
        {
            string wheresql = "billIndexID in (";
            //拼接选择记录的where语句
            foreach (DataGridViewRow item in dgvFindList.Rows)
            {
                if ((bool)item.Cells["dgvFindListCheck"].FormattedValue)
                {
                    wheresql +=  item.Cells["dgvFindListID"].Value.ToString() + ",";
                }
            }
            if (wheresql == "billIndexID in (")
            {
                wheresql = "(1=2)";
            }
            else
            {
                wheresql = wheresql.Substring(0, wheresql.Length - 1) + ")";
            }
            return wheresql;
        }

        //这里点击查看详情
        private void dgvCountList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCountList.Columns[e.ColumnIndex].Name == "dgvCountDetail" && e.RowIndex>-1)//此处索引列可以使name、也可以使headertext，看具体的设置。
            {
                //判断是否为空内容的小计项目
                if (dgvCountList.Rows[e.RowIndex].Cells["dgvCountSQL"].Value == null)
                    return;
                //打开 查询窗体
                string sql = dgvCountList.Rows[e.RowIndex].Cells["dgvCountSQL"].Value.ToString();
                if (sql != "")
                {
                    DataInput input = DataInput.CreateForm();
                    //赋值
                    input.Finds= new CountManager().FindBillIndexsBySQL(sql);
                    input.MdiParent = this.MdiParent;
                    input.WindowState = FormWindowState.Normal;
                    input.Show();
                }
            }
        }
        #endregion

        #region 导出报表
        private void btnCountOutPut_Click(object sender, EventArgs e)
        {
            OutPutExcelModel opem = new OutPutExcelModel() { Name="盘锦港集装箱统计汇总表", StartDay=dtpStart.Value, EndDay=dtpEnd.Value };
            if (dgvCountList.Rows.Count > 0)
                new ExcelHelper().OutPutExcel(dgvCountList, opem,dgvCountList.Columns.Count-2);
        } 
        #endregion

    }
}
