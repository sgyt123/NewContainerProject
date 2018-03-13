using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace ConfigManager
{
     public class XmlHelper
    {
        static XmlDocument xdoc = new XmlDocument();
        /// <summary>
        /// 打开的xml配置文件节点信息
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public static XmlNode xml(string filename,string firstnode)
        {
            xdoc.Load(Application.StartupPath + @"\" + filename);
            XmlNode node = xdoc.SelectSingleNode(firstnode);
            return node;
        }
        /// <summary>
        /// 获取指定节点下所有value值
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public static string[] GetAllValue(string filename,string firstnode,string nodename)
        {
            List<string> strs = new List<string>();
            foreach (XmlNode item in xml(filename,firstnode))
            {
                if (item.Name == nodename)
                {
                    foreach (XmlNode item1 in item)
                    {
                        XmlElement xe = (XmlElement)item1;
                        if (xe.GetAttribute("value").Trim() != "")
                        {
                            strs.Add(xe.GetAttribute("value"));
                        }
                    }
                }
            }
            return strs.ToArray();
        }
        /// <summary>
        /// 返回一个xml 节点的属性值 可以多级
        /// </summary>
        /// <param name="xn">父节点</param>
        /// <param name="nodename">节点名称</param>
        /// <param name="attrib">节点属性名</param>
        /// <returns></returns>
        public static string GetA(XmlNode xn, string nodename, string attrib)
        {
            string findstring = "";
            foreach (XmlNode item in xn.ChildNodes)
            {
                if (item.ChildNodes.Count > 0)
                {
                    findstring = GetA(item, nodename, attrib);
                    if (findstring.Trim() != "")
                    {
                        return findstring;
                    }
                }
                else
                {
                    XmlElement xe = (XmlElement)item;
                    if (xe.Name == nodename)
                    {
                        return xe.GetAttribute(attrib);
                    }
                }

            }
            return "";

        }
         /// <summary>
         /// 写入
         /// </summary>
         /// <param name="filename"></param>
         /// <param name="xn"></param>
         /// <param name="nodename"></param>
         /// <param name="attrib"></param>
         /// <param name="value"></param>
        public static void SetA(string filename,XmlNode xn, string nodename, string attrib,string value)
        {
            foreach (XmlNode item in xn.ChildNodes)
            {
                if (item.ChildNodes.Count > 0)
                {
                    GetA(item, nodename, attrib);
                }
                else
                {
                    XmlElement xe = (XmlElement)item;
                    if (xe.Name == nodename)
                    {
                        xe.SetAttribute(attrib, value);
                        xdoc.Save(filename);
                    }
                }

            }

        }
    }
}
