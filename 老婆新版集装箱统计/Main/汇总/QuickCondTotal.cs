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
    public partial class QuickCondTotal : Form
    {
        //设置单例模式
        #region 单例模式
        private static QuickCondTotal _single;

        public static QuickCondTotal CreateForm()
        {
            if (_single == null)
                _single = new QuickCondTotal();
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

        private QuickCondTotal()
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
        string[] cond = new string[0];
        private void btnCountLook_Click()
        {
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
            List<Bill> bills = new CountManager().GetGroupByTotal(idwhere + " group by " + group.Substring(0, group.Length - 1) + " order by " + group.Substring(0, group.Length - 1));   //这是拿到一个总的记录集合 分类汇总的
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
                Total countNumber = new BaseService<Total>().GetRecord(where + " and " + idwhere);
                //插入SQL到表格中
                dgvCountList.Rows[index].Cells["dgvCountSQL"].Value = where + " and " + idwhere;             //表格操作 插入条件SQL
                dgvCountList.Rows[index].Cells["dgvCountDetail"].Value = "点击详情";                          //这里需要显示 几条船记录
                //插入到表格控件里
                //这里是明细 进出方向
                //设置一个计数器
                CaleRowNumber(index, total, countNumber);

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
        private void CaleRowNumber(int index, List<Total> total, Total countnumber)
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
            //这里是艘次
            if (!string.IsNullOrEmpty(countnumber.Number))
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber"].Value = countnumber.Number;
            }
            else
            {
                dgvCountList.Rows[index].Cells["dgvCountShipNumber"].Value = "";
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
                    wheresql += item.Cells["dgvFindListID"].Value.ToString() + " ,";
                }
            }
            if (wheresql == "billIndexID in (")
            {
                wheresql = "(1=2)";
            }
            else
            {
                wheresql = wheresql.Substring(0, wheresql.Length - 2) + ")";
            }
            return wheresql;
        }

        //这里点击查看详情
        private void dgvCountList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCountList.Columns[e.ColumnIndex].Name == "dgvCountDetail" && e.RowIndex > -1)//此处索引列可以使name、也可以使headertext，看具体的设置。
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
                    input.Finds = new CountManager().FindBillIndexsBySQL(sql);
                    input.MdiParent = this.MdiParent;
                    input.WindowState = FormWindowState.Normal;
                    input.Show();
                }
            }
        }
        #endregion

        #region 功能按钮
        private string Btn_fun = "";     //代表功能
        private void btnGoodsType_Click(object sender, EventArgs e)
        {
            //1.航次  2.船公司  3.货种
            Btn_fun = "分货种";
            //cond = new string[] { "船舶名称","船公司", "大货种" };
            cond = new string[] { "船公司", "大货种" };
            btnCountLook_Click();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            //船公司
            Btn_fun = "分船公司";
            cond = new string[] { "船公司" };
            btnCountLook_Click();
        }

        private void btnAim_Click(object sender, EventArgs e)
        {
            //1.船公司  2.目的港
            Btn_fun = "分目的港";
            cond = new string[] { "船公司", "目的港" };
            btnCountLook_Click();
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            //1.船公司  2.代理
            Btn_fun = "分代理";
            cond = new string[] { "船公司", "代理" };
            btnCountLook_Click();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            //1.船公司  2.来源地
            Btn_fun = "分来源地";
            cond = new string[] { "船公司", "来源地" };
            btnCountLook_Click();
        }

        private void btnCompany2_Click(object sender, EventArgs e)
        {
            Btn_fun = "直航线船";
            cond = new string[] { "船公司", "主船驳船" };
            btnCountLook_Click();
        }

        private void btnDirction_Click(object sender, EventArgs e)
        {
            Btn_fun = "分流向";
            cond = new string[] { "船公司", "流向" };
            btnCountLook_Click();
        }

        private void btnSendPlace_Click(object sender, EventArgs e)
        {
            Btn_fun = "分发往地";
            cond = new string[] { "船公司", "发往地" };
            btnCountLook_Click();
        }
        //汇总输出
        private void ExcelOutPut_Click(object sender, EventArgs e)
        {
            switch (Btn_fun)
            {
                case "分货种":
                    new ExcelHelper().QuickCountByGoodsType(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分船公司":
                    new ExcelHelper().QuickCountByCompany(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分代理":
                    new ExcelHelper().QuickCountByProxy(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分目的港":
                    new ExcelHelper().QuickCountByAim(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分来源地":
                    new ExcelHelper().QuickCountBySource(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "直航线船":
                    new ExcelHelper().QuickCountByMain(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分流向":
                    new ExcelHelper().QuickCountByDirection(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "分发往地":
                    new ExcelHelper().QuickCountBySendPlace(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"));
                    break;
                case "货种流向分析":
                    //这里输出表格内容
                    new ExcelHelper().QuickCountByGoodsAim(dgvCountList, dtpStart.Value.ToString("yyyy年MM月dd日") + "至" + dtpEnd.Value.ToString("yyyy年MM月dd日"), goodsNames);
                    break;
                default:
                    break;
            }
        }
        #endregion


        List<string> goodsNames = new List<string>();
        /// <summary>
        /// 这是行是货种 列是港口的表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiuXiang_Click(object sender, EventArgs e)
        {
            //行是各大货种 列是目的港  流向港

            //1.现统计大货种的分类
            List<GoodsTypeUp> goodsName = new BaseService<GoodsTypeUp>().GetRecords(" 1=1 order by Code");
            goodsNames = goodsName.OrderBy(x => x.Code).Select(x => x.Name).Distinct().ToList();  //获取所有大货种的分类名称
            //2.创建dgv表格
            dgvCountList.Rows.Clear();
            dgvCountList.Columns.Clear();
            dgvCountList.RowHeadersVisible = false;
            dgvCountList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;      //设置列头不能自动高度
            dgvCountList.ColumnHeadersHeight = 30;
            dgvCountList.RowsDefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            dgvCountList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "进出口", Width = 40 });
            dgvCountList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "目的/流向", Width = 80 });
            foreach (string item in goodsNames)
            {
                dgvCountList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = item, Width = 60 });
            }
            dgvCountList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "合计(TEU)", Width = 80 });
            dgvCountList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "吞吐量", Width = 80 });
            //2.现统计下目的港
            string idwhere = CountWhereBillIndex();   //设置左侧条件
            List<Bill> inBills = new CountManager().GetGroupByTotal(idwhere + " and inout='出口' order by aim ");   //拿到所有出口的箱信息 按目的港排序 
            List<Bill> outBills = new CountManager().GetGroupByTotal(idwhere + " and inout='进口' order by direction ");   //拿到所有进口的箱信息 按流向地排序
            List<string> aims = inBills.OrderByDescending(x => x.Aim).Select(x => x.Aim).Distinct().ToList();   //目的港存入集合
            List<string> directions = outBills.OrderByDescending(x => x.Direction).Select(x => x.Direction).Distinct().ToList();   //流向港存入集合
            //先计算出口的   按目的港循环计算
            foreach (string item_aim in aims)
            {
                int index = dgvCountList.Rows.Add();
                dgvCountList.Rows[index].Cells[0].Value = "出";
                dgvCountList.Rows[index].Cells[1].Value = (item_aim == "" ? "其它" : item_aim);
                List<string> gup = inBills.OrderByDescending(x => x.Aim == item_aim).Select(x=>x.GoodsTypeUp).Distinct().ToList();
                int totalC = 0;
                double weightC = 0;
                foreach (string item_gp in gup)
                {
                    int C20 = inBills.Where(x => x.Aim == item_aim && x.GoodsTypeUp.Trim() == item_gp && x.BoxSize == "20").Count();
                    int C40 = inBills.Where(x => x.Aim == item_aim && x.GoodsTypeUp.Trim() == item_gp && x.BoxSize == "40").Count();
                    double weight = inBills.Where(x => x.Aim == item_aim && x.GoodsTypeUp.Trim() == item_gp).Sum(x => double.Parse(x.Weight));
                    totalC += C20 + C40 * 2;
                    weightC += weight;
                    int wz = goodsNames.IndexOf(item_gp);  //查找货种所在列位置  没找到就是其它
                    if (wz == -1 || item_gp=="其它")
                    {
                        wz = goodsNames.Count + 1;   //那就是其它
                        if (dgvCountList.Rows[index].Cells[wz].Value == null)
                            dgvCountList.Rows[index].Cells[wz].Value = C20 + C40 * 2;
                        else
                            dgvCountList.Rows[index].Cells[wz].Value = Int32.Parse(dgvCountList.Rows[index].Cells[wz].Value.ToString()) +C20 + C40 * 2;
                    }
                    else
                    {
                        wz += 2;   //位置加2就是列的位置
                        dgvCountList.Rows[index].Cells[wz].Value = C20 + C40 * 2;
                    }
                    //dgvCountList.Rows[index].Cells[wz].Value = C20+C40*2;
                }
                //总teu
                dgvCountList.Rows[index].Cells[goodsNames.Count + 2].Value = totalC;
                //总吨数
                dgvCountList.Rows[index].Cells[goodsNames.Count + 3].Value = weightC.ToString("F3");
            }
            //分界线
            dgvCountList.Rows.Add(new DataGridViewRow() { DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.Red } });
            //再计算进口的
            foreach (string item_directions in directions)
            {
                int index = dgvCountList.Rows.Add();
                dgvCountList.Rows[index].Cells[0].Value = "进";
                dgvCountList.Rows[index].Cells[1].Value = (item_directions == "" ? "其它" : item_directions);
                List<string> gup = inBills.OrderByDescending(x => x.Direction == item_directions).Select(x => x.GoodsTypeUp).Distinct().ToList();
                int totalC = 0;
                double weightC = 0;
                foreach (string item_gp in gup)
                {
                    int C20 = outBills.Where(x => x.Direction == item_directions && x.GoodsTypeUp == item_gp && x.BoxSize == "20").Count();
                    int C40 = outBills.Where(x => x.Direction == item_directions && x.GoodsTypeUp == item_gp && x.BoxSize == "40").Count();
                    double weight = outBills.Where(x => x.Direction == item_directions && x.GoodsTypeUp == item_gp).Sum(x => double.Parse(x.Weight));
                    totalC += C20 + C40 * 2;
                    weightC += weight;
                    int wz = goodsNames.IndexOf(item_gp);  //查找货种所在列位置  没找到就是其它
                    if (wz == -1||item_gp=="其它")
                    {
                        wz = goodsNames.Count + 1;   //那就是其它
                        if (dgvCountList.Rows[index].Cells[wz].Value == null)
                            dgvCountList.Rows[index].Cells[wz].Value = C20 + C40 * 2;
                        else
                            dgvCountList.Rows[index].Cells[wz].Value = Int32.Parse(dgvCountList.Rows[index].Cells[wz].Value.ToString()) + C20 + C40 * 2;
                    }
                    else
                    {
                        wz += 2;   //位置加2就是列的位置
                        dgvCountList.Rows[index].Cells[wz].Value = C20 + C40 * 2;
                    }
                    //dgvCountList.Rows[index].Cells[wz].Value = C20 + C40 * 2;
                }
                //总teu
                dgvCountList.Rows[index].Cells[goodsNames.Count + 2].Value = totalC;
                //总吨数
                dgvCountList.Rows[index].Cells[goodsNames.Count + 3].Value = weightC.ToString("F3");
            }
            Btn_fun = "货种流向分析";
        }

    }
}
