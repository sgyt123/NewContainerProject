using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ConfigManager;

namespace BillManager
{
    public class SearchManager
    {
        /// <summary>
        /// 初始化汇总表格
        /// </summary>
        /// <param name="stru"></param>
        /// <param name="cond"></param>
        /// <param name="dgv"></param>
        public void SearchInitDataGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;   //选择模式为整行 
            dgv.MultiSelect = true;                                       //不可以多选
            dgv.RowHeadersVisible = false;                                 //隐藏头一列
            dgv.AllowUserToResizeRows = false;                             //设置行是否可以调整大小
            dgv.BackgroundColor = Color.White;                               //设置背景颜色
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;      //设置列头不能自动高度
            dgv.ColumnHeadersHeight = 24;                                  //列头部高
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DeepSkyBlue };
            dgv.GridColor = Color.Black;
            //序号ckSequence 	箱号	 封号	重量	 箱型	状态 	船公司	目的港	货种 	作业地点	代理	 船名/航次	运单号	来源地
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "船舶清单名称", Width = 130, Name = "dgvCountShip", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            //这里是明细 进出方向
            foreach (string item_InOut in CommValue.BoxInOut)
            {
                //20 40类型
                foreach (string item_2040 in CommValue.BoxSize)
                {
                    // 重 空
                    foreach (string item_State in CommValue.BoxState)
                    {
                        dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = item_InOut + item_2040 + item_State, Width = 65, Name = "dgvCount" + item_InOut + item_2040 + item_State, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                    }
                }
            }
            //这里是行 小计 
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "小计(自然箱)", Width = 90, Name = "dgvCount" + "小计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Gray } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "总计(TEU)", Width = 70, Name = "dgvCount" + "总计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Gray } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "总吨数", Width = 70, Name = "dgvWeight" + "总计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Gray } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "货吨数", Width = 70, Name = "dgvWeight" + "小计", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.Gray } });
            dgv.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "详情", Width = 60, Name = "dgvCountDetail", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DarkCyan }, Text = "点击查询" });
        }
    }
}
