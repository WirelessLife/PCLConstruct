using PCLConstruct.Client.Security;
using PCLConstruct.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PCLConstruct.Client.Views
{
    public partial class PinAuthView : ContentPage
    {
        public PinAuthView(AzureADAuth azureauth)
        {
            InitializeComponent();
            BindingContext = new PinAuthViewModel(azureauth);
        }
    }
}
