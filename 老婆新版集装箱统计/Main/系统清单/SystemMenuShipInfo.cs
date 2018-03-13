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
    public partial class SystemMenuShipInfo : Form
    {
        #region 单例模式
        private static SystemMenuShipInfo _single;

        public static SystemMenuShipInfo CreateForm()
        {
            if (_single == null)
                _single = new SystemMenuShipInfo();
            else
                _single.Activate();
            return _single;
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion

        public SystemMenuShipInfo()
        {
            InitializeComponent();
            Init();
        }

        int rowIndex = 0;

        /// <summary>
        /// 初始化内容
        /// </summary>
        private void Init()
        {
            new SystemMenuManager().GetRecordsToDataGridView(dgvList, rowIndex);
            
        }


        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                rowIndex = e.RowIndex;
                lblID.Text = dgvList.Rows[e.RowIndex].Cells["dgvListID"].Value.ToString();
                txtCode.Text = dgvList.Rows[e.RowIndex].Cells["dgvListCode"].Value.ToString();
                txtName.Text = dgvList.Rows[e.RowIndex].Cells["dgvListName"].Value.ToString();
            }
        }

        #region 增删改查按钮操作
        private void editButtons1_InsertClickHandleClick(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtCode.Text = "";
            txtName.Text = "";
            dgvList.Enabled = false;
            ErrorInfo.Text = "";
        }

        private void editButtons1_ChangeClickHandleClick(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
            {
                ErrorInfo.Text = "没有选择一个要修改的记录！";
                editButtons1.isTrue = true;
            }
            else
            {
                ErrorInfo.Text = "";
                dgvList.Enabled = false;

            }
        }

        private void editButtons1_DeleteClickHandleClick(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
            {
                ErrorInfo.Text = "没有选择一个要删除的记录！";
                editButtons1.isTrue = true;
            }
            else
            {
                
                if (MessageBox.Show("您真的要删除记录为" + lblID.Text + "吗？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //删除操作
                    if (new BaseService<ChuanMing>().DeleteRecord(lblID.Text) > 0)
                    {
                        ErrorInfo.Text = "删除记录成功！";
                        Init();
                    }
                    else
                    {
                        ErrorInfo.Text = "删除记录发生异常！";
                    }

                    //删除后恢复显示
                }
             }
        }

        private void editButtons1_SaveClickHandleClick(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                ErrorInfo.Text = "代码内容不能为空！";
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                ErrorInfo.Text = "中文名称不能为空！";
                return;
            }
            if (lblID.Text == "")
            {
                //增加新内容
                ChuanMing c = new ChuanMing() { Code = txtCode.Text, Name = txtName.Text };
                //查询是否相同
                ChuanMing c1 = new BaseService<ChuanMing>().GetRecord(" Code='"+c.Code+"' or Name='"+c.Name+"'");
                if (string.IsNullOrEmpty(c1.ID))
                {
                    //是新的记录
                    if (new BaseService<ChuanMing>().InsertRecord(c)>0)
                    {
                        ErrorInfo.Text = "增加记录成功！";
                        rowIndex = dgvList.Rows.Count;
                        Init();

                    }else
                    {
                        ErrorInfo.Text = "增加记录出现异常！";
                        return;
                    }
                }
                else
                {
                    //有重复的记录
                    ErrorInfo.Text = "数据库中有相同的记录存在！";
                    return;
                }
            }
            else
            {
                //修改旧内容的
                ErrorInfo.Text = "建议您先删除记录，再增加记录以免发生重复记录！";

            }
            dgvList.Enabled = true;
            editButtons1.isTrue = true;
            lblID.Text = "";

        }
        private void editButtons1_CancelClickHandleClick(object sender, EventArgs e)
        {
            dgvList.Enabled = true;
            
        }
        #endregion


    }
}
