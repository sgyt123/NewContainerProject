using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BaseDAL;

namespace BillManager
{
    public class BoxSizeToControl
    {
        /// <summary>
        /// 把BoxSize表内容装入DataGridView里面
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="selectindex"></param>
        /// <returns></returns>
        public DataGridView BoxSizeToDgv(DataGridView dgv,int selectindex)
        {
            List<BoxSize> boxsizes = new BaseService<BoxSize>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (BoxSize item in boxsizes)
            {
               int index=dgv.Rows.Add();
               dgv.Rows[index].Cells[0].Value = item.ID;
               dgv.Rows[index].Cells[1].Value = item.Name;
               dgv.Rows[index].Cells[2].Value = item.Category;
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
        /// 这是检验的方法
        /// </summary>
        /// <param name="dgv"></param>
        public void BoxSizeCheck(DataGridView dgv)
        {
            List<BillIndex> bi = new BoxSizeService().GetReocrdByCheck();
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
        public void BoxSizeSearch(DataGridView dgv, string where)
        {
            List<BillIndex> bi = new BoxSizeService().GetReocrdBySearch(where);
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
