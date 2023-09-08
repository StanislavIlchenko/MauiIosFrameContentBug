using CollectionViewPopupTest.Localization;

namespace CollectionViewPopupTest.Extensions
{
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {

        public string Text { get; set; }
        public string StringFormat { get; set; }
        public IValueConverter Converter { get; set; }
        public object ConverterParameter { get; set; }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = LocalizationResourceManager.Instance,
                StringFormat = StringFormat,
                Converter = Converter,
                ConverterParameter = ConverterParameter
            };

            return binding;
        }
    }
}
