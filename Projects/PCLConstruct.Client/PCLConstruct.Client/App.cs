using PCLConstruct.Client.Security;
using PCLConstruct.Client.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PCLConstruct.Client
{
    public class App : Application
    {
        public AzureADAuth auth = new AzureADAuth();

        public App()
        {

            Init();
        }

        public void Init()
        {
           // auth.ClearCache();
            ContentPage content = new ContentPage
            {
                Title = "PCL Electronic Onboarding",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new ActivityIndicator()
                        {
                            IsRunning = true,
                            Color = Color.Black
                        }
                    }
                }
            };
            MainPage = content;
        }

        protected override void OnStart()
        {
            StartAuth();
        }

        public void StartAuth()
        {
            auth.UserAuthenticated += OnUserAuthenticated;
            auth.AuthenticateUser();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            auth.UserAuthenticated -= OnUserAuthenticated;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            auth.UserAuthenticated += OnUserAuthenticated;
        }

        public void OnUserAuthenticated(object sender, EventArgs e)
        {
            MainPage = new NavigationPage(new CraftWorkerArrivalList(auth));
            //MainPage = new NavigationPage(new PinAuthView(auth));
        }

        /// <summary>
        /// This Function is assigned to when the hardware button needs to be handled in code
        /// by the Views or ViewModels. It should mirror what the back/cancel button does in
        /// iOS.
        /// </summary>
        /// <returns>
        /// Three state (nullable) boolean:
        ///  - true  => Complete navigation as normal
        ///  - false => Do not navigate
        ///  - null  => Exit application (Used on screens that limit access to the app)
        /// </returns>
        public static Func<Task<bool?>> HardwareBackPressed
        {
            private get;
            set;
        }

        /// <summary>
        /// This function is used at the platform level when a hardware back button is pressed.
        /// On occasion we want to prevent/confirm backwards navigation or have the views/viewmodels
        /// perform an action on exit. Since iOS handles this without a hardware button, iOS will not
        /// use this method, but Android and WinPhone may both have hardware buttons that need to be
        /// handled.
        /// </summary>
        /// <returns>
        /// Three state (nullable) boolean:
        ///  - true  => Complete navigation as normal
        ///  - false => Do not navigate
        ///  - null  => Exit application (Used primarily on SignInScreen)
        /// </returns>
        public static async Task<bool?> CallHardwareBackPressed()
        {
            Func<Task<bool?>> backPressed = HardwareBackPressed;
            if (backPressed != null)
            {
                return await backPressed();
            }

            return true;
        }
    }
}
