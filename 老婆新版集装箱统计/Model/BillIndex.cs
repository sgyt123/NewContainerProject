using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BillIndex
    {
        /// <summary>
        /// 数据 ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime Reg_Date { get; set; }
        /// <summary>
        /// 进口 还是出口
        /// </summary>
        public string InOut { get; set; }
        /// <summary>
        /// 航线
        /// </summary>
        public string Voyage { get; set; }
        /// <summary>
        /// 船号
        /// </summary>
        public string ShipNo { get; set; }
        /// <summary>
        /// 结构体
        /// </summary>
        private Dictionary<string, int> stru = new Dictionary<string, int>();
        public Dictionary<string, int> Stru { get { return stru; } set { stru = value; } }

        public BillIndex()
        {
            ///初始化结构字典 默认的位置是0 为无 如果存在则大于0
            //stru.Add("ID", 0);
            stru.Add("序号", 0);
            stru.Add("箱号", 0);
            stru.Add("封号", 0);
            stru.Add("重量", 0);
            stru.Add("箱型", 0);
            stru.Add("状态", 0);
            stru.Add("船公司", 0);
            stru.Add("目的港", 0);
            stru.Add("货种", 0);
            stru.Add("作业地点", 0);
            stru.Add("代理", 0);
            stru.Add("船名/航次", 0);
            stru.Add("运单号", 0);
            stru.Add("来源地", 0);
            stru.Add("流向", 0);
            stru.Add("发往地", 0);
            stru.Add("备注", 0);
        }
        //序号	箱号	 封号	重量	 箱型	状态 	船公司	目的港	货种 	作业地点	代理	 船名/航次	运单号	来源地

    }
}
