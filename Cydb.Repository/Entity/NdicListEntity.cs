namespace Cydb.Repository.Entity {
    /// <summary>
    /// 行业分类全指标查询
    /// </summary>
    public class NdicListEntity {
        /// <summary>
        /// 行业代码
        /// </summary>
        public string ID { set; get; }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string NAME { set; get; }
        /// <summary>
        /// 税收
        /// </summary>
        public decimal TAX { set; get; }
        /// <summary>
        /// 区级收入
        /// </summary>
        public decimal QJSR { set; get; }
        /// <summary>
        /// GDP
        /// </summary>
        public decimal GDP { set; get; }
        /// <summary>
        /// 资产总计
        /// </summary>
        public decimal ZCZJ { set; get; }
        /// <summary>
        /// 营业收入
        /// </summary>
        public decimal YYSR { set; get; }
        /// <summary>
        /// 利润总额
        /// </summary>
        public decimal LRZE { set; get; }
        /// <summary>
        /// 从业人员 
        /// </summary>
        public decimal CYRY { set; get; }
        /// <summary>
        /// 水耗
        /// </summary>
        public decimal SH_SJ { set; get; }
        /// <summary>
        /// 能耗
        /// </summary>
        public decimal NYXFL { set; get; }
    }
}
