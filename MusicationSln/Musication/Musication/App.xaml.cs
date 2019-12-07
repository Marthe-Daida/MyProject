using Prism;
using Prism.Ioc;
using Musication.ViewModels;
using Musication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Musication.Services.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Musication
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainView/NavigationPage/MapsView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISecurityService, SecurityService>();
            containerRegistry.RegisterSingleton<IContentPackage, ZipContentPackage>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
         //   containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MapsView, MapsViewViewModel>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewViewModel>();
            containerRegistry.RegisterForNavigation<ViewPdf, ViewPdfViewViewModel>();
            containerRegistry.RegisterForNavigation<SignUp, SignUpViewModel>(); 
            containerRegistry.RegisterForNavigation<EmbeddedHtmlView, EmbeddedHtmlViewViewModel>();
        }
    }
}
