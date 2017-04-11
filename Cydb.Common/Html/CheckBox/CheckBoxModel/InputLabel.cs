namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public class InputLabel {
        public InputLabel(string type = "", string hiddenValue = "", string @class = "", string @checked = "") {
            Type = type;
            Class = @class;
            Checked = @checked;
            HiddenValue = hiddenValue;
        }

        public string Type { get; }
        public string HiddenValue { get; }
        public string Class { get; }
        public string Checked { get; }

        public string GetResult() {
            return $"<input type='{Type}' hiddenValue='{HiddenValue}' class='{Class}' {Checked}/>";
        }
    }
}
