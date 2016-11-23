using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PCLConstruct.Client
{
    public class App : Application
    {
        public App()
        {
            //// The root page of your application
            //var content = new ContentPage
            //{
            //    Title = "PCLConstruct.Client",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new ListView
            //            {

            //            }

            //        }
            //    }
            //};

            //MainPage = new NavigationPage(content);

            MainPage = new NavigationPage(new FormSelectionPage());
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
