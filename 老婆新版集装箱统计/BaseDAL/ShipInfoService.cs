using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using SQLite;
using System.Data;
using System.Data.SQLite;

namespace BaseDAL
{
    public class ShipInfoService : IBase<ShipInfo>
    {
        public int InsertRecord(ShipInfo item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into ShipInfo (name,type)values('" + item.Name + "','" + item.Type + "')");
        }

        public int UpdateRecord(ShipInfo item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update ShipInfo set name='" + item.Name + "'" + ",type='" + item.Type + "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from ShipInfo where id=" + id);
        }

        public List<ShipInfo> GetRecords(string where)
        {
            List<ShipInfo> aims = new List<ShipInfo>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from ShipInfo where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    ShipInfo a = new ShipInfo();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.Type = sdr["Type"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public ShipInfo GetRecord(string where)
        {
            ShipInfo aims = new ShipInfo();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from ShipInfo where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                    aims.Type = sdr["Type"].ToString();
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
            string sql = "select b.billIndexID from bill b left join shipinfo p on p.id=b.shipinfo where b.shipinfo>0 and (typeof(p.id)='null' or p.id='') group by b.billIndexID";
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
            string sql = "select b.billIndexID from bill b left join shipinfo p on p.id=b.shipinfo where b.shipinfo in (" + where + ") group by b.billIndexID";
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
