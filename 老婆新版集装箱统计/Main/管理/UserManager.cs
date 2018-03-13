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
    public partial class UserManager : Form
    {
        #region 单例模式
        private static UserManager _single;

        public static UserManager CreateForm()
        {
            if (_single == null)
                _single = new UserManager();
            else
                _single.Activate();
            return _single;
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion

        public UserManager()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            List<User> users = new BaseService<User>().GetRecords(" UserLogin<>'" + User.CurrUser.LoginUser + "'");
            dgvUserList.Rows.Clear();
            foreach (User item in users)
            {
                int index = dgvUserList.Rows.Add();
                dgvUserList.Rows[index].Cells["dgvUserListID"].Value = item.ID;
                dgvUserList.Rows[index].Cells["dgvUserListName"].Value = item.Name;
                dgvUserList.Rows[index].Cells["dgvUserListLoginUser"].Value = item.LoginUser;
                dgvUserList.Rows[index].Cells["dgvUserListLoginPwd"].Value = item.LoginPwd;
                dgvUserList.Rows[index].Cells["dgvUserListPass"].Value = "*******";
            }
        }
        #region 编辑增删改
        private void btnEdit_InsertClickHandleClick(object sender, EventArgs e)
        {
            dgvUserList.Enabled = false;
            txtUser.Text_My = "";
            txtLoginUser.Text_My = "";
            txtLoginPwd.Text_My = "";
            lblID.Text = "";
            lblError.Text = "";
        }

        private void btnEdit_ChangeClickHandleClick(object sender, EventArgs e)
        {
            dgvUserList.Enabled = false;
            if (lblID.Text == "")
                lblError.Text = "没有选择要修改的记录";
        }

        private void btnEdit_SaveClickHandleClick(object sender, EventArgs e)
        {
            string result = CheckText();
            if (result != "")
            {
                lblError.Text = result;
                return;
            }
            if (lblID.Text == "")
            {
                if (!string.IsNullOrEmpty(new BaseService<User>().GetRecord(" UserLogin='" + txtLoginUser.Text_My + "'").ID))
                {
                    lblError.Text = "登录用户名存在相同记录";
                    return;

                }//增加用户 先判断是否存在登录相同用户
                User u = new User();
                u.Name = txtUser.Text_My;
                u.LoginUser = txtLoginUser.Text_My;
                u.LoginPwd = txtLoginPwd.Text_My;
                new BaseService<User>().InsertRecord(u);

            }
            else
            {
                //修改用户

                User u = new User();
                u.ID = lblID.Text;
                u.Name = txtUser.Text_My;
                u.LoginUser = txtLoginUser.Text_My;
                u.LoginPwd = txtLoginPwd.Text_My;
                new BaseService<User>().UpdateRecord(u);

            }
            dgvUserList.Enabled = true;
            btnEdit.isTrue = true;
            Init();
        }

        private void btnEdit_CancelClickHandleClick(object sender, EventArgs e)
        {
            dgvUserList.Enabled = true;
        }

        private void btnEdit_DeleteClickHandleClick(object sender, EventArgs e)
        {
            if (lblID.Text == "")
                lblError.Text = "没有选择要修改的记录";
            else
            {
                if (MessageBox.Show("您是否真的要删除此用户记录?", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    new BaseService<User>().DeleteRecord(lblID.Text);
                    lblID.Text = "";
                    lblError.Text = "";
                    Init();
                }
            }

        }
        /// <summary>
        /// 检查合法性
        /// </summary>
        /// <returns></returns>
        private string CheckText()
        {
            if (txtUser.Text_My.Trim() == "")
                return "用户名不能为空!";
            if (txtLoginUser.Text_My.Trim() == "" || txtLoginPwd.Text_My.Trim() == "")
                return "登录名或密码不能为空!";
            if (txtLoginPwd.Text_My.Length < 4)
                return "密码长度大于4位";
            if (txtLoginUser.Text_My.Length < 4)
                return "登录用户长度大于4位";

            return "";
        }
        #endregion
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                lblID.Text = dgvUserList.Rows[e.RowIndex].Cells["dgvUserListID"].Value.ToString();
                txtUser.Text_My = dgvUserList.Rows[e.RowIndex].Cells["dgvUserListName"].Value.ToString();
                txtLoginUser.Text_My = dgvUserList.Rows[e.RowIndex].Cells["dgvUserListLoginUser"].Value.ToString();
                txtLoginPwd.Text_My = dgvUserList.Rows[e.RowIndex].Cells["dgvUserListLoginPwd"].Value.ToString();
            }
        }
    }
}
