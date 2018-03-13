using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BaseDAL;

namespace BillManager
{
    public class GoodsTypeUpToControl
    {
        public DataGridView GoodsTypeUpToDgv(DataGridView dgv, int selectindex)
        {
            List<GoodsTypeUp> boxsizes = new BaseService<GoodsTypeUp>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (GoodsTypeUp item in boxsizes)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvBaseListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvBaseListName"].Value = item.Name;
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
        /// 获取一级货种ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetGoodsTypeUpID(string name)
        {
            string id = new BaseService<GoodsTypeUp>().GetRecord(" name='" + name + "' or code='"+name+"'" ).Code;
            return string.IsNullOrEmpty(id) ? "0" : id;
        }

        /// <summary>
        /// 这是检验的方法
        /// </summary>
        /// <param name="dgv"></param>
        public void GoodsTypeUpCheck(DataGridView dgv)
        {
            List<BillIndex> bi = new GoodsTypeUpService().GetReocrdByCheck();
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
        public void GoodsTypeUpSearch(DataGridView dgv, string where)
        {
            List<BillIndex> bi = new GoodsTypeUpService().GetReocrdBySearch(where);
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
