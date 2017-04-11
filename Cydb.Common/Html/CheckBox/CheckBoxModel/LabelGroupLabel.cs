namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public class LabelGroupLabel {
        public LabelGroupLabel(string @class = "", string text = "", string isDisabled = "") {
            IsDisabled = isDisabled;
            Class = @class;
            Text = text;
        }

        public string Class { get; }
        public string Text { get; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public string IsDisabled { get; }

        public string GetResult() {
            var @imagespan = new SpanLabel("check-image ").GetResult();
            var @textspan = new SpanLabel("radiobox-content ", Text).GetResult();
            var @labelgroup = new LabelLabel(Class + " " + IsDisabled, @imagespan + @textspan).GetResult();
            return @labelgroup;
        }
    }
}
