using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BillManager;
using ExcelManager;

namespace Main
{
    public partial class DataInput : Form
    {
        #region 字段及属性
        private List<BillIndex> finds = new List<BillIndex>();      //这里是左侧查询结果的集合
        public List<BillIndex> Finds
        {
            get { return finds; }
            set
            {
                finds = value;
                new DataInputManager().FindsToDgv(dgvFindList, finds);
                lblNumber.Text = "共" + dgvFindList.Rows.Count + "条";
            }
        }

        private List<Bill> bills = new List<Bill>();             //当前表格内容

        #endregion

        //设置单例模式
        #region 单例模式
        private static DataInput _single;

        public static DataInput CreateForm()
        {
            if (_single == null)
                _single = new DataInput();
            else
                _single.Activate();
            return _single;
        }
        private void DataInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            _single = null;
        }
        #endregion


        private DataInput()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cbInout.SelectedIndex = 0;
            cbOpenInOut.SelectedIndex = 0;
            dgvDataList = new DataInputManager().InitBoxInfoDataGridView(dgvDataList);
            dgvDataList.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        #region 查询部分
        //查询按钮
        private void btnFind_Click(object sender, EventArgs e)
        {
            new DataInputManager().FindsToDgv(dgvFindList, dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), cbInout.Text);
            lblNumber.Text = "共" + dgvFindList.Rows.Count + "条";
        }
        //点击查询列表
        private void dgvFindList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string id = dgvFindList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtOpenTitle.Text = dgvFindList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtOpenDate.Text = dgvFindList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string error = "";
                string total = "";
                txtVoyage.Text = new BaseService<BillIndex>().GetRecord(" id=" + id).Voyage ;
                txtCH.Text = new BaseService<BillIndex>().GetRecord(" id=" + id).ShipNo;
                bills = new DataInputManager().GetBills(id);
                new DataInputManager().LookShipInfo(bills, dgvDataList, ref error, ref total);
                lberror.Text = error;
                lblTotal.Text = total;
                lblID.Text = id;                      //这是indexID的内容
                
            }
        }
        #endregion

        #region 导入 保存 导出数据
        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (txtOpen.Text != "" && txtOpen.Text != "点击这里选择Excel文件")
            {
                string error = "";
                string total = "";
                List<Bill> bi = new ExcelHelper().GetBills(txtOpen.Text, ref error, stru);   //放入公共集合里
                lberror.Text = error;
                if (error == "")   //导入无错误则装入dgv表格里
                {
                    new DataInputManager().LookShipInfo(bi, dgvDataList, ref error, ref total);
                    MessageBox.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblID.Text = "";
                    bills = bi;               //把当前的内容赋值给公共集合
                    lblTotal.Text = total;
                }
            }
            else
            {
                lberror.Text = "Excel文件没有选择";
            }

        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblID.Text))
            {
                //这里是选择的记录   可以更改以前的内容
                //保存标题内容
                BillIndex biUpdate = new BaseService<BillIndex>().GetRecord(" id=" + lblID.Text);  //读取索引记录
                biUpdate.Voyage = txtVoyage.Text;
                biUpdate.ShipNo = txtCH.Text;
                if (new BaseService<BillIndex>().UpdateRecord(biUpdate) == 0)
                {
                    lberror.Text = "在保存航线的时候出现异常";
                    return;
                }
                //保存详细箱内容
                lberror.Text = new DataInputManager().UpdateBill(bills, lblID.Text);
                if (lberror.Text == "")
                    MessageBox.Show("保存成功，请不要重复操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //这里是导入的记录
                //判断是否存在记录 sql = "select Count(*) from BillIndex where title='" + bi.Title + "' and date(reg_date,'localtime') = date('" + bi.Reg_Date.ToString("yyyy-MM-dd") + "','localtime')";
                BillIndex bi = new DataInputManager().GetBillIndex(" title='" + txtOpenTitle.Text + "' and date(reg_date,'localtime') = date('" + DateTime.Parse(txtOpenDate.Text).ToString("yyyy-MM-dd") + "','localtime')");
                if (!string.IsNullOrEmpty(bi.ID))
                {
                    MessageBox.Show("数据库中已经存在相同的记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        //加入数据库
                        bi = new BillIndex() { InOut = cbOpenInOut.Text, Title = txtOpenTitle.Text, Reg_Date = DateTime.Parse(txtOpenDate.Text), Voyage = txtVoyage.Text };
                        lberror.Text = new DataInputManager().InsertBill(bills, bi);
                        if (lberror.Text == "")
                            MessageBox.Show("成功保存到数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        lberror.Text = ex.Message;
                    }
                }
            }
        }
        //导出
        private void btnOutPut_Click(object sender, EventArgs e)
        {
            if (dgvDataList.Rows.Count > 0)
                new ExcelHelper().FindDataToExcel(dgvDataList, new BillIndex() { Title = txtOpenTitle.Text , ID=txtOpenDate.Text.ToString(), Voyage=txtVoyage.Text},  dgvDataList.Columns.Count - 1);
            else
                lberror.Text = "不能把空记录导出";
        }
        private Dictionary<string, int> stru;    //结构
        private void txtOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Excel2003文件|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtOpenTitle.Text = "";
                txtOpenDate.Text = "";
                txtOpen.Text = ofd.FileName;
                //自动提取表格头部信息
                string error = "";
                BillIndex bi = new ExcelHelper().GetExcelBillTopInfomation(txtOpen.Text, ref error);
                if (error != "EDI数据" && error != "手动数据" && error != "")
                {
                    lberror.Text = error;
                    return;
                }

                if (error == "手动数据" && bi.Title != "")    //能正确读出结果
                {
                    txtOpenTitle.Text = bi.Title;
                    txtOpenDate.Text = bi.Reg_Date.ToShortDateString();
                    txtVoyage.Text = bi.Voyage;
                    if (!string.IsNullOrEmpty(bi.InOut))
                        cbOpenInOut.Text = bi.InOut;
                    else
                    {
                        if (txtOpenTitle.Text.IndexOf("卸船") >= 0)
                        {
                            cbOpenInOut.Text = "进口";
                        }
                        if (txtOpenTitle.Text.IndexOf("装船") >= 0)
                        {
                            cbOpenInOut.Text = "出口";
                        }
                    }
                    //查询船舶名称
                    string shipname = bi.Title.IndexOf('/') > 0 ? bi.Title.Substring(0, bi.Title.IndexOf('/')) : bi.Title;
                    ShipInfo si = new DataInputManager().GetShipInfo(shipname);
                    if (string.IsNullOrEmpty(si.ID))
                    {
                        MessageBox.Show("请注意，本Excel数据无法确定船舶[" + shipname + "]属性。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    stru = bi.Stru;

                    btnLoad.Enabled = true;
                    
                }

                if (error == "EDI数据" && bi.Title != "")
                {
                    txtOpenTitle.Text = bi.Title;



                    btnLoad.Enabled = false;
                   
                }
            }
        }

        #endregion

        #region 编辑按钮组
        private void btnEdit_InsertClickHandleClick(object sender, EventArgs e)
        {
            ///插入状态 其它行都只读
            dgvDataList.EditMode = DataGridViewEditMode.EditOnEnter;
            int index = dgvDataList.Rows.Add();
            for (int i = 0; i < index; i++)
            {
                dgvDataList.Rows[i].ReadOnly = true;
            }
            //赋值
            dgvDataList.Rows[index].Cells[0].Value = "";
            dgvDataList.Rows[index].Cells[1].Value = (int.Parse(dgvDataList.Rows[index - 1].Cells[1].Value.ToString()) + 1).ToString();
            for (int j = 2; j < dgvDataList.Columns.Count; j++)
            {
                dgvDataList.Rows[index].Cells[j].Value = dgvDataList.Rows[index - 1].Cells[j].Value.ToString();
            }
            //定位
            dgvDataList.CurrentCell = dgvDataList.Rows[index].Cells[1];
        }

        private void btnEdit_ChangeClickHandleClick(object sender, EventArgs e)
        {
            dgvDataList.EditMode = DataGridViewEditMode.EditOnEnter;   //更改编辑状态
        }

        private void btnEdit_SaveClickHandleClick(object sender, EventArgs e)
        {
            //把当前表格内容装入bills集合里
            bills = new DataInputManager().DataGridViwToList(dgvDataList);
            dgvDataList.EditMode = DataGridViewEditMode.EditProgrammatically;
            btnEdit.isTrue = true;
        }

        private void btnEdit_CancelClickHandleClick(object sender, EventArgs e)
        {
            dgvDataList.EditMode = DataGridViewEditMode.EditProgrammatically;
            string error = "";
            string total = "";
            new DataInputManager().LookShipInfo(bills, dgvDataList, ref error, ref total);
            lberror.Text = error;
            lblTotal.Text = total;

        }
        //删除记录 并赋予最新的集合
        private void btnEdit_DeleteClickHandleClick(object sender, EventArgs e)
        {
            if (dgvDataList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("您真的要删除序号[" + dgvDataList.SelectedRows[0].Cells[1].Value.ToString() + "]的记录吗？误删除请不要进行保存。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvDataList.Rows.Remove(dgvDataList.SelectedRows[0]);
                    bills = new DataInputManager().DataGridViwToList(dgvDataList);
                }

            }
        }
        #endregion

        #region 修改状态下的编辑
        bool isEditState = false;
        private void dgvDataList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //try
            //{
            //    dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex] = new DataInputManager().CellToComboBox(dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            //}
            //catch (Exception)
            //{
            //}
            isEditState = true;
        }

        private void dgvDataList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex] = new DataInputManager().CellToTextBox(dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            //}
            //catch (Exception)
            //{
            //}
            isEditState = false;
            new DataInputManager().CheckTextBox(dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex]);
        }

        //数据发生错误
        private void dgvDataList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region 这里是右键添加内容
        private void tsmiAddBase_Click(object sender, EventArgs e)
        {

            if (selectExcelRow > 0 && selectExcelColumn > 0)
            {
                if (dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() == "")
                    return;
                MessageBox.Show("是否直接添加【" + dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() + "】到" + dgvDataList.Columns[selectExcelColumn].HeaderText + "基本库里");
                switch (dgvDataList.Columns[selectExcelColumn].HeaderText)
                {
                    case "箱型":
                        new BaseService<BoxSize>().InsertRecord(new BoxSize { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "箱状态":
                        new BaseService<BoxState>().InsertRecord(new BoxState { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "船公司":
                        new BaseService<Company>().InsertRecord(new Company { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "货种":
                        new BaseService<GoodsType>().InsertRecord(new GoodsType { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "代理":
                        new BaseService<Proxy>().InsertRecord(new Proxy { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "目的港":
                        new BaseService<Aim>().InsertRecord(new Aim { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "来源地":
                        new BaseService<Source>().InsertRecord(new Source { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "流向":
                        new BaseService<Direction>().InsertRecord(new Direction { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                    case "发往地":
                        new BaseService<SendPlace>().InsertRecord(new SendPlace { Name = dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value.ToString() });
                        break;
                }
            }
        }
        private int selectExcelRow = 0;
        private int selectExcelColumn = 0;
        private void dgvDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectExcelRow = e.RowIndex;
            selectExcelColumn = e.ColumnIndex;
        }
        #endregion


        #region 这是双击选择分类信息
        private void dgvDataList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isEditState && (e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 14 || e.ColumnIndex == 15 || e.ColumnIndex == 16))
            {
                //Point pCursor = new Point(Cursor.Position.X, Cursor.Position.Y)   //鼠标当前位置
                SelectBaseFrm sbform = new SelectBaseFrm(this, dgvDataList.Columns[e.ColumnIndex].HeaderText);
                if ((Cursor.Position.X + 187) > SystemInformation.PrimaryMonitorSize.Width)
                {
                    sbform.Left = Cursor.Position.X - 187;
                }
                else
                {
                    sbform.Left = Cursor.Position.X;      //当前位置
                }
                sbform.Top = this.MdiParent.Top + 120;
                sbform.ShowDialog();
            }
        }
        /// <summary>
        /// 回写内容
        /// </summary>
        /// <param name="content"></param>
        public void UpdateCellContent(string content)
        {
            dgvDataList.Rows[selectExcelRow].Cells[selectExcelColumn].Value = content;
            dgvDataList_CellLeave(new object(), new DataGridViewCellEventArgs(selectExcelRow, selectExcelColumn));
        }

        private void dgvDataList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion



        /// <summary>
        /// 复制头一行内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCopyFirstContext_Click(object sender, EventArgs e)
        {
            if (dgvDataList.SelectedCells.Count > 0)
            {
                if (dgvDataList.SelectedCells[dgvDataList.SelectedCells.Count - 1].Value != null)
                {
                    if (dgvDataList.SelectedCells[dgvDataList.SelectedCells.Count - 1].Value.ToString() != "")
                    {
                        string c = dgvDataList.SelectedCells[dgvDataList.SelectedCells.Count - 1].Value.ToString();
                        foreach (DataGridViewCell item in dgvDataList.SelectedCells)
                        {
                            item.Value = c;
                        }
                    }
                }
            }
        }

    }
}
