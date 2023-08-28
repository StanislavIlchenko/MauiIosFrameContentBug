using CollectionViewPopupTest.Interfaces;
using CollectionViewPopupTest.Pages;
using CollectionViewPopupTest.ViewModel;

namespace CollectionViewPopupTest;

public partial class App : Application
{

	public static new App Current => Application.Current as App;
    public IServiceProvider ServiceProvider { get; }

    public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

        ServiceProvider = serviceProvider;
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
        var navigationPage = new NavigationPageBase();
        MainPage = navigationPage;

        var result = base.CreateWindow(activationState);

        var popupService = ServiceProvider.GetService<IPopupDialogService>();
        var mainViewModel = new MainPageViewModel(popupService);
        var mainPage = new MainPage();
        mainPage.BindingContext = mainViewModel;

        navigationPage.Navigation.PushAsync(mainPage);  
        
        return result;
    }
}
