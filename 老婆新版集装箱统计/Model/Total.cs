using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Total
    {
        /// <summary>
        /// 此状态数量
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 进口或出口
        /// </summary>
        public string InOut { get; set; }
        /// <summary>
        /// 集装箱型号 20 40
        /// </summary>
        public string BoxSize { get; set; }
        /// <summary>
        /// 集装箱状态 重空
        /// </summary>
        public string BoxState { get; set; }
        /// <summary>
        /// 总重量
        /// </summary>
        public double TotalWeight { get; set; }
        /// <summary>
        /// 货物重量
        /// </summary>
        public double GoodsWeight { get; set; }
        /// <summary>
        /// 停泊艘次
        /// </summary>
        public string TBShouChi { get; set; }
        /// <summary>
        /// 作业艘次
        /// </summary>
        public string ZYShouChi { get; set; }
    }
}
