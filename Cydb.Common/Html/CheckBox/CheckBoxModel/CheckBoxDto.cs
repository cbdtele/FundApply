namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    /// <summary>
    /// 自定义美化CheckBox配置Dto
    /// </summary>
    public class CheckBoxDto {
        /// <summary>
        /// 自定义美化CheckBox配置Dto
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="value">值</param>
        /// <param name="isChecked">是否选中，默认不选中</param>
        /// <param name="isDisabled">是否禁用，默认不禁用</param>
        public CheckBoxDto(string text, string value, bool isChecked = false, bool isDisabled = false) {
            Text = text;
            Value = value;
            IsChecked = isChecked;
            IsDisabled = isDisabled;
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text { private set; get; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { private set; get; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked { private set; get; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisabled { private set; get; }
    }
}
