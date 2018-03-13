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
    public class BillService:IBase<Bill>
    {
        public int InsertRecord(Bill item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text,@"insert into bill 
               (sequence,boxNo,sealNo,weight,boxSize,
                 boxState,company,aim,goodstype,workplace,
                 proxy,shipName,waybillNo,source,billIndexID,
                 direction,sendplace,shipInfo)values("
                +item.Sequence+",'"+item.BoxNo+"','"+item.SealNo+"',"
                +item.Weight+","+item.BoxSize+","
                +item.BoxState+","+item.Company+","+item.Aim+","
                +item.GoodsType+","+item.WorkPlace+","
                +item.Proxy+",'"+item.ShipName+"','"
                +item.WayBillNo+"',"+item.Source+","
                +item.BillIndexID+","+item.Direction+","
                +item.SendPlace+","+item.ShipName+")");
        }

        public int UpdateRecord(Bill item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, @"update bill set 
                sequence=" + item.Sequence + ",boxNo='" + item.BoxNo + "',sealNo='"
                           + item.SealNo + "',weight=" + item.Weight + ",boxSize="
                           + item.BoxSize + ",boxState=" + item.BoxState + ",company="
                           + item.Company + ",aim=" + item.Aim + ",goodstype="
                           + item.GoodsType + ",workplace=" + item.WorkPlace + ",proxy="
                           + item.Proxy + ",shipName='" + item.ShipName + "',waybillNo='"
                           + item.WayBillNo + "',source=" + item.Source + ",billIndexID="
                           + item.BillIndexID + ",direction=" + item.Direction + ",sendplace="
                           + item.SendPlace + ",shipInfo=" + item.ShipName + " where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from bill where id="+id);
        }

        public List<Bill> GetRecords(string where)
        {
            List<Bill> bills = new List<Bill>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, @"select i.inout,c.name as company,
       t.name as boxstate,s.name as boxsize,
       g.name as goodstype,u.name as goodstype2,
       p.name as proxy,h.name as shipinfo,
       h.type as shiptype,r.name as aim,
       r1.name as direction,r2.name as source,
       r3.name as sendplace,w.name as workplace,
       b.id,b.sequence,b.boxNo,b.sealNo,b.weight,b.waybillNo,b.virtual,b.billIndexID,b.shipName,b.demo
       from bill b
left join billindex i on b.billindexid=i.id 
left join boxsize s on s.id=b.boxsize 
left join boxstate t on t.id=b.boxstate 
left join company c on c.id=b.company
left join goodstype g on g.id=b.goodstype
left join goodstypeup u on g.upCode=u.code
left join proxy p on p.id=b.proxy
left join shipinfo h on h.id=b.shipinfo
left join source r on r.id=b.aim
left join source r1 on r1.id=b.direction
left join source r2 on r2.id=b.source
left join source r3 on r3.id=b.sendplace
left join workplace w on w.id=b.workplace where " + where))
            {
                if (sdr == null)
                    return bills;
                while(sdr.Read())
                {
                    Bill b = new Bill();
                    b.ID = sdr["id"].ToString();
                    b.Aim = sdr["aim"].ToString();
                    b.BillIndexID = sdr["billIndexID"].ToString();
                    b.BoxNo = sdr["boxNo"].ToString();
                    b.BoxSize = sdr["boxSize"].ToString();
                    b.BoxState = sdr["boxState"].ToString();
                    b.Company = sdr["Company"].ToString();
                    b.Direction = sdr["Direction"].ToString();
                    b.GoodsType = sdr["GoodsType"].ToString();
                    b.Proxy = sdr["proxy"].ToString();
                    b.SealNo = sdr["SealNo"].ToString();
                    b.SendPlace = sdr["SendPlace"].ToString();
                    b.Sequence = sdr["Sequence"].ToString();
                    b.ShipInfo = sdr["shipInfo"].ToString();
                    b.ShipName = sdr["shipName"].ToString();   //船舶 航次
                    b.Source = sdr["Source"].ToString();
                    b.WayBillNo = sdr["WayBIllNo"].ToString();
                    b.Weight = sdr["Weight"].ToString();
                    b.WorkPlace = sdr["WorkPlace"].ToString();
                    b.Demo = sdr["Demo"].ToString();
                    bills.Add(b);
                }
                return bills;
            }
        }

        public Bill GetRecord(string where)
        {
            Bill b = new Bill();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, @"select i.inout,c.name as company,
       t.name as boxstate,s.name as boxsize,
       g.name as goodstype,u.name as goodstype2,
       p.name as proxy,h.name as shipinfo,
       h.type as shiptype,r.name as aim,
       r1.name as direction,r2.name as source,
       r3.name as sendplace,w.name as workplace,
       b.id,b.sequence,b.boxNo,b.sealNo,b.weight,b.waybillNo,b.virtual,b.billIndexID,b.shipName,b.demo
       from bill b
left join billindex i on b.billindexid=i.id 
left join boxsize s on s.id=b.boxsize 
left join boxstate t on t.id=b.boxstate 
left join company c on c.id=b.company
left join goodstype g on g.id=b.goodstype
left join goodstypeup u on g.upCode=u.code
left join proxy p on p.id=b.proxy
left join shipinfo h on h.id=b.shipinfo
left join source r on r.id=b.aim
left join source r1 on r1.id=b.direction
left join source r2 on r2.id=b.source
left join source r3 on r3.id=b.sendplace
left join workplace w on w.id=b.workplace where " + where))
            {
                if (sdr == null)
                    return b;
                if (sdr.Read())
                {
                    b.ID = sdr["id"].ToString();
                    b.Aim = sdr["aim"].ToString();
                    b.BillIndexID = sdr["billIndexID"].ToString();
                    b.BoxNo = sdr["boxNo"].ToString();
                    b.BoxSize = sdr["boxSize"].ToString();
                    b.BoxState = sdr["boxState"].ToString();
                    b.Company = sdr["Company"].ToString();
                    b.Direction = sdr["Direction"].ToString();
                    b.GoodsType = sdr["GoodsType"].ToString();
                    b.Proxy = sdr["proxy"].ToString();
                    b.SealNo = sdr["SealNo"].ToString();
                    b.SendPlace = sdr["SendPlace"].ToString();
                    b.Sequence = sdr["Sequence"].ToString();
                    b.ShipInfo = sdr["shipInfo"].ToString();
                    b.ShipName = sdr["shipName"].ToString();
                    b.Source = sdr["Source"].ToString();
                    b.WayBillNo = sdr["WayBIllNo"].ToString();
                    b.Weight = sdr["Weight"].ToString();
                    b.WorkPlace = sdr["WorkPlace"].ToString();
                    b.Demo=sdr["Demo"].ToString();
                    
                }
                return b;
            }
        }
        /// <summary>
        /// 获取Group by记录集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Bill> GetGroupByContent(string where)
        {
            List<Bill> bills = new List<Bill>();
            using(SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text,"select * from bills where "+where))
            {
                if (sdr == null)
                    return bills;
                while (sdr.Read())
                {
                    Bill b = new Bill();
                    b.ID = sdr["id"].ToString();
                    b.Aim = sdr["aim"].ToString();
                    b.BillIndexID = sdr["billIndexID"].ToString();
                    b.BoxNo = sdr["boxNo"].ToString();
                    b.BoxSize = sdr["boxSize"].ToString();
                    b.BoxState = sdr["boxState"].ToString();
                    b.Company = sdr["Company"].ToString();
                    b.Direction = sdr["Direction"].ToString();
                    b.GoodsType = sdr["GoodsType"].ToString();
                    b.GoodsTypeUp = sdr["GoodsTypeUp"].ToString();
                    b.Proxy = sdr["proxy"].ToString();
                    b.SealNo = sdr["SealNo"].ToString();
                    b.SendPlace = sdr["SendPlace"].ToString();
                    b.Sequence = sdr["Sequence"].ToString();
                    b.ShipInfo = sdr["shipInfo"].ToString();
                    b.ShipName = sdr["shipName"].ToString();   //船舶 航次
                    b.Source = sdr["Source"].ToString();
                    b.WayBillNo = sdr["WayBIllNo"].ToString();
                    b.Weight = sdr["Weight"].ToString();
                    b.WorkPlace = sdr["WorkPlace"].ToString();
                    b.Demo = sdr["Demo"].ToString();
                    b.InOut = sdr["InOut"].ToString();
                    b.ShipType = sdr["shipType"].ToString();
                    b.Voyage = sdr["voyage"].ToString();
                    bills.Add(b);
                }
                return bills;
            }
        }
    }
}
