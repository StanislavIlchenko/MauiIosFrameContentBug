namespace CollectionViewPopupTest.Interfaces
{
    public interface IPopupDialogService
    {
        Task ShowPopup(View view);
        Task ClosePopup();
    }
}
