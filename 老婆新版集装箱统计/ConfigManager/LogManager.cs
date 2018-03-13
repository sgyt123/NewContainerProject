using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConfigManager
{
   public  class LogManager
    {
       /// <summary>
       ///  查询日志文件存在性
       /// </summary>
       /// <param name="filename"></param>
       /// <returns></returns>
       public static bool FileExist(string filename)
       {
           try
           {
               if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\log"))
               {
                   Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\log");
               }
               if (!File.Exists(filename))
               {
                  StreamWriter sw= File.CreateText(filename);
                  sw.Close();
                   
               }
               return true;
           }
           catch (IOException )
           {

               return false;
           }
       }
       /// <summary>
       /// 写日志文件
       /// </summary>
       /// <param name="strline">追加文件内容</param>
       /// <returns></returns>
       public static bool WriteLog(string strline)
       {
           string filename =Directory.GetCurrentDirectory() + @"\log\" +DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString()+".txt";
           if (FileExist(filename))
           {
               FileStream fs = new FileStream(filename, FileMode.Append);
               StreamWriter sw = new StreamWriter(fs);
               sw.WriteLine(strline);
               sw.Close();
               fs.Close();
               return true;
           }
           else
           {

               return false;
           }
       
       }
       /// <summary>
       /// 删除文件
       /// </summary>
       /// <param name="filename"></param>
       /// <returns></returns>
       public static bool DeleteFile(string filename)
       {
           if (File.Exists(filename))
           {
               File.Delete(filename);
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
