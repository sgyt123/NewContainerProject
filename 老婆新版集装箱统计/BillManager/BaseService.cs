using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseDAL;
using System.Reflection;
using SQLite;

namespace BillManager
{
    public class BaseService<T>
    {
        private IBase<T> baseClass;   //基础类   
        public BaseService()
        {
            baseClass=Assembly.Load("BaseDAL").CreateInstance(string.Format("BaseDAL.{0}Service", typeof(T).Name)) as IBase<T>;
        }
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int InsertRecord(T item)
        {
            return baseClass.InsertRecord(item);
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateRecord(T item)
        {
            return baseClass.UpdateRecord(item);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRecord(string id)
        {
            return baseClass.DeleteRecord(id);
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> GetRecords(string where)
        {
            return baseClass.GetRecords(where);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T GetRecord(string where)
        {
            return baseClass.GetRecord(where);
        }

        /// <summary>
        /// 建立长连接
        /// </summary>
        /// <param name="connstring"></param>
        /// <returns></returns>
        public static bool CreateConntion(string connstring)
        {
            SQLiteHelper.SQLProfileConnString = connstring;
            return SQLite.SQLiteHelper.CreateConnection();

        }
    }
}
