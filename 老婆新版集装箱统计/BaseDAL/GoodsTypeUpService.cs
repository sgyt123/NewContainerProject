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
    public class GoodsTypeUpService : IBase<GoodsTypeUp>
    {
        public int InsertRecord(GoodsTypeUp item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into GoodsTypeUp (code,name)values('" +item.Code+"','"+ item.Name + "')");
        }

        public int UpdateRecord(GoodsTypeUp item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update GoodsTypeUp set name='" + item.Name + "',code='"+ item.Code+ "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from GoodsTypeUp where id=" + id);
        }

        public List<GoodsTypeUp> GetRecords(string where)
        {
            List<GoodsTypeUp> aims = new List<GoodsTypeUp>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from GoodsTypeUp where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    GoodsTypeUp a = new GoodsTypeUp();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.Code = sdr["code"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public GoodsTypeUp GetRecord(string where)
        {
            GoodsTypeUp aims = new GoodsTypeUp();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from GoodsTypeUp where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
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
            string sql = "select b.billIndexID from bill b left join goodstype g on b.goodstype=g.id left join goodstypeup p on p.Code=g.upCode where g.id>0 and (typeof(p.id)='null' or p.id='') group by b.billIndexID";
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
            string sql = "select b.billIndexID from bill b left join goodstype g on b.goodstype=g.id left join goodstypeup p on p.Code=g.upCode where p.id in (" + where + ") group by b.billIndexID";
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
