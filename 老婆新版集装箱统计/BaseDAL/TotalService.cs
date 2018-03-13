using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SQLite;
using SQLite;
using System.Data;
using ConfigManager;

namespace BaseDAL
{
    public class TotalService:IBase<Total>
    {
        public int InsertRecord(Total item)
        {
            throw new NotImplementedException();
        }

        public int UpdateRecord(Total item)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 这是获取 几种箱子的数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Total> GetRecords(string where)
        {
            List<Total> ts = new List<Total>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select count(*) as Number,sum(weight) as weight,inout,boxsize,boxstate from bills where " + where + " group by inout,boxsize,boxstate"))
            {
                if (sdr == null)
                    return ts;
                while (sdr.Read())
                {
                    Total t = new Total();
                    t.Number = sdr["number"].ToString();
                    t.InOut = sdr["inout"].ToString();
                    t.BoxSize = sdr["boxsize"].ToString();
                    t.BoxState = sdr["boxstate"].ToString();
                    t.TotalWeight=double.Parse(sdr["weight"].ToString());
                    if (t.BoxState == CommValue.BoxState[1])    //如果是空
                    {
                        if (t.BoxSize == "20")
                        {
                            t.GoodsWeight = 0;
                            t.TotalWeight =int.Parse(t.Number)* CommValue.SingleCoefficient;
                        }
                        if (t.BoxSize == "40")
                        {
                            t.GoodsWeight = 0;
                            t.TotalWeight = int.Parse(t.Number)*CommValue.DoubleCoefficient;
                        }
                    }
                    else
                    {
                        if (t.BoxSize == "20")
                        {
                            t.GoodsWeight = t.TotalWeight - int.Parse(t.Number) * CommValue.SingleCoefficient;
                        }
                        if (t.BoxSize == "40")
                        {
                            t.GoodsWeight = t.TotalWeight - int.Parse(t.Number) * CommValue.DoubleCoefficient;
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
        }
        //获取条件的几条船数量
        public Total GetRecord(string where)
        {
            Total ts = new Total();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select count(*) as number from (select id from bills where " + where + " group by ShipNo)"))
            {
                if (sdr == null)
                    return ts;
                while (sdr.Read())
                {
                    ts.TBShouChi = sdr["number"].ToString();
                }
            }
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select count(*) as number from (select id from bills where " + where + " group by billIndexID)"))
            {
                if (sdr == null)
                    return ts;
                while (sdr.Read())
                {
                    ts.ZYShouChi = sdr["number"].ToString();
                }
            }
            return ts;
        }
    }
}
