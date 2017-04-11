using Cydb.Common.Helper;

namespace Cydb.Repository.Entity {

    /// <summary>
    /// 全指标查询基类DTO工厂
    /// </summary>
    public class EntFactoryEntity : BaseTablePaging<EntFactoryEntity> {
        public EntFactoryEntity(string beginTime, string endTime, int enumTargetField, string orderBy, int page, int rows) : base(page, rows) {
            BeginTime = beginTime;
            EndTime = endTime;
            EnumTargetField = (EnumTargetField)enumTargetField;
            OrderBy = orderBy;
            TbBeginTime = BeginTime?.YearSubtract();
            TbEndTime = EndTime?.YearSubtract();
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginTime { get; }
        /// <summary>
        /// 同期开始时间
        /// </summary>
        public string TbBeginTime { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; }
        /// <summary>
        /// 同期结束时间
        /// </summary>
        public string TbEndTime { get; }
        /// <summary>
        /// 查询指标名
        /// </summary>
        public EnumTargetField EnumTargetField { get; }
        /// <summary>
        /// 排序方式 默认降序
        /// </summary>
        public string OrderBy { get; }
    }
}
