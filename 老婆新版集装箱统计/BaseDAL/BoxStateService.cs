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
    public class BoxStateService:IBase<BoxState>
    {
        public int InsertRecord(BoxState item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into boxstate (name)values('" + item.Name + "')");
        }

        public int UpdateRecord(BoxState item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update boxstate set name='" + item.Name + "'" + " where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from boxstate where id=" + id);
        }

        public List<BoxState> GetRecords(string where)
        {
            List<BoxState> aims = new List<BoxState>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from boxstate where " + where))
            {
                if (sdr == null)
                    return aims;
                while (sdr.Read())
                {
                    BoxState a = new BoxState();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["Name"].ToString();
                    aims.Add(a);
                }
                return aims;
            }
        }

        public BoxState GetRecord(string where)
        {
            BoxState aims = new BoxState();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from boxstate where " + where))
            {
                if (sdr == null)
                    return aims;
                if (sdr.Read())
                {
                    aims.ID = sdr["id"].ToString();
                    aims.Name = sdr["Name"].ToString();
                }
                return aims;
            }
        }
    }
}
