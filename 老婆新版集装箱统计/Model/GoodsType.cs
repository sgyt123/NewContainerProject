using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GoodsType
    {
        public string ID { get; set; }
        /// <summary>
        /// 货种名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上一级ID
        /// </summary>
        public string UpID { get; set; }
        /// <summary>
        /// 上一级名称
        /// </summary>
        public string UpName { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
