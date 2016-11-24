using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;
using Newtonsoft.Json;

using Xamarin.Forms;
using PCLConstruct.Client.Views;

namespace PCLConstruct.Client
{
    public partial class FormSelectionPage : ContentPage
    {
        public ObservableCollection<Form> forms;
        public FormSelectionPage(CraftWorker worker)
        {
            InitializeComponent();

            // Set the title
            this.Title = String.Format("{0} {1}'s Forms", worker.FirstName, worker.LastName);

            // Until we have a rest service to hit...
            string jsonStr = "[{\n    \"name\": \"Personnel Action Forms\",\n    \"id\": \"1\",\n    \"description\": \"\",\n    \"sections\": [{\n        \"text\": \"Employee Information\",\n        \"fields\": [{\n            \"id\": 1,\n            \"text\": \"Employee SIN #\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 9,\n            \"max\": 9\n        }, {\n            \"id\": 2,\n            \"text\": \"Employee #\",\n            \"type\": \"number\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 6\n        }, {\n            \"id\": 3,\n            \"text\": \"First Name\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n        }, {\n            \"id\": 40,\n            \"text\": \"Middle Initial\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 10\n        }, {\n            \"id\": 4,\n            \"text\": \"Last Name\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n        }, {\n            \"id\": 5,\n            \"text\": \"Maritial Status\",\n            \"type\": \"radio\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"options\": [\n                \"Married\",\n                \"Single\",\n                \"Common-Law\"\n            ]\n        }, {\n            \"id\": 6,\n            \"text\": \"Date of Birth\",\n            \"type\": \"date\",\n            \"placeholder\": \"\",\n            \"value\": \"\"\n        }, {\n            \"id\": 7,\n            \"text\": \"Have you previously worked under the Temporary Foreign Worker program with the PCL family of companies?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\"\n        }]\n    }, {\n        \"text\": \"Employee Address Information\",\n        \"fields\": [{\n            \"id\": 8,\n            \"text\": \"Address\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }, {\n            \"id\": 9,\n            \"text\": \"City\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }, {\n            \"id\": 10,\n            \"text\": \"Province\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n        }, {\n            \"id\": 11,\n            \"text\": \"Postal Code\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 6\n        }]\n    }]\n\n}, {\n    \"name\": \"Consent for the Collection, Use and Disclosure of Personal Information\",\n    \"id\": \"2\",\n    \"description\": \"\",\n    \"sections\": [{\n        \"text\": \"\",\n        \"fields\": [{\n            \"id\": 1,\n            \"text\": \"Name\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n        }, {\n            \"id\": 2,\n            \"text\": \"Signature\",\n            \"type\": \"text\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 255\n        }, {\n            \"id\": 3,\n            \"text\": \"SIN\",\n            \"type\": \"number\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 9\n        }, {\n            \"id\": 4,\n            \"text\": \"Date of Birth\",\n            \"type\": \"date\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 10\n        }]\n    }, {\n        \"text\": \"Journeyman/Apprentice Checklist\",\n        \"fields\": [{\n            \"id\": 5,\n            \"text\": \"Is this person a Journeyman in your province?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }, {\n            \"id\": 6,\n            \"text\": \"Does this person's certificate have a Red Seal?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }, {\n            \"id\": 7,\n            \"text\": \"Is this person a current (active) Apprentice in your province?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }, {\n            \"id\": 8,\n            \"text\": \"Is this Apprentice allowed to use employment hours from Alberta towards his Apprenticeship in the province?\",\n            \"type\": \"boolean\",\n            \"placeholder\": \"\",\n            \"value\": \"\",\n            \"min\": 1,\n            \"max\": 100\n        }]\n    }]\n\n}]";
            forms = JsonConvert.DeserializeObject<ObservableCollection<Form>>(jsonStr);
            
            lstForms.ItemsSource = this.forms;
            lstForms.BindingContext = this;

            // Bind item taps to forward to the form rendering page
            lstForms.ItemTapped += (sender, args) => { onFormSelected((Form)args.Item); };

            // Bind the submit button
            btnSubmit.Clicked += (sender, args) => {
                string jsonToSave = JsonConvert.SerializeObject(forms);

                // submit/save/whatever
                string foo = "bar";

                //if save success, jump to the pin auth page.

                Navigation.PushAsync(
                   new PinAuthView()
               );
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async Task onFormSelected(Form tappedForm){
            Form formInList = forms.FirstOrDefault(f => f.id == tappedForm.id);
            tappedForm.status = Controls.FormStatus.InProgress;
          
            await Navigation.PushAsync(new FormViewer(tappedForm));
        }
    }
}
