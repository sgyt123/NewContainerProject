using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigManager;
using SQLite;
using System.Data;
using System.Data.SQLite;

namespace BaseDAL
{
    public class UserService:IBase<User>
    {

        public int InsertRecord(User item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "insert into user (UserLogin,UserPwd,UserName,Power)values('" + item.LoginUser + "','"+item.LoginPwd+"','"+item.Name+"','"+item.Power+"')");
        }

        public int UpdateRecord(User item)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "update user set UserLogin='" + item.LoginUser + "'" + ",UserPwd='" + item.LoginPwd + "',UserName='" + item.Name + "',Power='"+item.Power+"' where id=" + item.ID);
        }

        public int DeleteRecord(string id)
        {
            return SQLiteHelper.ExecuteNonQuery(CommandType.Text, "delete from user where id=" + id);
        }

        public List<User> GetRecords(string where)
        {
            List<User> users = new List<User>();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from user where " + where))
            {
                if (sdr == null)
                    return users;
                while (sdr.Read())
                {
                    User a = new User();
                    a.ID = sdr["id"].ToString();
                    a.Name = sdr["UserName"].ToString();
                    a.LoginUser = sdr["UserLogin"].ToString();
                    a.LoginPwd = sdr["UserPwd"].ToString();
                    a.Power = sdr["Power"].ToString();
                    users.Add(a);
                }
                return users;
            }
        }

        public User GetRecord(string where)
        {
            User u = new User();
            using (SQLiteDataReader sdr = SQLiteHelper.ExecuteReader(CommandType.Text, "select * from user where " + where))
            {
                if (sdr == null)
                    return u;
                if (sdr.Read())
                {
                    u.ID = sdr["id"].ToString();
                    u.Name = sdr["UserName"].ToString();
                    u.LoginUser = sdr["UserLogin"].ToString();
                    u.LoginPwd = sdr["UserPwd"].ToString();
                    u.Power = sdr["Power"].ToString();
                }
                return u;
            }
        }
    }
}
