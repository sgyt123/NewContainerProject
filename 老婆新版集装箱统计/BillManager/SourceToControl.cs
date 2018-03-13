using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BaseDAL;

namespace BillManager
{
    public class SourceToControl
    {
        public DataGridView SourceToDgv(DataGridView dgv, int selectindex)
        {
            List<Source> boxsizes = new BaseService<Source>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (Source item in boxsizes)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvBaseListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvBaseListName"].Value = item.Name;
                dgv.Rows[index].Cells["dgvBaseListOtherName"].Value = item.OtherName;
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
        public void SourceCheck(DataGridView dgv,string lb)
        {
            List<BillIndex> bi = new List<BillIndex>();
            switch (lb)
            {
                case "目的港":
                    bi=new AimService().GetReocrdByCheck();
                    break;
                case "来源":
                    bi = new SourceService().GetReocrdByCheck();
                    break;
                case "流向":
                    bi = new DirectionService().GetReocrdByCheck();
                    break;
                case "发往地":
                    bi = new SendPlaceService().GetReocrdByCheck();
                    break;
            }
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
        public void SourceSearch(DataGridView dgv,string lb, string where)
        {
            List<BillIndex> bi = new List<BillIndex>();
            switch (lb)
            {
                case "目的港":
                    bi = new AimService().GetReocrdBySearch(where);
                    break;
                case "来源":
                    bi = new SourceService().GetReocrdBySearch(where);
                    break;
                case "流向":
                    bi = new DirectionService().GetReocrdBySearch(where);
                    break;
                case "发往地":
                    bi = new SendPlaceService().GetReocrdBySearch(where);
                    break;
            }
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
