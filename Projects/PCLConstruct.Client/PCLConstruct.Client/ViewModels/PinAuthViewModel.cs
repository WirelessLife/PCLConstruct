using PCLConstruct.Client.Security;
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

        public PinAuthViewModel()
        {
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

        public async void Login()
        {
            MultiFactorAuth mfauth = new MultiFactorAuth();
            var currentApp = Application.Current as App;
            if (mfauth.MfAuthenticateUser(currentApp.auth))
            {
                //jump to next page here
                currentApp.MainPage = new CraftWorkerArrivalList(currentApp.auth.UserName);
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
        }
    }
}
