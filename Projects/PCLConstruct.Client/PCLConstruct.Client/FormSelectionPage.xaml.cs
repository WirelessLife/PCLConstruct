using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace PCLConstruct.Client
{
    public partial class FormSelectionPage : ContentPage
    {
        public ObservableCollection<Form> forms;
        public FormSelectionPage()
        {
            InitializeComponent();

            this.Title = "John Doe's Forms";


            // Until we have a rest service to hit
            string dummyFile = "PCLConstruct.Client.iOS.dummyForms.json";
            Device.OnPlatform(Android: () =>
             {
                 dummyFile = "PCLConstruct.Client.Droid.dummyForms.json";
             });

            string jsonStr = "[\n  {\n    \"name\": \"Personnel Action Form\",\n    \"id\": \"\",\n    \"description\": \"\",\n    \"sections\": [\n      {\n        \"text\":  \"Employee Information\",\n        \"fields\": [\n          {\n            \"id\": 1,\n            \"text\": \"Employee SIN #\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 9,\n            \"max\": 9\n          },\n          {\n            \"id\": 2,\n            \"text\": \"Employee #\",\n            \"type\": \"number\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 6\n          },\n          {\n            \"id\": 3,\n            \"text\": \"First Name\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n          },\n          {\n            \"id\": 3,\n            \"text\": \"Middle Initial\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 0,\n            \"max\": 10\n          },\n          {\n            \"id\": 4,\n            \"text\": \"Last Name\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n          },\n          {\n            \"id\": 5,\n            \"text\": \"Maritial Status\",\n            \"type\": \"radio\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"options\": [\n              \"Married\",\n              \"Single\",\n              \"Common-Law\"\n            ]\n          },\n          {\n            \"id\": 6,\n            \"text\": \"Date of Birth\",\n            \"type\": \"date\",\n            \"placeholder\": \"\",\n            \"value\": \"\"\n          },\n          {\n            \"id\": 7,\n            \"text\": \"Have you previously worked under the Temporary Foreign Worker program with the PCL family of companies?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\"\n          }\n        ]\n      }\n    ]\n  }\n]";
            forms = JsonConvert.DeserializeObject<ObservableCollection<Form>>(jsonStr);
            
            lstForms.ItemsSource = this.forms;
            lstForms.BindingContext = this;

            // Bind item presses to forward to the form display page
            lstForms.ItemTapped += (sender, args) => { onFormSelected((Form)args.Item); };
        }

        protected override void OnAppearing()
        {
            //Task.Factory.StartNew(async () =>
            //{
            //    await Task.Delay(500);
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        lstForms.ItemsSource = null;
            //        lstForms.ItemsSource = forms;
            //    });
            //});

            base.OnAppearing();
        }

        private async Task onFormSelected(Form tappedForm){
            Form formInList = forms.FirstOrDefault(f => f.id == tappedForm.id);
            tappedForm.status = Controls.FormStatus.InProgress;
          
            await Navigation.PushAsync(new FormViewer(tappedForm));
        }
    }
}
