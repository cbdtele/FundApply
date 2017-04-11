namespace Cydb.Repository.Entity {
    /// <summary>
    /// 查询查询组合实体
    /// </summary>
    public class SqlBuildSubQuery {
        /// <summary>
        /// 查询列
        /// </summary>
        public string SelectColumn { set; get; }
        /// <summary>
        /// 联合查询表
        /// </summary>
        public string SubQuery { set; get; }
        /// <summary>
        /// 连接语句和过滤条件
        /// </summary>
        public string JoinWhere { set; get; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string OrderBy { set; get; }
        /// <summary>
        /// 分页
        /// </summary>
        public string Paging { set; get; }
    }
}
