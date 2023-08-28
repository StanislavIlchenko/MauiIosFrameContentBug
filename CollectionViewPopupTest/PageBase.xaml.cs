using CollectionViewPopupTest.Interfaces;

namespace CollectionViewPopupTest;

public partial class PageBase : ContentPage
{
    #region BindableProperties

    public static readonly BindableProperty PopupViewProperty = BindableProperty.Create(nameof(PopupView), typeof(View), typeof(PageBase));

    #endregion

    #region Properties

    public View? PopupView
    {
        get => GetValue(PopupViewProperty) as View;
        set => SetValue(PopupViewProperty, value);
    }

    #endregion

    public PageBase()
    {
        InitializeComponent();
    }

    protected void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        App.Current?.ServiceProvider?.GetService<IPopupDialogService>()?.ClosePopup();
    }
}