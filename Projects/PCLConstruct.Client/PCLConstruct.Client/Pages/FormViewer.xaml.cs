using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;
using PCLConstruct.Client.Controls.Interfaces;
using Xamarin.Forms;
using PCLConstruct.Client.Controls;

namespace PCLConstruct.Client
{
    public partial class FormViewer : ContentPage
    {

        private Form form;
        private StackLayout layout;

        public FormViewer(Form form)
        {
            this.form = form;
            InitializeComponent();

            this.Title = form.name;

            layout = new StackLayout();
            layout.Orientation = StackOrientation.Vertical;

            foreach (Section section in form.sections)
            {
                FormSectionLabel lblSection = new FormSectionLabel();
                lblSection.Text = section.text;

                layout.Children.Add(lblSection);

                //loop through each child control inside the section
                foreach (Field field in section.fields)
                {
                    //create label
                    FormLabel lblText = new FormLabel(field);
                    lblText.Text = field.text;
                    layout.Children.Add(lblText);

                    //create field
                    switch (field.type)
                    {
                        case "text":
                            FormEntry entText = new FormEntry(field, lblText);
                            layout.Children.Add(entText);
                            entText.ClassId = field.id.ToString();
                            if(field.value != null && !String.IsNullOrWhiteSpace(field.value))
                                entText.Text = field.value;
                            break;
                        case "number":
                            FormEntry entNumber = new FormEntry(field, lblText)
                            {
                                Placeholder = "",
                                Keyboard = Keyboard.Numeric,
                                ClassId = field.id.ToString()
                            };
                            if (field.value != null && !String.IsNullOrWhiteSpace(field.value))
                                entNumber.Text = field.value;
                            layout.Children.Add(entNumber);
                            break;
                        case "radio":
                            FormDropDownList entPicker = new FormDropDownList(field, lblText)
                            {
                                Title = "Select...",
                                ClassId = field.id.ToString()
                            };

                            foreach (string pickeritem in field.options)
                            {
                                entPicker.Items.Add(pickeritem);
                            }

                            if (field.value != null && !String.IsNullOrWhiteSpace(field.value))
                                entPicker.SelectedIndex = entPicker.Items.IndexOf(entPicker.Items.FirstOrDefault(i => i.ToString() == field.value));

                            layout.Children.Add(entPicker);
                            break;
                        case "date":
                            FormDate entDate = new FormDate(field, lblText)
                            {
                                Format = "MMMM dd, yyyy",
                                ClassId = field.id.ToString()
                            };
                            if (field.value != null && !String.IsNullOrWhiteSpace(field.value))
                                entDate.Date = DateTime.Parse(field.value);
                            layout.Children.Add(entDate);
                            break;
                        case "boolean":
                            FormBoolean entToggle = new FormBoolean(field, lblText)
                            {
                                ClassId = field.id.ToString()
                            };

                            if (field.value != null && !String.IsNullOrWhiteSpace(field.value))
                                entToggle.IsToggled = field.value.Trim().ToLower() == "true";
                           
                            layout.Children.Add(entToggle);
                            break;
                    }


                }
            }
            FormContent.Content = layout;

            // Bind the Help and Complete buttons
            btnHelp.Clicked += (sender, args) => {
                DisplayAlert("Help", "You have been alerted", "OK","Cancel");
            };

            btnComplete.Clicked += (sender, args) =>
            {
                // Check that all required fields are valid    
                if (AreAllFieldsValid())
                {
                    this.form.status = FormStatus.Complete;
                    Navigation.PopAsync();
                }
                else {
                    DisplayAlert("Form Invalid", "This form could not be marked as complete because there was invalid data entered", "Ok");
                }
                

            };
        }

        private bool AreAllFieldsValid() {
            bool allValid = true;

            foreach (IValidatable validatableControl in layout.Children.Where(child => child is IValidatable))
            {
                validatableControl.evaluateValidity();
                if (!validatableControl.isValid)
                {
                    allValid = false;
                }
            }

            return allValid;
        }

        protected override void OnDisappearing() {
            // On the page going away, push the dynamic field values back to the form that was passed in
            foreach (View control in layout.Children) {
                if (!String.IsNullOrEmpty(control.ClassId)) {
                    int fieldId = Int32.Parse(control.ClassId);
                    // Update that field in the form we're modifying

                    // Look in all sections
                    foreach (Section section in form.sections)
                    {
                        // For fields with matching field IDs
                        Field field = section.fields.FirstOrDefault(f => f.id == fieldId);
                        if (field == null)
                        {
                            continue;
                        }
                        // And based on their type, fetch the current value from the UI and update the form model with it
                        switch (field.type)
                        {
                            case "text":
                                field.value = ((FormEntry)control).Text;
                                break;
                            case "number":
                                field.value = ((FormEntry)control).Text;
                                break;
                            case "radio":
                                int selectedIndex = ((FormDropDownList)control).SelectedIndex;
                                if (selectedIndex > -1)
                                {
                                    field.value = ((FormDropDownList)control).Items[selectedIndex].ToString();
                                }
                                break;
                            case "date":
                                field.value = ((FormDate)control).Date.ToString();
                                break;
                            case "boolean":
                                field.value = ((FormBoolean)control).IsToggled.ToString();
                                break;
                        }
                    }
                }
            }   
        }
    }
}
