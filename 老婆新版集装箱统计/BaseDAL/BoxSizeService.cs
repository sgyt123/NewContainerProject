using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using SQLite;
using System.Data.SQLite;

namespace BaseDAL
{
    public class BoxSizeService:IBase<BoxSize>
    {
        public int InsertRecord(BoxSize item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into boxsize (name,Category)values('" + item.Name + "','"+item.Category+"')");
        }

        public int UpdateRecord(BoxSize item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update boxsize set name='" + item.Name + "'" + ",Category='"+item.Category+"' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from boxsize where id=" + id);
        }

        public List<BoxSize> GetRecords(string where)
        {
            List<BoxSize> aims = new List<BoxSize>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from boxsize where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    BoxSize a = new BoxSize();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.Category = sdr["Category"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public BoxSize GetRecord(string where)
        {
            BoxSize aims = new BoxSize();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from boxsize where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                    aims.Category = sdr["Category"].ToString();
                }
                return aims;
            }
        }

        /// <summary>
        /// 这是检查基础数据的方法
        /// </summary>
        /// <returns></returns>
        public List<BillIndex> GetReocrdByCheck()
        {
            string sql = "select b.billIndexID from bill b left join boxsize p on p.id=b.boxsize where b.boxsize>0 and (typeof(p.id)='null' or p.id='') group by b.billIndexID";
            List<BillIndex> bi = new List<BillIndex>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (sdr == null)
                    return bi;
                while (sdr.Read())
                {
                    BillIndex b = new BillIndex();
                    b.ID = sdr["billindexID"].ToString();
                    b = new BillIndexService().GetRecord(" id=" + b.ID);
                    bi.Add(b);
                }
            }
            return bi;
        }
        /// <summary>
        /// 这是查询分类船舶的方法
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<BillIndex> GetReocrdBySearch(string where)
        {
            string sql = "select b.billIndexID from bill b left join boxsize p on p.id=b.boxsize where b.boxsize in (" + where + ") group by b.billIndexID";
            List<BillIndex> bi = new List<BillIndex>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (sdr == null)
                    return bi;
                while (sdr.Read())
                {
                    BillIndex b = new BillIndex();
                    b.ID = sdr["billindexID"].ToString();
                    b = new BillIndexService().GetRecord(" id=" + b.ID);
                    bi.Add(b);
                }
            }
            return bi;
        }
    }
}
