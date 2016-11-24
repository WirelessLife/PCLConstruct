using PCLConstruct.Client.Security;
using PCLConstruct.Client.Views;
using System;

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

            //if (string.IsNullOrEmpty(auth.authResult.AccessToken))
            //{
            //     MainPage.DisplayAlert("Error", "Failed to get Token", "OK");
            // }

            //AzureADAuth auth = new AzureADAuth();
            //auth.ClearCache();
            // Handle when your app starts
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
            MainPage = new NavigationPage(new CraftWorkerArrivalList(auth.UserName));
            //MainPage = new NavigationPage(new PinAuthView(auth));
        }
    }
}
