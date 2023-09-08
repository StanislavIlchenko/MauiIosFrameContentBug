namespace CollectionViewPopupTest.Converters
{
    using System.Reflection;

    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var sourceIdentifier = value as string;
            if (sourceIdentifier == null)
            {
                return null;
            }

            var source = ImageSource.FromResource(sourceIdentifier, typeof(StringToImageSourceConverter).GetTypeInfo().Assembly);

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
