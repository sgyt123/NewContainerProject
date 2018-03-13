using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Data;
using Model;
using System.Data.SQLite;

namespace BaseDAL
{
    public class GoodsTypeService : IBase<GoodsType>
    {
        public int InsertRecord(GoodsType item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into GoodsType (name,upCode,code)values('" + item.Name + "','" + item.UpID + "','"+item.Code+"')");
        }

        public int UpdateRecord(GoodsType item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update GoodsType set name='" + item.Name + "',code='"+item.Code+"',upCode='" + item.UpID + "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from GoodsType where id=" + id);
        }

        public List<GoodsType> GetRecords(string where)
        {
            List<GoodsType> aims = new List<GoodsType>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select g.id as id,g.name as name,t.Code as upCode,t.name as upname,g.code as code from GoodsType g left join GoodsTypeUp t on g.upCode=t.Code where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    GoodsType a = new GoodsType();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.UpID = sdr["upCode"].ToString();
                    a.UpName = sdr["upName"].ToString();
                    a.Code = sdr["code"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public GoodsType GetRecord(string where)
        {
            GoodsType aims = new GoodsType();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from GoodsType where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                    aims.UpID = sdr["upCode"].ToString();
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
            string sql = "select b.billIndexID from bill b left join goodstype g on b.goodstype=g.id  where b.goodstype>0 and (typeof(g.id)='null' or g.id='') group by b.billIndexID";
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
            string sql = "select b.billIndexID from bill b left join goodstype g on b.goodstype=g.id  where g.id in (" + where + ") group by b.billIndexID";
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
