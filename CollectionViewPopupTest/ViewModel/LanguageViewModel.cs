namespace CollectionViewPopupTest.ViewModel
{
    public class LanguageViewModel
    {
        public string IconSource { get; }
        public string LangCode { get; }
        public string Description { get; }
        public bool IsChecked { get; }

        public LanguageViewModel(string iconSource, string langCode, string description, bool isChecked) 
        {
            IconSource = iconSource;
            LangCode = langCode;
            Description = description;
            IsChecked = isChecked;
        }
    }
}
