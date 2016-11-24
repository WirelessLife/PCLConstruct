using PCLConstruct.Client.Security;
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

        public AzureADAuth auth;

        public PinAuthViewModel(AzureADAuth azureauth)
        {
            MainText = "Please pass this moblie device back to the administrator.";
            auth = azureauth;
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
            //if (PinNumber != "123456")
            //{
            //    MainText = "Incorrect Pin Number";
            //}
            //else
            //{
            //    MainText = "Pin Number Authenticated.";
            //}

            MultiFactorAuth mfauth = new MultiFactorAuth();
            mfauth.MfAuthenticateUser(auth);
        }
    }
}
