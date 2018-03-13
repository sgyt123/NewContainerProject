using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Proxy
    {
        public string ID { get; set; }
        /// <summary>
        /// 代理名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string OtherName { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
