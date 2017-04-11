using Cydb.Common.Html.CheckBox.CheckBoxModel;

namespace Cydb.Common.Html.CheckBox {
    public class CheckBoxBuilder : Builder {
        private readonly InputLabel _inputLabel;
        private readonly LabelGroupLabel _labelGroupLabel;

        /// <summary>
        /// 建造一个漂亮的复选框
        /// </summary>
        public CheckBoxBuilder(CheckBoxDto checkBoxDto) {
            _inputLabel = new InputLabel("checkbox", checkBoxDto.Value, "chklist", checkBoxDto.IsChecked ? " checked='checked' " : "");
            _labelGroupLabel = new LabelGroupLabel("chkbox", checkBoxDto.Text, checkBoxDto.IsDisabled ? " disabled " : "");
        }

        private readonly IProduct _product = new Product();
        public override void BuildHiddenInput() {
            _product.AddInputLabel(_inputLabel);
        }

        public override void BuildShowInput() {
            _product.AddLabelGroupLabel(_labelGroupLabel);
        }

        public override string GetResult() {
            return _product.GetResult();
        }
    }
}
