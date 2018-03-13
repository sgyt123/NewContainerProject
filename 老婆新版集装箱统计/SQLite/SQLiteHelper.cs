using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using ConfigManager;

namespace SQLite
{
    /// <summary>
    /// AccHelper类提供很高的数据访问性能, 
    /// 使用SQLite类的通用定义.
    /// </summary>
    public class SQLiteHelper
    {

        //定义数据库连接串
        public static string SQLProfileConnString = "";
        public static SQLiteConnection SqlConn;
        /// <summary>
        /// 建立Sqlite连接
        /// </summary>
        /// <returns></returns>
        public static bool CreateConnection()
        {
            SqlConn = new SQLiteConnection(SQLProfileConnString);
            try
            {
                SqlConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("SqliteHelper(CreateConnection):" + ex.Message + "/" + DateTime.Now.ToString());
                return false;
            }
            
        }
        /// <summary>
        /// 删除Sqlite连接
        /// </summary>
        /// <returns></returns>
        public static bool CloseConnection()
        {
            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
            return true;
        }

        #region ExecuteNonQuery
        /// <summary>
        /// 使用连接字符串，执行一个SQLiteCommand命令（没有记录返回）
        /// 使用参数数组形式提供参数列表.
        /// </summary>
        /// <remarks>
        /// 使用示例:
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SQLiteParameter("@prodid", 24));   
        /// </remarks>
        /// <param name="connectionString">一个有效的SQLiteConnection连接串</param>
        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>受此命令影响的行数</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, params SQLiteParameter[] commandParameters)
        {

            SQLiteCommand command = new SQLiteCommand();
            try
            {
                command.Connection = SqlConn;
                //通过PrepareCommand方法将参数逐个加入到SQLiteCommand的参数集合中
                PrepareCommand(command, commandType, commandText, commandParameters);
                int val = command.ExecuteNonQuery();
                //清空SQLiteCommand中的参数列表
                command.Parameters.Clear();
                return val;

            }
            catch (Exception ex)
            {
                LogManager.WriteLog("SqliteHelper(ExecuteNonQuery):" +commandText+"/"+ ex.Message + "/" + DateTime.Now.ToString());
                return 0;
            }
            finally
            {
                
            }

        }

        #endregion

        #region ExecuteReader
        /// <summary>
        /// 在一个连接串上执行一个命令，返回一个SQLiteDataReader对象
        /// 使用参数数组形式提供参数列表.
        /// </summary>
        /// <remarks>
        /// 使用示例:  
        ///  SQLiteDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SQLiteParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的SQLiteConnection连接串(改了参数名称)</param>
        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>
        /// <param name="commandText">存贮过程名称或是一个T-SQLite语句串</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>一个结果集对象SQLiteDataReader</returns>

        public static SQLiteDataReader ExecuteReader(CommandType commandType, string commandText, params SQLiteParameter[] commandParameters)
        {

            SQLiteCommand command = new SQLiteCommand();
            // 如果不存在要查询的对象，则发生异常
            // 连接要关闭
            // CommandBehavior.CloseConnection在异常时不发生作用
            try
            {
                command.Connection = SqlConn;
                PrepareCommand(command, commandType, commandText, commandParameters);
                SQLiteDataReader rdr = command.ExecuteReader();
                command.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("SqliteHelper(ExecuteReader):" +commandText+"/"+ ex.Message + "/" + DateTime.Now.ToString());
                return null;
            }

        }


        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 在一个连接串上执行一个命令，返回表中第一行，第一列的值
        /// 使用提供的参数.
        /// </summary>        
        /// <remarks>
        /// 使用示例:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SQLiteParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的SQLiteConnection连接串</param>
        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>
        /// <param name="commandText">存贮过程名称或是一个T-SQLite语句串</param>
        /// <param name="commandParameters">执行命令的参数集</param>        
        /// <returns>返回的对象，在使用时记得类型转换</returns>


        public static int ExecuteScalar(CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {

            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.Connection = SqlConn;
                PrepareCommand(cmd, cmdType, cmdText, commandParameters);
                int val = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("SqliteHelper(ExecuteScalar):" + cmdText + "/" + ex.Message + "/" + DateTime.Now.ToString());
                return 0;
            }
            finally
            {
               
            }
        }

        #endregion

        #region ExecuteAdapter,ExecuteDataSet
        /// <summary>
        /// 在一个连接串上执行一个命令，返回一个SQLiteDataAdapter对象
        /// 使用参数数组形式提供参数列表.
        /// </summary>
        /// <remarks>
        /// 使用示例:  
        ///  SQLiteDataReader r = ExecuteAdapter(connString, CommandType.StoredProcedure, "PublishOrders", new SQLiteParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的SQLiteConnection连接串(改了参数名称)</param>
        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>
        /// <param name="commandText">存贮过程名称或是一个T-SQLite语句串</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>一个结果集对象SQLiteDataReader</returns>
        public static SQLiteDataAdapter ExecuteAdapter(string connectionString, CommandType commandType, string commandText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                command.Connection = connection;
                PrepareCommand(command, commandType, commandText, commandParameters);
                SQLiteDataAdapter adp = new SQLiteDataAdapter(command);
                command.Parameters.Clear();
                return adp;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        #endregion

        /// <summary>
        /// 提供一个SQLiteCommand对象的设置
        /// </summary>
        /// <param name="cmd">SQLiteCommand对象</param>
        /// <param name="conn">SQLiteConnection 对象</param>
        /// <param name="trans">SQLiteTransaction 对象</param>
        /// <param name="cmdType">CommandType 如存贮过程，T-SQLite</param>
        /// <param name="cmdText">存贮过程名或查询串</param>
        /// <param name="cmdParms">命令中用到的参数集</param>

        private static void PrepareCommand(SQLiteCommand cmd, CommandType cmdType, string cmdText, SQLiteParameter[] cmdParms)
        {

            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


    }


}
