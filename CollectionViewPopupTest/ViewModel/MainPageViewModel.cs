using CollectionViewPopupTest.Interfaces;
using CollectionViewPopupTest.Pages.Popups;

namespace CollectionViewPopupTest.ViewModel
{
    public class MainPageViewModel
    {
        private readonly IPopupDialogService _popupDialogService;

        public Command ShowCollectionView { get; set; }
        public Command SelectLanguageCommand { get; set; }

        public Command SelectLanguageCommand_CollectionView { get; set; }

        public MainPageViewModel(IPopupDialogService popupDialogService) 
        {
            _popupDialogService = popupDialogService;
            ShowCollectionView = new Command(ShowCollectionViewPopup);
            SelectLanguageCommand = new Command(ShowSelectLanguagePopup);
            SelectLanguageCommand_CollectionView = new Command(ShowSelectLanguagePopup_CollectionView);
        }

        private void ShowCollectionViewPopup()
        {
            var collectionView = new CollectionViewPopup();
            var viewModel = new TestViewModel();
            collectionView.BindingContext = viewModel;

            _popupDialogService.ShowPopup(collectionView);
        }

        private void ShowSelectLanguagePopup()
        {
            var languagesViewModel = new LanguageSelectPopupViewModel(_popupDialogService, Localization.AppResources.CurrentLanguage);
            var view = new LanguageSelectPopup();
            view.BindingContext = languagesViewModel;

            _popupDialogService.ShowPopup(view);
        }

        private void ShowSelectLanguagePopup_CollectionView()
        {
            var languagesViewModel = new LanguageSelectPopupViewModel(_popupDialogService, Localization.AppResources.CurrentLanguage);
            var view = new LanguageSelectPopup_CollectionView();
            view.BindingContext = languagesViewModel;

            _popupDialogService.ShowPopup(view);
        }
    }
}
