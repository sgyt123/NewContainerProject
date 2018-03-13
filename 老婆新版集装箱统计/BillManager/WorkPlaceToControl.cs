using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BaseDAL;

namespace BillManager
{
    public class WorkPlaceToControl
    {
        public DataGridView WorkPlaceToDgv(DataGridView dgv, int selectindex)
        {
            List<WorkPlace> boxsizes = new BaseService<WorkPlace>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (WorkPlace item in boxsizes)
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
        /// 这是检验的方法
        /// </summary>
        /// <param name="dgv"></param>
        public void WorkPlaceCheck(DataGridView dgv)
        {
            List<BillIndex> bi = new WorkPlaceService().GetReocrdByCheck();
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
        public void WorkPlaceSearch(DataGridView dgv, string where)
        {
            List<BillIndex> bi = new WorkPlaceService().GetReocrdBySearch(where);
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
