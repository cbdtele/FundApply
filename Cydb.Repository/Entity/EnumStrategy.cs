namespace Cydb.Repository.Entity {
    /// <summary>
    /// 企业排名查询策略
    /// </summary>
    public enum EnumStrategy {
        /// <summary>
        /// 总额
        /// </summary>
        Targetsum = 1,
        /// <summary>
        /// 同比增速
        /// </summary>
        Zs = 2,
        /// <summary>
        /// 同比增量
        /// </summary>
        Zl = 3
    }
}
