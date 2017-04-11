namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public class Product : IProduct {
        public InputLabel InputLabel { private set; get; }
        public LabelGroupLabel LabelGroupLabel { private set; get; }

        public void AddInputLabel(InputLabel inputLabel) {
            InputLabel = inputLabel;
        }
        public void AddLabelGroupLabel(LabelGroupLabel labelGroupLabel) {
            LabelGroupLabel = labelGroupLabel;
        }
        public string GetResult() {
            return InputLabel.GetResult() + LabelGroupLabel.GetResult();
        }
    }
}
