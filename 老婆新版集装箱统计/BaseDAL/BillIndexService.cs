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
    public class BillIndexService:IBase<BillIndex>
    {
        public int InsertRecord(BillIndex item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text,"Insert into BillIndex (title,reg_date,inout,voyage,shipno)values('"+item.Title+"','"+item.Reg_Date.ToString("yyyy-MM-dd")+"','"+item.InOut+"','"+item.Voyage+"','"+item.ShipNo+"')");
        }

        public int UpdateRecord(BillIndex item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "Update billIndex set title='" + item.Title + "',reg_date='" + item.Reg_Date.ToString("yyyy-MM-dd") + "',inout='" + item.InOut + "',voyage='" + item.Voyage + "',shipNo='"+item.ShipNo+"' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from billIndex where id="+id);
        }

        public List<BillIndex> GetRecords(string where)
        {
            List<BillIndex> bills = new List<BillIndex>();
            using(SQLiteDataReader sdr=SQLiteHelper.ExecuteReader(CommandType.Text,"select * from billIndex where "+where))
            {
                if (sdr == null)
                    return bills;
                while (sdr.Read())
                {
                    BillIndex bi = new BillIndex();
                    bi.ID = sdr["id"].ToString();
                    bi.InOut = sdr["inout"].ToString();
                    bi.Reg_Date = DateTime.Parse(string.IsNullOrEmpty(sdr["reg_date"].ToString())? "1900-01-01" : sdr["reg_date"].ToString());
                    bi.Title = sdr["title"].ToString();
                    bi.Voyage = sdr["voyage"].ToString();
                    bi.ShipNo = sdr["ShipNo"].ToString();
                    bills.Add(bi);
                }
            }
            return bills;
        }

        public BillIndex GetRecord(string where)
        {
            BillIndex bi = new BillIndex();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from billIndex where " + where))
            {
                if (sdr == null)
                    return bi;
                while (sdr.Read())
                {
                    
                    bi.ID = sdr["id"].ToString();
                    bi.InOut = sdr["inout"].ToString();
                    bi.Reg_Date = DateTime.Parse(string.IsNullOrEmpty(sdr["reg_date"].ToString()) ? "1900-01-01" : sdr["reg_date"].ToString());
                    bi.Title = sdr["title"].ToString();
                    bi.Voyage = sdr["voyage"].ToString();
                    bi.ShipNo = sdr["shipNo"].ToString();
                    
                }
            }
            return bi;
        }

        public List<BillIndex> GetRecordByGroupBy(string sql)
        {
            List<BillIndex> bills = new List<BillIndex>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select billIndexID from bills where " + sql + " group by billIndexID"))
            {
                if (sdr == null)
                    return bills;
                while(sdr.Read())
                {
                    string id = sdr["billIndexID"].ToString();
                    BillIndex bi = GetRecord(" id="+id);
                    bills.Add(bi);
                }
                return bills;
            }
        }
    }
}
