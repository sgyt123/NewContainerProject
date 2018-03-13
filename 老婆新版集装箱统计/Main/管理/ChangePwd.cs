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
    public partial class ChangePwd : Form
    {
        #region 单例模式
        private static ChangePwd _single;

        public static ChangePwd CreateForm()
        {
            if (_single == null)
                _single = new ChangePwd();
            else
                _single.Activate();
            return _single;
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion

        private ChangePwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckPassWord() != "")
                lblError.Text = CheckPassWord();
            else
            {
                User.CurrUser.LoginPwd = pass2.Text_My;
                if (new BaseService<User>().UpdateRecord(User.CurrUser) > 0)
                    lblError.Text = "密码成功修改";
                else
                    lblError.Text = "修改密码异常";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String CheckPassWord()
        {
            if (pass1.Text_My != User.CurrUser.LoginPwd)
                return "原始密码不正确!";
            if (pass2.Text_My.Length < 4 || pass3.Text_My.Length < 4)
                return "设置新密码长度必须大于4位";
            if (pass2.Text_My != pass3.Text_My)
                return "两次新密码不一致";
            return "";
        }
    }
}
