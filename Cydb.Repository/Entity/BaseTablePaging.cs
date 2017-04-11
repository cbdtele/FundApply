namespace Cydb.Repository.Entity {
    /// <summary>
    /// 数据表格分页基类
    /// </summary>
    public abstract class BaseTablePaging<T> where T : class {
        protected BaseTablePaging(int page = 1, int rows = 10) {
            Page = page;
            Rows = rows;
            BeginPagNum = (Page - 1) * Rows;
            EndPagNum = Page * Rows;
        }

        /// <summary>
        /// 页
        /// </summary>
        public int Page { set; private get; } = 1;
        /// <summary>
        /// 每页显示数据
        /// </summary>
        public int Rows { set; private get; } = 10;
        /// <summary>
        /// 分页 起始行
        /// </summary>
        public int BeginPagNum { private set; get; }
        /// <summary>
        /// 分页 终止页
        /// </summary>
        public int EndPagNum { private set; get; }
    }
}
