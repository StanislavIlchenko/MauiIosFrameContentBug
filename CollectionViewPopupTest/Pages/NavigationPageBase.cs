using CollectionViewPopupTest.Interfaces;

namespace CollectionViewPopupTest.Pages
{
    public class NavigationPageBase : NavigationPage, IRootPage
    {
        public NavigationPageBase() { }

        public async Task ShowPopup(View popup)
        {
            var currentPage = this.Navigation.NavigationStack.LastOrDefault() as PageBase;
            if (currentPage != null)
            {
                currentPage.PopupView = popup;
            }
        }

        public async Task ClosePopup()
        {
            var currentPage = this.Navigation.NavigationStack.LastOrDefault() as PageBase;
            var popup = currentPage?.PopupView;
            if (currentPage != null && popup != null)
            {
                currentPage.PopupView = null;
            }
        }
    }
}
