using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConfigManager;
using System.IO;
using Sunisoft.IrisSkin;

namespace Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SkinEngine skin = new SkinEngine();
            skin.SkinFile = Application.StartupPath+@"\MP10.ssk";
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            tsbarDate.Text ="当前时间:"+ DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            stateLbl.Text = "登录用户：" + User.CurrUser.Name;
        }

        private void tsmiBase_Click(object sender, EventArgs e)
        {
            BoxSizeInfo bsinfo = BoxSizeInfo.CreateForm();
            bsinfo.MdiParent = this;
            bsinfo.Show();
        }

        private void tsmiCompany_Click(object sender, EventArgs e)
        {
            CompanyInfo com = CompanyInfo.CreateForm();
            com.MdiParent = this;
            com.Show();
        }

        private void tsmiProxy_Click(object sender, EventArgs e)
        {
            ProxyInfo proxy = ProxyInfo.CreateForm();
            proxy.MdiParent = this;
            proxy.Show();
        }

        private void tsmiSource_Click(object sender, EventArgs e)
        {
            SourceInfo source = SourceInfo.CreateForm();
            source.MdiParent = this;
            source.Show();
        }

        private void tsmiShip_Click(object sender, EventArgs e)
        {
            ShipInfoInfo sinfo = ShipInfoInfo.CreateForm(); ;
            sinfo.MdiParent = this;
            sinfo.Show();
        }

        private void tsmiWorkPlace_Click(object sender, EventArgs e)
        {
            WorkPlaceInfo wpi = WorkPlaceInfo.CreateForm();
            wpi.MdiParent = this;
            wpi.Show();
        }

        private void tsmiGoodsType1_Click(object sender, EventArgs e)
        {
            GoodsTpye1Info goods1 = GoodsTpye1Info.CreateForm();
            goods1.MdiParent = this;
            goods1.Show();
        }

        private void tsmiGoodsType2_Click(object sender, EventArgs e)
        {
            GoodsType2Info goods2 = GoodsType2Info.CreateForm();
            goods2.MdiParent = this;
            goods2.Show();
        }

        private void tmiInput_Click(object sender, EventArgs e)
        {
            DataInput input = DataInput.CreateForm();
            input.MdiParent = this;
            input.Show();
        }

        private void tsmiCondTotal_Click(object sender, EventArgs e)
        {
            CondTotal ct = CondTotal.CreateForm();
            ct.MdiParent = this;
            ct.Show();
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiPassWord_Click(object sender, EventArgs e)
        {
            ChangePwd cp = ChangePwd.CreateForm();
            cp.MdiParent = this;
            cp.Show();
        }

        private void tsmiUser_Click(object sender, EventArgs e)
        {
            UserManager user = UserManager.CreateForm();
            user.MdiParent = this;
            user.Show();
        }

        private void tsmiQuickTotal_Click(object sender, EventArgs e)
        {
            QuickCondTotal qct = QuickCondTotal.CreateForm();
            qct.MdiParent = this;
            qct.Show();
        }

        private void tsbInput_Click(object sender, EventArgs e)
        {
            DataInput input = DataInput.CreateForm();
            input.MdiParent = this;
            input.Show();
        }

        private void tsbCount_Click(object sender, EventArgs e)
        {
            CondTotal ct = CondTotal.CreateForm();
            ct.MdiParent = this;
            ct.Show();
        }

        private void tsbQuick_Click(object sender, EventArgs e)
        {
            QuickCondTotal qct = QuickCondTotal.CreateForm();
            qct.MdiParent = this;
            qct.Show();
        }

        private void tsmiCondFind_Click(object sender, EventArgs e)
        {
            SearchInfomation sinf = SearchInfomation.CreateForm();
            sinf.MdiParent = this;
            sinf.Show();
        }

        #region 清单部分程序
        /// <summary>
        /// 清单管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSystemMenu_Click(object sender, EventArgs e)
        {
            SystemMenu smu = SystemMenu.CreateForm();
            smu.MdiParent = this;
            smu.Show();
        }

        private void tsmiSystemChuan_Click(object sender, EventArgs e)
        {
            SystemMenuShipInfo smsi = SystemMenuShipInfo.CreateForm();
            smsi.MdiParent = this;
            smsi.Show();
        }

        private void tsmiSystemChixiang_Click(object sender, EventArgs e)
        {

        }

        private void tsmiSystemGang_Click(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}
