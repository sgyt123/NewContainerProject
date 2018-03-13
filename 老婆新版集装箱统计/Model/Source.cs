using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Source
    {
        public string ID { get; set; }
        /// <summary>
        /// 来源地
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 汇总名称 
        /// </summary>
        public string OtherName { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
    }
}
