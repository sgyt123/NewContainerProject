using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigManager
{
    public class CommValue
    {
        public static Dictionary<string, int> BoxSpec = new Dictionary<string, int>();
        /// <summary>
        /// 集装箱的分类型号 20 40
        /// </summary>
        public static string[] BoxSize = new string[] {"20","40" };
        /// <summary>
        /// 集装箱的分类类型
        /// </summary>
        public static string[] BoxState = new string[] {"重","空" };
        /// <summary>
        /// 集装箱的虚 实数
        /// </summary>
        public static string[] BoxVirtual = new string[] {"实","虚" };
        /// <summary>
        /// 集装箱的进口 出口
        /// </summary>
        public static string[] BoxInOut = new string[] { "进口", "出口" };
        /// <summary>
        /// 单个20箱子系数
        /// </summary>
        public static double SingleCoefficient = 2.3;
        //双40箱子系数
        public static double DoubleCoefficient = 4.6;

    }
}
