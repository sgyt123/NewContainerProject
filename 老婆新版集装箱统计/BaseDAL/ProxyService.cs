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
    public class ProxyService:IBase<Proxy>
    {
        public int InsertRecord(Proxy item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into proxy (code,name,othername)values('"+item.Code+"','" + item.Name + "','"+item.OtherName+"')");
        }

        public int UpdateRecord(Proxy item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update proxy set name='" + item.Name + "',othername='"+item.OtherName+"',code='"+item.Code+"' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from proxy where id=" + id);
        }

        public List<Proxy> GetRecords(string where)
        {
            List<Proxy> aims = new List<Proxy>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from proxy where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    Proxy a = new Proxy();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.OtherName = sdr["OtherName"].ToString();
                    a.Code = sdr["code"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public Proxy GetRecord(string where)
        {
            Proxy aims = new Proxy();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from proxy where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                    aims.OtherName = sdr["OtherName"].ToString();
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
            string sql="select b.billIndexID from bill b left join proxy p on p.id=b.proxy where b.proxy>0 and (typeof(p.id)='null' or p.id='') group by b.billIndexID";
            List<BillIndex> bi=new List<BillIndex>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (sdr == null)
                    return bi;
                while(sdr.Read())
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
            string sql = "select b.billIndexID from bill b left join proxy p on p.id=b.proxy where b.proxy in ("+where+") group by b.billIndexID";
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
