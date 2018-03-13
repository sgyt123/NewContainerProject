using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Bill
    {
        /// <summary>
        /// 数据ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string Sequence { get; set; }
        /// <summary>
        /// 箱号
        /// </summary>
        public string BoxNo { get; set; }
        /// <summary>
        /// 封号
        /// </summary>
        public string SealNo { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 箱型
        /// </summary>
        public string BoxSize { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string BoxState { get; set; }
        /// <summary>
        /// 船公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 目的港
        /// </summary>
        public string Aim { get; set; }
        /// <summary>
        /// 货种
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 货种总分类
        /// </summary>
        public string GoodsTypeUp { get; set; }
        /// <summary>
        /// 作业地点
        /// </summary>
        public string WorkPlace { get; set; }
        /// <summary>
        /// 代理
        /// </summary>
        public string Proxy { get; set; }
        /// <summary>
        /// 船名/航次
        /// </summary>
        public string ShipName { get; set; }
        /// <summary>
        /// 运单号
        /// </summary>
        public string WayBillNo { get; set; }
        /// <summary>
        /// 来源地
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 归属的总索引号
        /// </summary>
        public string BillIndexID { get; set; }
        /// <summary>
        /// 流向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 发往地
        /// </summary>
        public string SendPlace { get; set; }
        /// <summary>
        /// 船舶信息
        /// </summary>
        public string ShipInfo { get; set; }
        /// <summary>
        /// 进出
        /// </summary>
        public string InOut { get; set; }
        /// <summary>
        /// 备注项目
        /// </summary>
        public string Demo { get; set; }
        /// <summary>
        /// 船舶类型
        /// </summary>
        public string ShipType { get; set; }
        /// <summary>
        /// 航线
        /// </summary>
        public string Voyage { get; set; }
    }
}
