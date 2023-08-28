using CollectionViewPopupTest.Interfaces;

namespace CollectionViewPopupTest.Services
{
    public class PopupDialogService : IPopupDialogService
    {
        public async Task ClosePopup()
        {
            var rootPage = GetRootPage();
            if (rootPage != null)
            {
                await rootPage.ClosePopup();
            }
        }

        public async Task ShowPopup(View view)
        {
            var rootPage = GetRootPage();
            if(rootPage != null) 
            {
                await rootPage.ShowPopup(view);
            }
        }

        private static IRootPage? GetRootPage()
        {
            return App.Current.MainPage as IRootPage;
        }
    }
}
