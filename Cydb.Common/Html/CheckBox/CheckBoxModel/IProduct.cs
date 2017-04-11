namespace Cydb.Common.Html.CheckBox.CheckBoxModel {
    public interface IProduct {
        void AddInputLabel(InputLabel inputLabel);
        void AddLabelGroupLabel(LabelGroupLabel labelGroupLabel);
        string GetResult();
    }
}