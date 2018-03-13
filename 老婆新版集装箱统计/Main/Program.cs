using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConfigManager;
using System.Data.SQLite;
using BillManager;

namespace Main
{
    static class Program
    {


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //判断数据库
            string SqlConnectionString = "Data Source=" + XmlHelper.GetA(XmlHelper.xml("Config.xml", "Configure"), "DB_Path", "value") + ";Version=3;Password=ykweiwei";
            bool isConnection = BaseService<object>.CreateConntion(SqlConnectionString);
            //判断用户
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login l = new Login();
            if (!isConnection)
                l.Texterror = "数据库没有连接";
            else
                l.Texterror = "数据库正常连接";
            Application.Run(l);
            if (l.isLogin)
            {
                //设置常用变量   20重  20空  40重  40空
                foreach (string itemSize in CommValue.BoxSize)
                {
                    foreach (string itemState in CommValue.BoxState)
                    {
                        CommValue.BoxSpec.Add(itemSize + itemState, 0);
                    }
                }

                SQLiteFunction.RegisterFunction(typeof(SQLiteCollation_PinYin));    // 注入  
                Application.Run(new frmMain());
            }
        }
        // 中文拼音比较规则
        [SQLiteFunction(FuncType = FunctionType.Collation, Name = "PinYin")]
        class SQLiteCollation_PinYin : SQLiteFunction
        {
            public override int Compare(string x, string y)
            {
                return string.Compare(x, y);
            }
        }
    }
}
