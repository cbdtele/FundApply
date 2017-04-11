namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public class SpanLabel {
        public SpanLabel(string @class = "", string htmlText = "") {
            Class = @class;
            HtmlText = htmlText;
        }

        public string Class { private set; get; }
        public string HtmlText { private set; get; }

        public string GetResult() {
            return $" <span class='{Class}'>{HtmlText}</span>";
        }
    }
}
