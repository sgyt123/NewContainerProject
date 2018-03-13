using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillManager;
using ExcelManager;
using Model;

namespace Main
{
    public partial class SystemMenu : Form
    {
        //设置单例模式
        #region 单例模式
        private static SystemMenu _single;

        public static SystemMenu CreateForm()
        {
            if (_single == null)
                _single = new SystemMenu();
            else
                _single.Activate();
            return _single;
        }
        private void SystemMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion


        public SystemMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 装入基础信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemMenu_Load(object sender, EventArgs e)
        {
            dgvList=new SystemMenuControl().InitSystemMenuDataGridView(dgvList);
        }
        /// <summary>
        /// 打开系统清单 Excel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenSystemMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "全部文件|*.*|Excel 97-2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx";
            ofd.ShowDialog();
            string error = "";
            if (ofd.FileName != "")
            {
                dgvList=new SystemMenuExcelManager().GetSystemMenu(ofd.FileName, dgvList, ref error);
                lblError.Text = error;
            }
        }
        /// <summary>
        /// 校验内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvList.Rows)
            {
                string c = item.Cells["dgvExcelSize"].Value.ToString().Substring(0,2);
                item.Cells["dgvExcelBoxSize"].Value = c + item.Cells["dgvExcelBoxSize"].Value.ToString();     //箱型内容 需要+尺寸
                item.Cells["dgvExcelCompany"].Value = new BaseService<ChiXiangRen>().GetRecord(" Code='" + item.Cells["dgvExcelCompany"].Value.ToString()+ "'").Name;      //持箱人 对应ChiXiangRen
                item.Cells["dgvExcelBoxState"].Value=(item.Cells["dgvExcelBoxState"].Value.ToString().Contains("E")?"空":"重");
                item.Cells["dgvExcelInOut"].Value = (item.Cells["dgvExcelInOut"].Value.ToString() == "I" ? "进口" : "出口");
                item.Cells["dgvExcelShipName"].Value = new BaseService<ChuanMing>().GetRecord(" Code='" + item.Cells["dgvExcelShipName"].Value.ToString() + "'").Name;      //船名
                item.Cells["dgvExcelAim"].Value = new BaseService<Gang>().GetRecord(" Code='" + item.Cells["dgvExcelAim"].Value.ToString() + "'").Name;      //目的港
                item.Cells["dgvExcelXie"].Value = new BaseService<Gang>().GetRecord(" Code='" + item.Cells["dgvExcelXie"].Value.ToString() + "'").Name;      //卸货港
                item.Cells["dgvExcelZhuang"].Value = new BaseService<Gang>().GetRecord(" Code='" + item.Cells["dgvExcelZhuang"].Value.ToString() + "'").Name;      //装船港
            }
        }
        /// <summary>
        /// 到处到excel清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            new SystemMenuExcelManager().DataToExcel(dgvList);
        }
    }
}
