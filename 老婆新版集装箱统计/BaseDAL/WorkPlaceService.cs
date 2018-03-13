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
    public  class WorkPlaceService:IBase<WorkPlace>
    {
        public int InsertRecord(WorkPlace item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into workplace (name,code)values('" + item.Name + "','"+item.Code+"')");
        }

        public int UpdateRecord(WorkPlace item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update WorkPlace set name='" + item.Name + "',code='" +item.Code+ "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from WorkPlace where id=" + id);
        }

        public List<WorkPlace> GetRecords(string where)
        {
            List<WorkPlace> aims = new List<WorkPlace>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from WorkPlace where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    WorkPlace a = new WorkPlace();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    a.Code = sdr["code"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public WorkPlace GetRecord(string where)
        {
            WorkPlace aims = new WorkPlace();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from WorkPlace where " + where))
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
            string sql = "select b.billIndexID from bill b left join workPlace s on s.id=b.workPlace where b.workPlace>0 and (typeof(s.id)='null' or s.id='') group by b.billIndexID";
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
            string sql = "select b.billIndexID from bill b left join workPlace s on s.id=b.workPlace where b.workPlace in (" + where + ") group by b.billIndexID";
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
