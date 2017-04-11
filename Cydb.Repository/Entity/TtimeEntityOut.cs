namespace Cydb.Repository.Entity {
    /// <summary>
    /// 自定义时间控件输出
    /// </summary>
    public class TtimeEntityOut {
        /// <summary>
        /// 值
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked { set; get; }
        /// <summary>
        /// 分隔符，默认为‘至’
        /// </summary>
        public string SplitChar { set; private get; }
        public string GetSplitChar() {
            return string.IsNullOrWhiteSpace(SplitChar) ? "至" : SplitChar;
        }
    }
}
