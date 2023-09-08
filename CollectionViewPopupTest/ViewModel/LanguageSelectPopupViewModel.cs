using CollectionViewPopupTest.Interfaces;
using CollectionViewPopupTest.Localization;
using System.Globalization;

namespace CollectionViewPopupTest.ViewModel
{
    public class LanguageSelectPopupViewModel
    {
        private readonly IPopupDialogService _popupDialogService;

        public List<LanguageViewModel> Languages { get; }
        public Command<string> LanguageSelectedCommand { get; }

        public LanguageSelectPopupViewModel(IPopupDialogService popupDialogService, string currentLanguage)
        { 
            var languages = new List<LanguageViewModel>()
            {
                CreateLanguageModel("en", "English", currentLanguage),
                CreateLanguageModel("de", "German", currentLanguage),
                CreateLanguageModel("fr", "French", currentLanguage),
                CreateLanguageModel("it", "Italian", currentLanguage),
            };
            Languages = languages;
            LanguageSelectedCommand = new Command<string>(SelectLanguage);
            _popupDialogService = popupDialogService;
        }

        private static LanguageViewModel CreateLanguageModel(string langCode, string name, string current)
        {
            return new LanguageViewModel(langCode, $"{langCode}.png", name, name == current);
        }

        private void SelectLanguage(string langCode)
        { 
            var culture = new CultureInfo(langCode);
            LocalizationResourceManager.Instance.CurrentCulture = culture;

            _popupDialogService.ClosePopup();
        }
    }
}
