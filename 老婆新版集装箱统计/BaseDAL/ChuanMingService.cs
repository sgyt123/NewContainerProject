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
    public class ChuanMingService:IBase<ChuanMing>
    {

        public int InsertRecord(ChuanMing item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into ChuanMing (Name,Code)values('" + item.Name + "','" + item.Code + "')");
        }

        public int UpdateRecord(ChuanMing item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update ChuanMing set name='" + item.Name + "'" + ",Code='" + item.Code + "' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from ChuanMing where id=" + id);
        }

        public List<ChuanMing> GetRecords(string where)
        {
            List<ChuanMing> cms = new List<ChuanMing>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from ChuanMing where " + where))
            {
                if (sdr == null)
                    return cms;
                while (sdr.Read())
                {
                    ChuanMing c = new ChuanMing();
                    c.ID = sdr["id"].ToString();
                    c.Name = sdr["Name"].ToString();
                    c.Code = sdr["Code"].ToString();
                    cms.Add(c);
                }
                return cms;
            }
        }

        public ChuanMing GetRecord(string where)
        {
            ChuanMing c = new ChuanMing();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from ChuanMing where " + where))
            {
                if (sdr == null)
                    return c;
                if (sdr.Read())
                {
                    c.ID = sdr["id"].ToString();
                    c.Name = sdr["Name"].ToString();
                    c.Code = sdr["code"].ToString();
                }
                return c;
            }
        }
    }
}
