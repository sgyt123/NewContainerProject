using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Drawing;
using ConfigManager;
using BaseDAL;

namespace BillManager
{
    public class DataInputManager
    {
        /// <summary>
        /// 根据日期查询船舶记录 
        /// </summary>
        /// <param name="dgv">填充到表格控件</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">终止日期</param>
        /// <param name="inorput">进口或出口</param>
        /// <returns></returns>
        public DataGridView FindsToDgv(DataGridView dgv, string startDate, string endDate, string inorput)
        {
            string where = " reg_date>='" + startDate + "' and reg_date<='" + endDate + "' and inout like '%" + inorput + "%'";
            List<BillIndex> bills = new BaseService<BillIndex>().GetRecords(where);
            dgv.Rows.Clear();
            foreach (BillIndex item in bills)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvFindListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvFindListName"].Value = item.Title;
                dgv.Rows[index].Cells["dgvFindListDate"].Value = item.Reg_Date.ToString("yyyy-MM-dd");
            }
            return dgv;
        }
        /// <summary>
        /// 利用现有的集合装入查询列表
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="bis"></param>
        /// <returns></returns>
        public DataGridView FindsToDgv(DataGridView dgv, List<BillIndex> bis)
        {
            dgv.Rows.Clear();
            foreach (BillIndex item in bis)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells["dgvFindListID"].Value = item.ID;
                dgv.Rows[index].Cells["dgvFindListName"].Value = item.Title;
                dgv.Rows[index].Cells["dgvFindListDate"].Value = item.Reg_Date.ToString("yyyy-MM-dd");
            }
            return dgv;
        }
        /// <summary>
        /// 初始化表格 装箱单
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public DataGridView InitBoxInfoDataGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;   //选择模式为整行 
            dgv.MultiSelect = true;                                       //不可以多选
            dgv.RowHeadersVisible = false;                                 //隐藏头一列
            dgv.AllowUserToResizeRows = false;                             //设置行是否可以调整大小
            dgv.BackgroundColor = Color.White;                               //设置背景颜色
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;      //设置列头不能自动高度
            dgv.ColumnHeadersHeight = 24;                                  //列头部高
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.DeepSkyBlue };
            dgv.GridColor = Color.Black;
            //序号ckSequence 	箱号	 封号	重量	 箱型	状态 	船公司	目的港	货种 	作业地点	代理	 船名/航次	运单号	来源地
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", Width = 40, Name = "dgvExcelID", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }, Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "序号", Width = 40, Name = "dgvExcelSequence", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "箱号", Width = 90, Name = "dgvExcelBoxNo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "封号", Width = 90, Name = "dgvExcelSealNo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "重量", Width = 70, Name = "dgvExcelWeight", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "箱型", Width = 60, Name = "dgvExcelBoxSize", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "状态", Width = 70, Name = "dgvExcelBoxState", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "船公司", Width = 90, Name = "dgvExcelCompany", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "目的港", Width = 90, Name = "dgvExcelAim", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "货种", Width = 100, Name = "dgvExcelGoodsType", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "作业地点", Width = 100, Name = "dgvExcelWorkPlace", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "代理", Width = 70, Name = "dgvExcelProxy", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "船名/航次", Width = 120, Name = "dgvExcelShipName", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "运单号", Width = 150, Name = "dgvExcelWayBillNo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "来源地", Width = 70, Name = "dgvExcelSource", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "流向", Width = 70, Name = "dgvExcelDirection", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "发往地", Width = 70, Name = "dgvExcelSendPlace", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "备注", Width = 50, Name = "dgvExcelDemo", SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            return dgv;
        }

        /// <summary>
        /// 获取一个清单号的所有记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Bill> GetBills(string id)
        {
            return new BaseService<Bill>().GetRecords(" billIndexID=" + id);    //获取此票据的详细信息
        }

        /// <summary>
        /// 把集合装入详细装船明细单
        /// </summary>
        /// <param name="dgv">信息表格</param>
        /// <param name="id">船舶明细编号</param>
        /// <param name="error">返回错误列表</param>
        /// <returns></returns>
        public void LookShipInfo(List<Bill> bi, DataGridView dgv, ref string error, ref string total)
        {
            dgv.Rows.Clear();
            int errorint = 0;      //错误计数器
            double weight = 0;     //重量统计
            Dictionary<string, int> boxnumber = new Dictionary<string, int>() { };
            //读取数据库内容 箱型号加入到字典中
            foreach (BoxSize item in new BaseService<BoxSize>().GetRecords(" 1=1"))
            {
                boxnumber.Add(item.Name, 0);
            }
            foreach (Bill item in bi)
            {
                int index = dgv.Rows.Add();
                CheckItemData(dgv.Rows[index], item, ref boxnumber, ref errorint, ref weight);
            }
            total = "总:" + bi.Count.ToString() + "/";
            total = total + "总重:" + weight.ToString() + "/";

            //箱子统计
            foreach (string item in boxnumber.Keys)
            {
                total += item + ":" + boxnumber[item].ToString() + "个/";
            }
            error = "总计有" + errorint.ToString() + "个错误。";
        }


        /// <summary>
        /// 校验数据个列合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private void CheckItemData(DataGridViewRow dgvRow, Bill b, ref Dictionary<string, int> boxnumber, ref int errorint, ref double weight)
        {
            #region ID号
            dgvRow.Cells["dgvExcelID"].Value = b.ID;
            #endregion

            #region 序号
            if (b.Sequence != null)
            {
                dgvRow.Cells["dgvExcelSequence"].Value = b.Sequence;
                try
                {
                    int.Parse(b.Sequence);
                    dgvRow.Cells["dgvExcelSequence"].Style.BackColor = Color.White;
                }
                catch (Exception)
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelSequence"].Style.BackColor = Color.Red;
                }
                if (b.Sequence.Contains(",") || b.Sequence.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelSequence"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelSequence"].Value = "";
            }
            #endregion

            #region 箱子号
            if (b.BoxNo != null)
            {
                dgvRow.Cells["dgvExcelBoxNo"].Value = b.BoxNo;
                if (b.BoxNo.Contains(",") || b.BoxNo.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelBoxNo"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelBoxNo"].Value = "";
            }
            #endregion

            #region 封号
            if (b.SealNo != null)
            {
                dgvRow.Cells["dgvExcelSealNo"].Value = b.SealNo;
                if (b.SealNo.Contains(",") || b.SealNo.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelSealNo"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelSealNo"].Value = "";
            }
            #endregion

            #region 重量
            if (b.Weight != null)
            {
                dgvRow.Cells["dgvExcelWeight"].Value = b.Weight;
                try
                {
                    double singleweigth=double.Parse(b.Weight);
                    dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.White;
                    if (b.BoxState == CommValue.BoxState[0])   //如果重的 重量大于系数
                    {
                        if (b.BoxSize.Substring(0,2) == CommValue.BoxSize[0])   //20长的 要大于2.3
                        {
                            if (singleweigth <= CommValue.SingleCoefficient)
                            {
                                dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Brown;
                            }
                        }
                        else
                        {
                            //如果是40长的箱子
                            if (singleweigth <= CommValue.DoubleCoefficient)
                            {
                                dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Brown;
                            }
                        }
                    }
                    else
                    {
                        //如果是空的箱子 则直接可以赋值
                        if (b.BoxSize.Substring(0, 2) == CommValue.BoxSize[0])   //20长的
                        {
                            if (b.Weight != CommValue.SingleCoefficient.ToString())
                            {
                                dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            if (b.Weight != CommValue.DoubleCoefficient.ToString())
                            {
                                dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Yellow;
                            }
                        }
                    }
                    
                    weight += double.Parse(b.Weight);
                }
                catch (Exception)
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Red;
                }
                if (b.Weight.Contains(",") || b.Weight.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                //当为空时候的判断 是否是空箱
                if (b.BoxState == CommValue.BoxState[1])    //是否为空箱子
                {
                    if (b.BoxSize.Substring(0, 2) == CommValue.BoxSize[0])   //20长的
                    {
                        dgvRow.Cells["dgvExcelWeight"].Value = CommValue.SingleCoefficient.ToString();
                        b.Weight = CommValue.SingleCoefficient.ToString();
                    }
                    else
                    {
                        dgvRow.Cells["dgvExcelWeight"].Value = (CommValue.DoubleCoefficient).ToString();
                        b.Weight = (CommValue.DoubleCoefficient).ToString();
                    }
                }
                else
                {
                    dgvRow.Cells["dgvExcelWeight"].Value = "0";
                    dgvRow.Cells["dgvExcelWeight"].Style.BackColor = Color.Red;
                }
            }
            #endregion

            #region 箱子型号
            if (b.BoxSize != null)
            {
                dgvRow.Cells["dgvExcelBoxSize"].Value = b.BoxSize;
                if (!string.IsNullOrEmpty(new BaseService<BoxSize>().GetRecord(" name='" + b.BoxSize + "'").ID))
                {
                    boxnumber[b.BoxSize]++;
                    dgvRow.Cells["dgvExcelBoxSize"].Style.BackColor = Color.White;
                }
                else
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelBoxSize"].Style.BackColor = Color.Red;
                }
                if (b.BoxSize.Contains(",") || b.BoxSize.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelBoxSize"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelBoxSize"].Value = "";
            }
            #endregion

            #region 箱子状态
            if (b.BoxState != null)
            {
                dgvRow.Cells["dgvExcelBoxState"].Value = b.BoxState;
                if (CommValue.BoxState.Contains(b.BoxState))     //利用常量数组来完成比较
                {
                    dgvRow.Cells["dgvExcelBoxState"].Style.BackColor = Color.White;
                }
                else
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelBoxState"].Style.BackColor = Color.Red;
                }
                if (b.BoxState.Contains(",") || b.BoxState.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelBoxState"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelBoxState"].Value = "";
            }
            #endregion

            #region 船公司
            if (b.Company != null)
            {
                dgvRow.Cells["dgvExcelCompany"].Value = b.Company;
                if (!string.IsNullOrEmpty(new BaseService<Company>().GetRecord(" name='" + b.Company + "'").ID))
                {
                    dgvRow.Cells["dgvExcelCompany"].Style.BackColor = Color.White;
                }
                else
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelCompany"].Style.BackColor = Color.Red;
                }
                if (b.Company.Contains(",") || b.Company.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelCompany"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelCompany"].Value = "";
            }
            #endregion

            #region 目的港
            if (b.Aim != null)
            {
                dgvRow.Cells["dgvExcelAim"].Value = b.Aim;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.Aim)))     //空船必须判断
                {
                    if (!string.IsNullOrEmpty(new BaseService<Aim>().GetRecord(" name='" + b.Aim + "' ").ID))
                    {
                        dgvRow.Cells["dgvExcelAim"].Style.BackColor = Color.White;
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelAim"].Style.BackColor = Color.Red;
                    }

                }
                if (b.Aim.Contains(",") || b.Aim.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelAim"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelAim"].Value = "";
            }
            #endregion

            #region 货种
            if (b.GoodsType != null)
            {
                dgvRow.Cells["dgvExcelGoodsType"].Value = b.GoodsType;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.GoodsType)))
                {
                    GoodsType goods = new BaseService<GoodsType>().GetRecord(" name='" + b.GoodsType + "'");
                    if (!string.IsNullOrEmpty(goods.ID))
                    {
                        //如果没有上级的则出现另类颜色
                        if (!string.IsNullOrEmpty(goods.UpID) && goods.UpID != "0")
                            dgvRow.Cells["dgvExcelGoodsType"].Style.BackColor = Color.White;
                        else
                            dgvRow.Cells["dgvExcelGoodsType"].Style.BackColor = Color.Yellow;       //黄色的为没定义上一 级货种  
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelGoodsType"].Style.BackColor = Color.Red;        //红色为错误的格式，无对应记录内容
                    }
                }
                if (b.GoodsType.Contains(",") || b.GoodsType.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelGoodsType"].Style.BackColor = Color.Green;            //非法字符
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelGoodsType"].Value = "";
            }
            #endregion

            #region 工作地点
            if (b.WorkPlace != null)
            {
                dgvRow.Cells["dgvExcelWorkPlace"].Value = b.WorkPlace;
                if (!string.IsNullOrEmpty(new BaseService<WorkPlace>().GetRecord(" name='" + b.WorkPlace + "'").ID))
                {
                    dgvRow.Cells["dgvExcelWorkPlace"].Style.BackColor = Color.White;
                }
                else
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelWorkPlace"].Style.BackColor = Color.Red;
                }
                if (b.WorkPlace.Contains(",") || b.WorkPlace.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelWorkPlace"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelWorkPlace"].Value = "";
            }
            #endregion

            #region 代理
            if (b.Proxy != null)
            {
                dgvRow.Cells["dgvExcelProxy"].Value = b.Proxy;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.Proxy)))
                {
                    if (!string.IsNullOrEmpty(new BaseService<Proxy>().GetRecord(" name='" + b.Proxy + "'").ID))
                    {
                        dgvRow.Cells["dgvExcelProxy"].Style.BackColor = Color.White;
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelProxy"].Style.BackColor = Color.Red;
                    }
                }
                if (b.Proxy.Contains(",") || b.Proxy.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelProxy"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelProxy"].Value = "";
            }
            #endregion

            #region 船舶名称
            if (b.ShipName != null)
            {
                dgvRow.Cells["dgvExcelShipName"].Value = b.ShipName;
                if (b.ShipName.Contains(",") || b.ShipName.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelShipName"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelShipName"].Value = "";
            }
            #endregion

            #region 运单号
            if (b.WayBillNo != null)
            {
                dgvRow.Cells["dgvExcelWayBillNo"].Value = b.WayBillNo;
                if (b.WayBillNo.Contains(",") || b.WayBillNo.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelWayBillNo"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelWayBillNo"].Value = "";
            }
            #endregion

            #region 来源地
            if (b.Source != null)
            {
                dgvRow.Cells["dgvExcelSource"].Value = b.Source;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.Source)))
                {
                    if (!string.IsNullOrEmpty(new BaseService<Source>().GetRecord(" name='" + b.Source + "'").ID))
                    {
                        dgvRow.Cells["dgvExcelSource"].Style.BackColor = Color.White;
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelSource"].Style.BackColor = Color.Red;
                    }
                }
                if (b.Source.Contains(",") || b.Source.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelSource"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelSource"].Value = "";
            }
            #endregion

            #region 流向
            if (b.Direction != null)
            {
                dgvRow.Cells["dgvExcelDirection"].Value = b.Direction;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.Direction)))
                {
                    if (!string.IsNullOrEmpty(new BaseService<Direction>().GetRecord(" name='" + b.Direction + "'").ID))
                    {
                        dgvRow.Cells["dgvExcelDirection"].Style.BackColor = Color.White;
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelDirection"].Style.BackColor = Color.Red;
                    }
                }
                if (b.Direction.Contains(",") || b.Direction.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelDirection"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelDirection"].Value = "";
            }
            #endregion

            #region 发往地
            if (b.SendPlace != null)
            {
                dgvRow.Cells["dgvExcelSendPlace"].Value = b.SendPlace;
                if (b.BoxState != "空" || (!string.IsNullOrEmpty(b.SendPlace)))
                {
                    if (!string.IsNullOrEmpty(new BaseService<SendPlace>().GetRecord(" name='" + b.SendPlace + "'").ID))
                    {
                        dgvRow.Cells["dgvExcelSendPlace"].Style.BackColor = Color.White;
                    }
                    else
                    {
                        errorint++;
                        dgvRow.Cells["dgvExcelSendPlace"].Style.BackColor = Color.Red;
                    }
                }
                if (b.SendPlace.Contains(",") || b.SendPlace.Contains("'"))
                {
                    errorint++;
                    dgvRow.Cells["dgvExcelSendPlace"].Style.BackColor = Color.Green;
                }
            }
            else
            {
                dgvRow.Cells["dgvExcelSendPlace"].Value = "";
            }
            #endregion

            #region 备注标注
            dgvRow.Cells["dgvExcelDemo"].Value = b.Demo;
            if (b.Demo.Contains(",") || b.Demo.Contains("'"))
            {
                errorint++;
                dgvRow.Cells["dgvExcelDemo"].Style.BackColor = Color.Green;
            }
            #endregion

        }



        /// <summary>
        /// 表格内容导如集合
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public List<Bill> DataGridViwToList(DataGridView dgv)
        {
            List<Bill> bills = new List<Bill>();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                Bill b = new Bill();
                if (item.Cells["dgvExcelID"].Value == null)
                    b.ID = "";
                else
                    b.ID = item.Cells["dgvExcelID"].Value.ToString();
                b.Sequence = (item.Cells["dgvExcelSequence"].Value==null?"":item.Cells["dgvExcelSequence"].Value.ToString());
                b.BoxNo = (item.Cells["dgvExcelBoxNo"].Value.ToString()==null?"":item.Cells["dgvExcelBoxNo"].Value.ToString());
                b.SealNo = (item.Cells["dgvExcelSealNo"].Value==null?"":item.Cells["dgvExcelSealNo"].Value.ToString());
                b.Weight = (item.Cells["dgvExcelWeight"].Value==null?"":item.Cells["dgvExcelWeight"].Value.ToString());
                b.BoxSize = (item.Cells["dgvExcelBoxSize"].Value==null?"":item.Cells["dgvExcelBoxSize"].Value.ToString());
                b.BoxState =(item.Cells["dgvExcelBoxState"].Value==null?"": item.Cells["dgvExcelBoxState"].Value.ToString());
                b.Company = (item.Cells["dgvExcelCompany"].Value==null?"":item.Cells["dgvExcelCompany"].Value.ToString());
                b.Aim = (item.Cells["dgvExcelAim"].Value==null?"":item.Cells["dgvExcelAim"].Value.ToString());
                b.GoodsType = (item.Cells["dgvExcelGoodsType"].Value==null?"":item.Cells["dgvExcelGoodsType"].Value.ToString());
                b.WorkPlace = (item.Cells["dgvExcelWorkPlace"].Value==null?"":item.Cells["dgvExcelWorkPlace"].Value.ToString());
                b.Proxy = (item.Cells["dgvExcelProxy"].Value==null?"":item.Cells["dgvExcelProxy"].Value.ToString());
                b.ShipName = (item.Cells["dgvExcelShipName"].Value==null?"":item.Cells["dgvExcelShipName"].Value.ToString());
                b.WayBillNo = (item.Cells["dgvExcelWayBillNo"].Value==null?"":item.Cells["dgvExcelWayBillNo"].Value.ToString());
                b.Source = (item.Cells["dgvExcelSource"].Value==null?"":item.Cells["dgvExcelSource"].Value.ToString());
                b.Direction = (item.Cells["dgvExcelDirection"].Value==null?"":item.Cells["dgvExcelDirection"].Value.ToString());
                b.SendPlace = (item.Cells["dgvExcelSendPlace"].Value==null?"":item.Cells["dgvExcelSendPlace"].Value.ToString());
                b.Demo = (item.Cells["dgvExcelDemo"].Value.ToString() == null ? "" : item.Cells["dgvExcelDemo"].Value.ToString());
                bills.Add(b);
            }
            return bills;
        }
        /// <summary>
        /// 更改成选择方式
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public DataGridViewCell CellToComboBox(DataGridViewCell cell)
        {
            DataGridViewComboBoxCell combox = new DataGridViewComboBoxCell();
            switch (cell.ColumnIndex)
            {
                case 4:  //箱子重量  重新录入
                    if (cell.Value != null)
                    {
                        try
                        {
                            double.Parse(cell.Value.ToString());
                            cell.Style.BackColor = Color.White;
                        }
                        catch (Exception)
                        {
                            cell.Style.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        //当为空时候的判断 是否是空箱
                        cell.Value = "0";
                        cell.Style.BackColor = Color.Red;
                        
                    }
                    break;
                case 5:    //箱子型
                    List<BoxSize> bs = new BaseService<BoxSize>().GetRecords(" 1=1");
                    combox.DataSource = bs;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 7:    //船公司
                    List<Company> cp = new BaseService<Company>().GetRecords(" 1=1");
                    cp.Insert(0, new Company() { ID = "0", Name = "" });
                    combox.DataSource = cp;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 8:  //目的港
                    List<Aim> ai = new BaseService<Aim>().GetRecords(" 1=1");
                    ai.Insert(0, new Aim() { ID = "0", Name = "" });
                    combox.DataSource = ai;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 9:   //货种
                    List<GoodsType> good = new BaseService<GoodsType>().GetRecords(" 1=1");
                    good.Insert(0, new GoodsType() { ID = "0", Name = "" });
                    combox.DataSource = good;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 10:
                    List<WorkPlace> work = new BaseService<WorkPlace>().GetRecords(" 1=1");
                    work.Insert(0, new WorkPlace() { ID = "0", Name = "" });
                    combox.DataSource = work;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 11:
                    List<Proxy> proxy = new BaseService<Proxy>().GetRecords(" 1=1");
                    proxy.Insert(0, new Proxy() { ID = "0", Name = "" });
                    combox.DataSource = proxy;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 14:
                    List<Source> source = new BaseService<Source>().GetRecords(" 1=1");
                    source.Insert(0, new Source() { ID = "0", Name = "" });
                    combox.DataSource = source;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 15:
                    List<Direction> dt = new BaseService<Direction>().GetRecords(" 1=1");
                    dt.Insert(0, new Direction() { ID = "0", Name = "" });
                    combox.DataSource = dt;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 16:
                    List<SendPlace> send = new BaseService<SendPlace>().GetRecords(" 1=1");
                    send.Insert(0, new SendPlace() { ID = "0", Name = "" });
                    combox.DataSource = send;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 17:
                    foreach (string item in CommValue.BoxVirtual)
                    {
                        combox.Items.Add(item);
                    }
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
                case 6:
                    List<BoxState> state = new BaseService<BoxState>().GetRecords(" 1=1");
                    combox.DataSource = state;
                    combox.ValueMember = "Name";
                    combox.DisplayMember = "Name";
                    combox.Value = cell.Value.ToString();
                    cell = combox;
                    break;
            }

            return cell;
        }
        /// <summary>
        ///  更改回文本方式
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public DataGridViewCell CellToTextBox(DataGridViewCell cell)
        {
            if (cell == null)
            {
                return cell;
            }
            if (cell is DataGridViewComboBoxCell)
            {
                DataGridViewTextBoxCell textbox = new DataGridViewTextBoxCell();
                if (cell.Value != null)
                    textbox.Value = cell.Value.ToString();
                else
                    textbox.Value = "";
                cell = textbox;
            }
            return cell;
        }

        /// <summary>
        ///  更改回文本方式
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public void CheckTextBox(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                return;
            }
            cell.Style.BackColor = Color.White;
            string context = cell.Value.ToString();
            if (context.Trim() == "")     //空白直接返回
                return;
            //语法错误的
            if (context.Contains(",") || context.Contains("'"))
            {
                cell.Style.BackColor = Color.Green;
                return;
            }
            switch (cell.ColumnIndex)
            {
                case 4:  //箱子重量  重新录入
                    if (cell.Value != null)
                    {
                        try
                        {
                            double.Parse(cell.Value.ToString());
                            cell.Style.BackColor = Color.White;
                            if (double.Parse(cell.Value.ToString()) <= 0)
                            {
                                cell.Style.BackColor = Color.Brown;
                            }
                        }
                        catch (Exception)
                        {
                            cell.Style.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        //当为空时候的判断 是否是空箱
                        cell.Value = "0";
                        cell.Style.BackColor = Color.Red;

                    }
                    break;
                case 5:    //箱子型
                    BoxSize bs = new BaseService<BoxSize>().GetRecord(" name='" + context + "'");
                    if (string.IsNullOrEmpty(bs.ID))
                        cell.Style.BackColor = Color.Red;
                    break;
                case 7:    //船公司
                    Company company = new BaseService<Company>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(company.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = company.Name;
                    break;
                case 8:  //目的港
                    Aim aim = new BaseService<Aim>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(aim.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = aim.Name;
                    break;
                case 9:   //货种
                    GoodsType goodstype = new BaseService<GoodsType>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(goodstype.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                    {
                        cell.Value = goodstype.Name;
                        GoodsTypeUp goodsup = new BaseService<GoodsTypeUp>().GetRecord(" code='" + goodstype.UpID+"'");
                        if (string.IsNullOrEmpty(goodsup.ID))
                            cell.Style.BackColor = Color.Yellow;
                    }
                    break;
                case 10:
                    WorkPlace workplace = new BaseService<WorkPlace>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(workplace.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = workplace.Name;
                    break;
                case 11:
                    Proxy proxy = new BaseService<Proxy>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(proxy.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = proxy.Name;
                    break;
                case 14:
                    Source source = new BaseService<Source>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(source.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = source.Name;
                    break;
                case 15:
                    Direction direction = new BaseService<Direction>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(direction.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = direction.Name;
                    break;
                case 16:
                    SendPlace sendplace = new BaseService<SendPlace>().GetRecord(" name='" + context + "' or code='" + context + "'");
                    if (string.IsNullOrEmpty(sendplace.ID))
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Value = sendplace.Name;
                    break;
                case 6:
                    BoxState boxstate = new BaseService<BoxState>().GetRecord(" name='" + context + "'");
                    if (string.IsNullOrEmpty(boxstate.ID))
                        cell.Style.BackColor = Color.Red;
                    break;
            }
            return;
        }

        /// <summary>
        /// 更新船舶明细
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateBill(List<Bill> b, string id)
        {
            return new BillFindService().UpdateBill(b, id);
        }

        public string InsertBill(List<Bill> b, BillIndex bi)
        {
            return new BillFindService().InsertBill(bi, b);
        }
        /// <summary>
        /// 获取船舶信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ShipInfo GetShipInfo(string name)
        {
            return new BaseService<ShipInfo>().GetRecord(" name='" + name + "'");
        }
        /// <summary>
        /// 获取明细单信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BillIndex GetBillIndex(string name)
        {
            return new BaseService<BillIndex>().GetRecord(name);
        }
    }
}
