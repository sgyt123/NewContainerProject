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
    public partial class BoxSizeInfo : Form
    {
        #region 单例模式
        private static BoxSizeInfo _single;

        public static BoxSizeInfo CreateForm()
        {
            if (_single == null)
                _single = new BoxSizeInfo();
            else
                _single.Activate();
            return _single;
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion

        int index = 0;     //这是被选择的索引号
        int EditOrInsert = 0;    //0--为insert 1---为edit
        private BoxSizeInfo()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化内容
        /// </summary>
        private void Init()
        {
            dgvBaseList = new BoxSizeToControl().BoxSizeToDgv(dgvBaseList, index);
            dgvBaseList.EditMode = DataGridViewEditMode.EditProgrammatically;    //只有begin开始编辑
        }

        //插入内容
        private void btnEdit_InsertClickHandleClick(object sender, EventArgs e)
        {
            index=dgvBaseList.Rows.Add();
            dgvBaseList.Rows[index].Cells[1].Selected = true;
            for (int i = 0; i < index; i++)
            {
                dgvBaseList.Rows[i].ReadOnly = true;
            }
            for (int j = 0; j < dgvBaseList.Columns.Count; j++)     //赋值为了后面比较
            {
                dgvBaseList.Rows[index].Cells[j].Value = "";
            }
            EditOrInsert = 0;
            dgvBaseList.EditMode = DataGridViewEditMode.EditOnEnter;       //更改成任意点击就可以编辑
        }

        /// <summary>
        /// 修改内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_ChangeClickHandleClick(object sender, EventArgs e)
        {
            EditOrInsert = 1;
            //这里是修改 记住行号
            index = dgvBaseList.CurrentCell.RowIndex;   //存储当前行号
            dgvBaseList.Columns[0].ReadOnly = true;
            dgvBaseList.EditMode = DataGridViewEditMode.EditOnEnter;       //更改成任意点击就可以编辑
        }

        //保存内容
        private void btnEdit_SaveClickHandleClick(object sender, EventArgs e)
        {
            // 这里是插入方法
            if (EditOrInsert == 0)
            {
                //判断为空
                if (string.IsNullOrEmpty(dgvBaseList.Rows[index].Cells[1].Value.ToString()) || string.IsNullOrEmpty(dgvBaseList.Rows[index].Cells[2].Value.ToString()))
                {
                    lblError.Text = "箱型名称或分类没有添入内容";
                    return;                         //存在相同直接返回
                }
                //这是插入记录 行号为Index 
                for (int i = 0; i < dgvBaseList.Rows.Count-1; i++)
                {
                    if (dgvBaseList.Rows[i].Cells[1].Value.ToString().Trim() == dgvBaseList.Rows[index].Cells[1].Value.ToString())
                    {
                        dgvBaseList.Rows[i].Cells[1].Style.BackColor = Color.Red;
                        lblError.Text = "存在相同项";
                        return;                         //存在相同直接返回
                    }
                }
                
                //这里插入记录
                BoxSize bs = new BoxSize();
                bs.Name = dgvBaseList.Rows[index].Cells[1].Value.ToString();
                bs.Category = dgvBaseList.Rows[index].Cells[2].Value.ToString();
                new BaseManager<BoxSize>().InsertBoxSize(bs);
            }
            //这里是修改记录方法
            if (EditOrInsert == 1)     
            {
                //进行相同比较
                for (int i = 0; i < dgvBaseList.Rows.Count-1; i++)
                {
                    for (int j = i+1; j < dgvBaseList.Rows.Count; j++)
                    {
                        if (dgvBaseList.Rows[i].Cells[1].Value.ToString() == dgvBaseList.Rows[j].Cells[1].Value.ToString())
                        {
                            //存在相同 红色显示
                            dgvBaseList.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            dgvBaseList.Rows[j].Cells[1].Style.BackColor = Color.Red;
                            lblError.Text = "存在相同的内容";
                            return;
                        }
                    }
                }
                foreach (DataGridViewRow item in dgvBaseList.Rows)    //循环更新
                {
                    BoxSize bs = new BoxSize();
                    bs.ID = item.Cells[0].Value.ToString();
                    bs.Name = item.Cells[1].Value.ToString();
                    bs.Category = item.Cells[2].Value.ToString();
                    new BaseManager<BoxSize>().UpdateBoxSize(bs);
                }

            }
            btnEdit.isTrue = true;
            lblError.Text = "";
            Init();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_CancelClickHandleClick(object sender, EventArgs e)
        {
            lblError.Text = "";
            Init();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_DeleteClickHandleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvBaseList.SelectedRows)
            {
                if (MessageBox.Show("您是否真的要删除标识[" + item.Cells[0].Value.ToString() + "]的记录?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new BaseManager<BoxSize>().DeleteBoxSize(item.Cells[0].Value.ToString());
                }
            }
            lblError.Text = "";
            Init();
        }

        #region 校验与查询
        private void btnCheck_Click(object sender, EventArgs e)
        {
            new BoxSizeToControl().BoxSizeCheck(dgvShipInfo);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //首先是where 左侧选择ID列表 
            string where = "10000,";
            foreach (DataGridViewRow item in dgvBaseList.SelectedRows)
            {
                where += item.Cells["dgvBaseListID"].Value.ToString() + ",";
            }
            new BoxSizeToControl().BoxSizeSearch(dgvShipInfo, where.Substring(0, where.Length - 1));
        }
        /// <summary>
        /// 查询 校验或查询的结果列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            List<BillIndex> bi = new List<BillIndex>();
            foreach (DataGridViewRow item in dgvShipInfo.SelectedRows)
            {
                BillIndex b = new BillIndex();
                b.ID = item.Cells["dgvShipListID"].Value.ToString();
                b.Title = item.Cells["dgvShipListName"].Value.ToString();
                b.Reg_Date = DateTime.Parse(item.Cells["dgvShipListDate"].Value.ToString());
                bi.Add(b);
            }
            if (bi.Count > 0)
            {
                DataInput input = DataInput.CreateForm();
                //赋值
                input.Finds = bi;
                input.MdiParent = this.MdiParent;
                input.WindowState = FormWindowState.Normal;
                input.Show();
            }
        }
        #endregion
    }
}
