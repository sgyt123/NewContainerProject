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
    public class GangService:IBase<Gang>
    {
        int IBase<Gang>.InsertRecord(Gang item)
        {
            throw new NotImplementedException();
        }

        int IBase<Gang>.UpdateRecord(Gang item)
        {
            throw new NotImplementedException();
        }

        int IBase<Gang>.DeleteRecord(string id)
        {
            throw new NotImplementedException();
        }

        List<Gang> IBase<Gang>.GetRecords(string where)
        {
            throw new NotImplementedException();
        }

        public Gang GetRecord(string where)
        {
            Gang c = new Gang();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from Gang where " + where))
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
