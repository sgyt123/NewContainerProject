using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BillManager
{
    public class SystemMenuControl
    {
        public DataGridView InitSystemMenuDataGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;   //选择模式为整行 
            dgv.MultiSelect = true;                                       //可以多选
            dgv.RowHeadersVisible = false;                                 //隐藏头一列
            dgv.AllowUserToResizeRows = false;                             //设置行是否可以调整大小
            dgv.BackgroundColor = Color.White;                               //设置背景颜色
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;      //设置列头不能自动高度
            dgv.ColumnHeadersHeight = 30;                                  //列头部高
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DeepSkyBlue };
            dgv.GridColor = Color.Black;
            //序号 	箱号	 尺寸 箱型  持箱人  状态   船名  航次  进出口  流向    重量   目的港  卸货港  装货港  提单号   货种	 
            //dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", Width = 40, Name = "dgvExcelID", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }, Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "序号", Width = 40, Name = "dgvExcelSequence", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "箱号", Width = 90, Name = "dgvExcelBoxNo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "尺寸", Width = 40, Name = "dgvExcelSize", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "箱型", Width = 40, Name = "dgvExcelBoxSize", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "持箱人", Width = 90, Name = "dgvExcelCompany", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "状态", Width = 70, Name = "dgvExcelBoxState", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "船名", Width = 120, Name = "dgvExcelShipName", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "航次", Width = 120, Name = "dgvExcelHangChi", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "I/E", Width = 50, Name = "dgvExcelInOut", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "流向/来源", Width = 70, Name = "dgvExcelDirection", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "重量", Width = 70, Name = "dgvExcelWeight", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "目的港", Width = 90, Name = "dgvExcelAim", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "卸货港", Width = 90, Name = "dgvExcelXie", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "装货港", Width = 90, Name = "dgvExcelZhuang", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "提单号", Width = 150, Name = "dgvExcelWayBillNo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "货名", Width = 100, Name = "dgvExcelGoodsType", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            return dgv;

        }
    }
}
