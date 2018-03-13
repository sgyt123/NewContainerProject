using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConfigManager;
using BillManager;

namespace Main
{
    public partial class DB_Path : Form
    {
        string path=System.Environment.CurrentDirectory+@"\";

        public DB_Path()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQLite数据库|*.db";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPathUrl.Text = ofd.FileName;
            }
        }

        private void DB_Path_Load(object sender, EventArgs e)
        {
            txtPathUrl.Text = XmlHelper.GetA(XmlHelper.xml("Config.xml", "Configure"), "DB_Path", "value");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPathUrl.Text.Trim() != "")
            {
                XmlHelper.SetA(Application.StartupPath + @"\Config.xml", XmlHelper.xml("Config.xml", "Configure"), "DB_Path", "value", txtPathUrl.Text);
                string SqlConnectionString = "Data Source=" + XmlHelper.GetA(XmlHelper.xml("Config.xml", "Configure"), "DB_Path", "value") + ";Version=3;Password=ykweiwei";
                bool isConnection = BaseService<object>.CreateConntion(SqlConnectionString);
                this.Close();
            }
        }
    }
}
