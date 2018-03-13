using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BaseDAL;
using System.Drawing;

namespace BillManager
{
    public class GoodsTypeToControl
    {
        public DataGridView GoodsTypeToDgv(DataGridView dgv, int selectindex)
        {
            List<GoodsType> boxsizes = new BaseService<GoodsType>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (GoodsType item in boxsizes)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvBaseListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvBaseListName"].Value = item.Name;
                dgv.Rows[index].Cells["dgvBaseListCategory"].Value = item.UpName;
                dgv.Rows[index].Cells["dgvBaseListCode"].Value = item.Code;
            }
            dgv.ClearSelection();
            if (dgv.Rows.Count > selectindex)
            {
                dgv.Rows[selectindex].Selected = true;
                dgv.CurrentCell = dgv.Rows[selectindex].Cells[0];
            }
            return dgv;

        }
        /// <summary>
        /// 这是把一级货种放到下拉列表里
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public DataGridViewCell CellToCombox(DataGridViewCell cells)
        {
            string id = new BaseService<GoodsTypeUp>().GetRecord(" name='" + cells.Value.ToString() + "'").ID;
            List<GoodsTypeUp> goods = new BaseService<GoodsTypeUp>().GetRecords(" 1=1 ");
            goods.Insert(0, new GoodsTypeUp() { ID="0", Name="--请选择--" });
            DataGridViewComboBoxCell dvcb =new DataGridViewComboBoxCell();
            dvcb.DataSource = goods;
            dvcb.ValueMember = "ID";
            dvcb.DisplayMember = "Name";
            cells = dvcb;
            cells.Value = (string.IsNullOrEmpty(id) ? "0" : id);
            return cells;
        }

        /// <summary>
        /// 这是把一级货种放到下拉列表里
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public DataGridViewCell CellToGoodsTypeUpCode(DataGridViewCell cells)
        {
            string id = new BaseService<GoodsTypeUp>().GetRecord(" name='" + cells.Value.ToString() + "'").Code;
            cells.Style.BackColor = Color.White;
            if (string.IsNullOrEmpty(id))
            {
                cells.Style.BackColor = Color.Gainsboro;
            }
            else
            {
                cells.Value = id;
            }
            return cells;
        }
        /// <summary>
        /// 这是还原分类的名称
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="nextcells"></param>
        /// <returns></returns>
        public DataGridViewCell CellToTextBox(DataGridViewCell cells)
        {
            DataGridViewTextBoxCell dgvt = new DataGridViewTextBoxCell();
            dgvt.Value = "";
            if (cells.Value != null)
            {
                if (cells.Value.ToString() != "0")
                {
                    dgvt.Value = cells.FormattedValue.ToString();
                }
            }
            cells = dgvt;
            return cells;
        }

        /// <summary>
        /// 这是还原分类的名称
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="nextcells"></param>
        /// <returns></returns>
        public DataGridViewCell CellToGoodsTypeUpName(DataGridViewCell cells)
        {
            string name = new BaseService<GoodsTypeUp>().GetRecord(" code='" + cells.Value.ToString() + "'").Name;
            cells.Style.BackColor = Color.White;
            if (string.IsNullOrEmpty(name))
            {
                cells.Style.BackColor = Color.Red;
               
            }
            else
            {
                cells.Value = name;
            }
            return cells;
        }

        /// <summary>
        /// 这是检验的方法
        /// </summary>
        /// <param name="dgv"></param>
        public void GoodsTypeCheck(DataGridView dgv)
        {
            List<BillIndex> bi = new GoodsTypeService().GetReocrdByCheck();
            dgv.Rows.Clear();
            foreach (BillIndex item in bi)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvShipListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvShipListName"].Value = item.Title;
                dgv.Rows[index].Cells["dgvShipListDate"].Value = item.Reg_Date.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 这是查询的方法
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="where"></param>
        public void GoodsTypeSearch(DataGridView dgv, string where)
        {
            List<BillIndex> bi = new GoodsTypeService().GetReocrdBySearch(where);
            dgv.Rows.Clear();
            foreach (BillIndex item in bi)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvShipListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvShipListName"].Value = item.Title;
                dgv.Rows[index].Cells["dgvShipListDate"].Value = item.Reg_Date.ToString("yyyy-MM-dd");
            }
        }
    }
}
