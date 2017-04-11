namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public class LabelLabel {
        public LabelLabel(string @class = "", string htmlText = "") {
            Class = @class;
            HtmlText = htmlText;
        }

        public string Class { private set; get; }
        public string HtmlText { private set; get; }

        public string GetResult() {
            return $"<label class='{Class}'>{HtmlText}</label>";
        }
    }
}
