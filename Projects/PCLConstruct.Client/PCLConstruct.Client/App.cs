using Xamarin.Forms;

namespace PCLConstruct.Client
{
    public class App : Application
    {
        public App()
        {
            Button CraftWorkerArrivalNavButton = new Button
            {
                Text = "Go to Craft Worker Arrival List",
            };

            CraftWorkerArrivalNavButton.Clicked += (sender, args) =>
            {
                MainPage.Navigation.PushAsync(new CraftWorkerArrivalList());
            };

            // The root page of your application
            var content = new ContentPage
            {
                Title = "PCLConstruct.Client",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                        CraftWorkerArrivalNavButton
                    }
                }
            };

            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
