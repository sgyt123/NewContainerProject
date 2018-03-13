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

namespace Main
{
    public partial class SelectBaseFrm : Form
    {
        private DataInput input;
        private List<BaseModel> selectBase = new List<BaseModel>();
        public SelectBaseFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 调用父类传递 需要返回  lb是要显示的哪中分类
        /// </summary>
        /// <param name="di"></param>
        public SelectBaseFrm(DataInput di, string lb)
        {
            InitializeComponent();
            this.input = di;
            Init(lb);
        }

        private void Init(string lb)
        {
            List<BaseModel> bm = new List<BaseModel>();
            switch (lb)
            {
                case ("代理"):
                    List<Proxy> p = new BaseService<Proxy>().GetRecords(" 1=1");
                    foreach (Proxy item in p)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("船公司"):
                    List<Company> c = new BaseService<Company>().GetRecords(" 1=1");
                    foreach (Company item in c)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("目的港"):
                    List<Aim> a = new BaseService<Aim>().GetRecords(" 1=1");
                    foreach (Aim item in a)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("货种"):
                    List<GoodsType> g= new BaseService<GoodsType>().GetRecords(" 1=1");
                    foreach (GoodsType item in g)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("作业地点"):
                    List<WorkPlace> w = new BaseService<WorkPlace>().GetRecords(" 1=1");
                    foreach (WorkPlace item in w)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("来源地"):
                    List<Source> s = new BaseService<Source>().GetRecords(" 1=1");
                    foreach (Source item in s)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("流向"):
                    List<Direction> d = new BaseService<Direction>().GetRecords(" 1=1");
                    foreach (Direction item in d)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
                case ("发往地"):
                    List<SendPlace> e = new BaseService<SendPlace>().GetRecords(" 1=1");
                    foreach (SendPlace item in e)
                    {
                        bm.Add(new BaseModel() { Code = item.Code, Name = item.Name });
                    }
                    break;
            }
            selectBase = bm;
            lbBaseInfo.DataSource = selectBase;
            lbBaseInfo.DisplayMember = "Name";
            lbBaseInfo.ValueMember = "Code";
        }

        /// <summary>
        /// 这是在改变的情况下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lbBaseInfo.DataSource = null;
            lbBaseInfo.DataSource = selectBase.Where(b => b.Code.Contains(txtSearch.Text.Trim())).ToList();
            lbBaseInfo.DisplayMember = "Name";
            lbBaseInfo.ValueMember = "Code";
        }
        /// <summary>
        /// 回写内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbBaseInfo_DoubleClick(object sender, EventArgs e)
        {
            input.UpdateCellContent(lbBaseInfo.Text.ToString());
            this.Close();
        }
    }

    /// <summary>
    /// 临时模版类
    /// </summary>
    class BaseModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Name { get; set; }
    }
}
