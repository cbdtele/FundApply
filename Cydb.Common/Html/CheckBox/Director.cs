namespace Cydb.Common.Html.CheckBox {
    public class Director {
        public void Construct(Builder builder) {
            builder.BuildHiddenInput();
            builder.BuildShowInput();
        }
    }
}
