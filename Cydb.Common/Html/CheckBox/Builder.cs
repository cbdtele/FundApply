namespace Cydb.Common.Html.CheckBox {
    public abstract class Builder {
        /// <summary>
        /// 建造隐藏的复选框
        /// </summary>
        public abstract void BuildHiddenInput();
        /// <summary>
        /// 建造显示的复选框
        /// </summary>
        public abstract void BuildShowInput();
        public abstract string GetResult();
    }
}
