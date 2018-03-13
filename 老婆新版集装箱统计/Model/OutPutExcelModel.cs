using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class OutPutExcelModel
    {
        /// <summary>
        /// 报表名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 起始时间 
        /// </summary>
        public DateTime StartDay { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDay { get; set; }
    }
}
