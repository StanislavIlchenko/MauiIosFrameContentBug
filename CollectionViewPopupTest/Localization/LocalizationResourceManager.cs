namespace CollectionViewPopupTest.Localization
{
    using System.Diagnostics;
    using System.Globalization;
    using CommunityToolkit.Mvvm.ComponentModel;

    public class LocalizationResourceManager : ObservableObject
    {
        private const string LanguagePreference = "Language";

        private static LocalizationResourceManager _instance;
        private CultureInfo _currentCulture = Thread.CurrentThread.CurrentUICulture;

        public static LocalizationResourceManager Instance => _instance;

        private LocalizationResourceManager()
        {
            var cultureLetters = Preferences.Get(LanguagePreference, default(string));
            if (string.IsNullOrEmpty(cultureLetters))
            {
                cultureLetters = "en";
            }

            CurrentCulture = new CultureInfo(cultureLetters);
        }

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (SetProperty(ref _currentCulture, value, null))
                {
                    _currentCulture = value;
                    SetLocale(_currentCulture);

                    Preferences.Set(LanguagePreference, _currentCulture.TwoLetterISOLanguageName);
                }
            }
        }

        public string this[string key] => AppResources.ResourceManager.GetString(key, CurrentCulture) ?? key.ToUpper();

        public static void Initialize()
        {
            if (_instance == null)
            {
                _instance = new LocalizationResourceManager();
            }
        }

        private void SetLocale(CultureInfo ci)
        {
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            foreach (var thread in Process.GetCurrentProcess().Threads.OfType<Thread>())
            {
                thread.CurrentCulture = ci;
                thread.CurrentUICulture = ci;
            }
        }
    }
}
