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
    public class DirectionService : IBase<Direction>
    {
        public int InsertRecord(Direction item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into source (name,otherName,code)values('" + item.Name + "','" + item.OtherName + "','" + item.Code + "')");
        }

        public int UpdateRecord(Direction item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update source set name='" + item.Name + "',othername='" + item.OtherName + "',code='" + item.Code + "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from source where id=" + id);
        }

        public List<Direction> GetRecords(string where)
        {
            List<Direction> aims = new List<Direction>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from source where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    Direction a = new Direction();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.Code = sdr["code"].ToString();
                    a.OtherName = sdr["othername"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public Direction GetRecord(string where)
        {
            Direction aims = new Direction();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from source where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                    aims.OtherName = sdr["othername"].ToString();
                    aims.Code = sdr["code"].ToString();
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
            string sql = "select b.billIndexID from bill b left join Source s on s.id=b.direction where b.direction>0 and (typeof(s.id)='null' or s.id='') group by b.billIndexID";
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
            string sql = "select b.billIndexID from bill b left join Source s on s.id=b.direction where b.direction in (" + where + ") group by b.billIndexID";
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
