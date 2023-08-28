namespace CollectionViewPopupTest.Interfaces
{
    public interface IRootPage
    {
        Task ShowPopup(View popup);
        Task ClosePopup();
    }
}
