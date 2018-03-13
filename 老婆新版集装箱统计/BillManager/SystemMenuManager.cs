using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace BillManager
{
    /// <summary>
    /// 系统清单管理类
    /// </summary>
    public class SystemMenuManager
    {
        public DataGridView GetRecordsToDataGridView(DataGridView dgv, int selectindex)
        {
            List<ChuanMing> cms = new BaseService<ChuanMing>().GetRecords(" 1=1");
            dgv.Rows.Clear();
            foreach (ChuanMing item in cms)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvListName"].Value = item.Name;
                dgv.Rows[index].Cells["dgvListCode"].Value = item.Code;
            }
            dgv.ClearSelection();
            if (dgv.Rows.Count > selectindex)
            {
                dgv.Rows[selectindex].Selected = true;
                dgv.CurrentCell = dgv.Rows[selectindex].Cells[0];
            }
            return dgv;
        }

        
    }
}
