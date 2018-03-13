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
    public partial class Login : Form
    {
        public bool isLogin { get; set; }     //是否登录成功
        public Login()
        {
            InitializeComponent();
            isLogin = false;
        }

        private string texterror = "";    //错误代码

        public string Texterror
        {
            get { return texterror; }
            set
            {
                texterror = value;
                this.lblError.Text = texterror;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 输入用户名校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtuser.Text.Length > 4)
                {
                    txtpwd.Focus();
                }
                else
                {
                    lblError.Text = "用户名长度不够";
                }
            }
        }

        /// <summary>
        /// 输入密码校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtpwd.Text.Length > 4)
                {
                    btnJoin_Click(new object(), new EventArgs());
                }
                else
                {
                    lblError.Text = "密码长度不够";
                }
            }
        }

        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            //进行校验
            if (txtuser.Text.Length < 4 || txtpwd.Text.Length < 4)
            {
                lblError.Text = "用户名或密码长度不够4位";
                return;
            }
            if (txtuser.Text.Contains("'") || txtpwd.Text.Contains("'"))
            {
                lblError.Text = "用户名或密码包含非法字符";
                return;
            }
            lblError.Text = "";
            string where = "UserLogin='" + txtuser.Text + "' and UserPwd='" + txtpwd.Text + "'";
            User U = new BaseService<User>().GetRecord(where);
            if (!string.IsNullOrEmpty(U.ID))   //查询到用户了
            {
                User.CurrUser = U;   //赋值成当前用户
                isLogin = true;
                this.Close();
            }
            else
            {
                lblError.Text = "用户或密码输入错误";
            }
        }

        private void llblConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB_Path dbpath = new DB_Path();
            dbpath.Show();
        }
    }
}
