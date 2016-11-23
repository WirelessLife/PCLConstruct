﻿using PCLConstruct.Client.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //AzureADAuth auth = new AzureADAuth();
            //auth.AuthenticateUser(MainPage);
            AzureADAuth auth = new AzureADAuth();
            auth.ClearCache();
        }

        protected override void OnStart()
        {
            AzureADAuth auth = new AzureADAuth();
            auth.AuthenticateUser();

            
            //if (string.IsNullOrEmpty(auth.authResult.AccessToken))
            //{
           //     MainPage.DisplayAlert("Error", "Failed to get Token", "OK");
           // }

            //AzureADAuth auth = new AzureADAuth();
            //auth.ClearCache();
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
