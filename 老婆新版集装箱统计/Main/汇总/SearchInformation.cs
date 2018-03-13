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
    public partial class SearchInfomation : Form
    {
        //设置单例模式
        #region 单例模式
        private static SearchInfomation _single;

        public static SearchInfomation CreateForm()
        {
            if (_single == null)
                _single = new SearchInfomation();
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

        private SearchInfomation()
        {
            InitializeComponent();
            Init();
        }

        #region 初始化操作
        private void Init()
        {
            Filter.Add("箱型", "BoxSize");
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
            Filter.Add("实数虚数", "Virtual");
            Filter.Add("主船驳船", "ShipType");
            new SearchManager().SearchInitDataGridView(dgvSearchList);
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
        #endregion

        #region 条件汇总
        /// <summary>
        /// 左侧条件
        /// </summary>
        /// <returns></returns>
        private string CountWhereBillIndex(string idname)
        {
            string wheresql = idname+" in (";
            //拼接选择记录的where语句
            foreach (DataGridViewRow item in dgvFindList.Rows)
            {
                if ((bool)item.Cells["dgvFindListCheck"].FormattedValue)
                {
                    wheresql += item.Cells["dgvFindListID"].Value.ToString() + ",";
                }
            }
            if (wheresql == idname+" in (")
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

        }
        #endregion

        #region 功能按钮
        //查询功能开始
        private void btnGoodsType_Click(object sender, EventArgs e)
        {
            int souci = 0;
            dgvSearchList.Rows.Clear();
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //查询  1.根据上面的集合 先结算进口的
                string inwhere = CountWhereBillIndex("ID") + " and (inout='" + item_InOut + "')";
                List<BillIndex> billsIndex = new BaseService<BillIndex>().GetRecords(inwhere);
                //2.循环进出口的船只 
                foreach (BillIndex item in billsIndex)
                {
                    List<Total> totals = new BaseService<Total>().GetRecords(" billIndexID=" + item.ID);
                    //插入记录
                    InsertDataGridView(dgvSearchList, totals, item.Title);
                }
                //进出口总计
                List<Total> samlltotal = new BaseService<Total>().GetRecords(CountWhereBillIndex("billIndexID") + " and (inout='" + item_InOut + "')");
                //插入记录
                InsertDataGridView(dgvSearchList, samlltotal, item_InOut+":" + billsIndex.Count.ToString() + "艘");
                souci += billsIndex.Count;
            }
            //总计  循环找合计数
            Dictionary<string, int> ztotals = new Dictionary<string, int>();
            ztotals.Add("dgvCount小计", 0);
            ztotals.Add("dgvCount总计", 0);
            double w1 = 0;
            double w2 = 0;
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        ztotals.Add(item_InOut + item_2040 + item_State, 0);
                    }
                }
            }  //字典初始值
            foreach (DataGridViewRow item in dgvSearchList.Rows)
            {
                if (item.Cells["dgvCountShip"].Value.ToString().Contains("口:"))   //如果包括小计的字符
                {
                    foreach (string item_InOut in CommValue.BoxInOut)
                    {
                        //20 40类型
                        foreach (string item_2040 in CommValue.BoxSize)
                        {
                            // 重 空
                            foreach (string item_State in CommValue.BoxState)
                            {
                                string  s1=item.Cells["dgvCount"+item_InOut + item_2040 + item_State].Value.ToString();
                                ztotals[item_InOut + item_2040 + item_State] += (string.IsNullOrEmpty(s1) ? 0 : int.Parse(s1));
                            }
                        }
                    }  //数字相加
                    //总计末尾
                    string s2 = item.Cells["dgvCount小计"].Value.ToString();
                    string s3 = item.Cells["dgvCount总计"].Value.ToString();
                    string s4 = item.Cells["dgvWeight总计"].Value.ToString();
                    string s5 = item.Cells["dgvWeight小计"].Value.ToString();
                    ztotals["dgvCount小计"] += int.Parse(s2);
                    ztotals["dgvCount总计"] += int.Parse(s3);
                    w1 += double.Parse(s4);
                    w2 += double.Parse(s5);
                    //修饰
                    item.DefaultCellStyle.BackColor = Color.Silver;
                    item.DefaultCellStyle.Font = new Font("宋体", 10, FontStyle.Bold);
                }
                
            }
            //总计增加到表格中
            int index = dgvSearchList.Rows.Add();
            dgvSearchList.Rows[index].Cells["dgvCountShip"].Value = "总计:"+souci.ToString()+"艘";
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        dgvSearchList.Rows[index].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = (ztotals[item_InOut + item_2040 + item_State] == 0 ? "" : ztotals[item_InOut + item_2040 + item_State].ToString());
                    }
                }
            }
            dgvSearchList.Rows[index].Cells["dgvCount" + "小计"].Value = (ztotals["dgvCount小计"]==0?"":ztotals["dgvCount小计"].ToString());
            dgvSearchList.Rows[index].Cells["dgvCount" + "总计"].Value = (ztotals["dgvCount总计"] == 0 ? "" : ztotals["dgvCount总计"].ToString());
            dgvSearchList.Rows[index].Cells["dgvWeight" + "总计"].Value = w1.ToString();
            dgvSearchList.Rows[index].Cells["dgvWeight" + "小计"].Value = w2.ToString();
            //修饰
            dgvSearchList.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
            dgvSearchList.Rows[index].DefaultCellStyle.Font = new Font("宋体", 10, FontStyle.Bold);

        }


        private void InsertDataGridView(DataGridView dgv,List<Total> totals,string title)
        {
            int index = dgv.Rows.Add();
            int samllTotal = 0;
            int teuTotal=0;
            double total1=0;
            double total2=0;
            dgv.Rows[index].Cells["dgvCountShip"].Value = title;
            //这里是明细 进出方向
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        int number=0;
                        List<Total> t=totals.Where(q=>q.InOut==item_InOut && q.BoxSize==item_2040 && q.BoxState==item_State).ToList();
                        if (t.Count > 0)
                        {
                            number = int.Parse(t[0].Number);
                            samllTotal += number;
                            if (item_2040 == "40")
                                teuTotal += number * 2;
                            else
                                teuTotal += number;
                            total1+=t[0].TotalWeight;
                            total2+=t[0].GoodsWeight;
                        }
                        dgv.Rows[index].Cells["dgvCount" + item_InOut + item_2040 + item_State].Value = (number == 0 ? "" : number.ToString()); 
                        
                    }
                }
            }
            //计算小计
            dgv.Rows[index].Cells["dgvCount" + "小计"].Value = samllTotal.ToString();
            dgv.Rows[index].Cells["dgvCount" + "总计"].Value = teuTotal.ToString();
            dgv.Rows[index].Cells["dgvWeight" + "总计"].Value = total1.ToString();
            dgv.Rows[index].Cells["dgvWeight" + "小计"].Value =total2.ToString();
            dgv.Rows[index].Cells["dgvCountDetail"].Value = "点击详情";
        }

        //汇总输出
        private void ExcelOutPut_Click(object sender, EventArgs e)
        {
            new ExcelHelper().OutPutExcel(dgvSearchList, new OutPutExcelModel() { Name="船舶查询结果", StartDay=dtpStart.Value, EndDay=dtpEnd.Value }, dgvSearchList.Columns.Count - 1);
        }

        #endregion

    }
}
