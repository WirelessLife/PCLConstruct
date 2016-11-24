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
        FormSelectionPage selectionpage;
        public PinAuthView()
        {
            InitializeComponent();
            //NavigationPage.SetHasBackButton(this, false);
            //Navigation.PushAsync(previousPage);
            //selectionpage = previousPage;
            BindingContext = new PinAuthViewModel();
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    return true;
        //}
        protected override void OnAppearing()
        {
            // Navigation.RemovePage(selectionpage);
            // Navigation.NavigationStack.de
            //var existingPages = Navigation.NavigationStack.ToList();
            //foreach (var p in existingPages)
            //{
            //    if (p is FormSelectionPage)
            //    {
            //        Navigation.RemovePage(p);
            //    }
            //}
            //MovePage();
        }

        public async void MovePage()
        {
            await Navigation.PopToRootAsync();
            //await Navigation.PushAsync(selectionpage);
            //await Navigation.PushAsync(this);
            //(new EventArgs());
        }
        protected virtual void PageRemoted(EventArgs e)
        {

            //Navigation.InsertPageBefore(this, selectionpage);
        }


    }
}
