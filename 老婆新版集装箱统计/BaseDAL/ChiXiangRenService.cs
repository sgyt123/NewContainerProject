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
    public class ChiXiangRenService:IBase<ChiXiangRen>
    {

        int IBase<ChiXiangRen>.InsertRecord(ChiXiangRen item)
        {
            throw new NotImplementedException();
        }

        int IBase<ChiXiangRen>.UpdateRecord(ChiXiangRen item)
        {
            throw new NotImplementedException();
        }

        int IBase<ChiXiangRen>.DeleteRecord(string id)
        {
            throw new NotImplementedException();
        }

        List<ChiXiangRen> IBase<ChiXiangRen>.GetRecords(string where)
        {
            throw new NotImplementedException();
        }

        public ChiXiangRen GetRecord(string where)
        {
            ChiXiangRen c = new ChiXiangRen();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from ChiXiangRen where " + where))
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
