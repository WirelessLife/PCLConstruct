using PCLConstruct.Client.Security;
using PCLConstruct.Client.Services;
using PCLConstruct.Client.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PCLConstruct.Client.ViewModels
{
    public class PinAuthViewModel : INotifyPropertyChanged
    {
        private string _mainText;
        private string _pinNumber;
        INavigation nav;
        public PinAuthViewModel(INavigation nav)
        {
            this.nav = nav;
            MainText = "Please pass this moblie device back to the administrator.";
        }

        ICommand authenticatePin;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand AuthenticatePinCommand =>
            authenticatePin ??
            (authenticatePin = new Command(async () => await ExecutePinCheck()));

        public string MainText
        {
            get
            {
                return _mainText;
            }

            set
            {
                _mainText = value;
                OnPropertyChanged();
            }
        }

        public string PinNumber
        {
            get
            {
                return _pinNumber;
            }

            set
            {
                _pinNumber = value;
            }
        }

        private async Task ExecutePinCheck()
        {
            Login();

        }

        private bool _ShowButton = true;
        public bool ShowButton
        {
            get
            {
                return _ShowButton;
            }
            set { _ShowButton = value; OnPropertyChanged(); }
        }

        private bool _ShowMessage = false;
        public bool ShowMessage
        {
            get
            {
                return _ShowMessage;
            }
            set { _ShowMessage = value; OnPropertyChanged(); }
        }


        public void Login()
        {
            ShowMessage = true;
            ShowButton = false;

            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(100);
                var result = await DataService.Default.MfAuthenticateUser();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var currentApp = Application.Current as App;
                    if (result)
                    {
                        //jump to next page here
                        await this.nav.PopModalAsync();
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        var answer = await currentApp.MainPage.DisplayAlert("Error", "Phone authentication failed, do you want to try again?", "Yes", "Login using password");
                        // auth failed
                        if (answer == true)
                        {
                            Login();
                        }
                        else
                        {
                            currentApp.Init();
                            currentApp.StartAuth();
                        }
                    }
                });
            });
        }
    }
}
