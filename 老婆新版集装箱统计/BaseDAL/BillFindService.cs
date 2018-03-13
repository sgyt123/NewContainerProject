using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SQLite;
using SQLite;

namespace BaseDAL
{
    public class BillFindService
    {
        /// <summary>
        /// 删除票据信息
        /// </summary>
        /// <param name="connstring"></param>
        /// <param name="billindexid"></param>
        /// <returns></returns>
        public string DeleteBill(string billindexid)
        {
            string deletebillindex = "delete from billindex where id=" + billindexid;
            string deletebill = "delete from bill where billindexid=" + billindexid;
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = SQLiteHelper.SqlConn;
            SQLiteTransaction trans = null;
            try
            {
                cmd.Connection = conn;
                trans = conn.BeginTransaction();    //开始

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = deletebillindex;
                cmd.ExecuteNonQuery();

                cmd.CommandText = deletebill;
                cmd.ExecuteNonQuery();

                trans.Commit();
                return "";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
        }
        /// <summary>
        /// 更新票据明细
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="IndexID"></param>
        /// <returns></returns>
        public string UpdateBill(List<Bill> bs,string IndexID)
        {
            BillIndex bi = new BillIndexService().GetRecord(" id=" + IndexID);   //获取票据索引记录
            string delete = "delete from bill where billindexid=" + bi.ID;
            if (string.IsNullOrEmpty(bi.ID))
                return "没有找到票据ID="+IndexID+"号的记录";
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = SQLiteHelper.SqlConn;
            SQLiteTransaction trans = null;
            try
            {
                 cmd.Connection = conn;
                trans = conn.BeginTransaction();    //开始
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = delete;
                cmd.ExecuteNonQuery();           //头一步删除旧记录

                foreach (Bill b in bs)
                {
                    string insertBill = InsertSQL(b, bi.Title, bi.ID);
                    cmd.CommandText = insertBill;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            return "";
        }

        /// <summary>
        /// 插入票据单和明细单 事务处理
        /// </summary>
        /// <param name="connstring"></param>
        /// <param name="bi"></param>
        /// <param name="bs"></param>
        /// <returns></returns>
        public string InsertBill(BillIndex bi, List<Bill> bs)
        {
            //先获取最大序号ID
            string selectNo = "select max(id) from billindex";
            int id = SQLiteHelper.ExecuteScalar(CommandType.Text, selectNo);
            bi.ID = (id + 1).ToString();
            string insertBillIndex = "insert into billindex (id,title,reg_date,inout,voyage)values('" + bi.ID + "','" + bi.Title + "','" + bi.Reg_Date.ToString("yyyy-MM-dd") + "','" + bi.InOut + "','"+bi.Voyage+"')";

            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = SQLiteHelper.SqlConn;
            SQLiteTransaction trans=null;
            //事务开始
            try
            {
                cmd.Connection = conn;
                trans = conn.BeginTransaction();    //开始

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = insertBillIndex;
                cmd.ExecuteNonQuery();
                foreach (Bill b in bs)
                {
                    string insertBill = InsertSQL(b, bi.Title,bi.ID);
                    cmd.CommandText = insertBill;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            return "";
        }
        /// <summary>
        /// 根据单据 拼写Insert代码
        /// </summary>
        /// <param name="bi"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static string InsertSQL(Bill b, string title,string id)
        {
            string boxsize = new BoxSizeService().GetRecord(" name='" + b.BoxSize + "'").ID;
            string boxstate = new BoxStateService().GetRecord(" name='" + b.BoxState + "'").ID;
            string company = new CompanyService().GetRecord(" name='" + b.Company + "'").ID;
            string aim = new SourceService().GetRecord(" name='" + b.Aim + "'").ID;
            string goods = new GoodsTypeService().GetRecord(" name='" + b.GoodsType + "'").ID;
            string workplace = new WorkPlaceService().GetRecord(" name='" + b.WorkPlace + "'").ID;
            string proxy = new ProxyService().GetRecord(" name='" + b.Proxy + "'").ID;
            string source = new SourceService().GetRecord(" name='" + b.Source + "'").ID;
            string direction = new DirectionService().GetRecord(" name='" + b.Direction + "'").ID;
            string sendplace = new SendPlaceService().GetRecord(" name='" + b.SendPlace + "'").ID;
            string ship = new ShipInfoService().GetRecord(" name='" + title.Substring(0, title.IndexOf('/')) + "'").ID;
            string insertBill = "insert into bill(sequence,boxno,sealno,weight,boxsize,boxstate,company,"
                                + "aim,goodstype,workplace,proxy,shipname,waybillno,source,billindexid,direction,sendplace,shipinfo,demo)values("
                                + b.Sequence + ",'" + b.BoxNo + "','" + b.SealNo + "'," + (string.IsNullOrEmpty(b.Weight) ? "0" : b.Weight)
                                + "," + (string.IsNullOrEmpty(boxsize) ? "0" : boxsize)
                                + "," + (string.IsNullOrEmpty(boxstate) ? "0" : boxstate)
                                + "," + (string.IsNullOrEmpty(company) ? "0" : company)
                                + "," + (string.IsNullOrEmpty(aim) ? "0" : aim)
                                + "," + (string.IsNullOrEmpty(goods) ? "0" : goods)
                                + "," + (string.IsNullOrEmpty(workplace) ? "0" : workplace)
                                + "," + (string.IsNullOrEmpty(proxy) ? "0" : proxy)
                                + ",'" + b.ShipName + "','" + b.WayBillNo + "'"
                                + "," + (string.IsNullOrEmpty(source) ? "0" : source)
                                + "," + id
                                + "," + (string.IsNullOrEmpty(direction) ? "0" : direction)
                                + "," + (string.IsNullOrEmpty(sendplace) ? "0" : sendplace)
                                + "," + (string.IsNullOrEmpty(ship) ? "0" : ship)
                                + ",'" + (string.IsNullOrEmpty(b.Demo) ? "" : b.Demo) + "')";
            return insertBill;
        }

    }
}
