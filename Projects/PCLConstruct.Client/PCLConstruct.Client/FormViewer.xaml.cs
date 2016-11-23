using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;

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
                    FormLabel lblText = new FormLabel();
                    lblText.Text = field.text;
                    layout.Children.Add(lblText);

                    //create field
                    switch (field.type)
                    {
                        case "text":
                            FormEntry entText = new FormEntry();
                            layout.Children.Add(entText);
                            entText.ClassId = field.id.ToString();
                            break;
                        case "number":
                            FormEntry entNumber = new FormEntry
                            {
                                Placeholder = "",
                                Keyboard = Keyboard.Numeric,
                                ClassId = field.id.ToString()
                            };
                            layout.Children.Add(entNumber);
                            break;
                        case "radio":
                            FormDropDownList entPicker = new FormDropDownList
                            {
                                Title = "Select...",
                                ClassId = field.id.ToString()
                            };

                            foreach (string pickeritem in field.options)
                            {
                                entPicker.Items.Add(pickeritem);
                            }

                            layout.Children.Add(entPicker);
                            break;
                        case "date":
                            FormDate entDate = new FormDate
                            {
                                Format = "MMMM dd, yyyy",
                                ClassId = field.id.ToString()
                            };
                            layout.Children.Add(entDate);
                            break;
                        case "boolean":
                            FormBoolean entToggle = new FormBoolean
                            {
                                ClassId = field.id.ToString()
                            };
                            layout.Children.Add(entToggle);
                            break;
                    }


                }
            }
            FormContent.Content = layout;

            // Bind the Help and Complete buttons
            btnHelp.Clicked += (sender, args) => {
                //TODO
            };

            btnComplete.Clicked += (sender, args) => {
                this.form.status = FormStatus.Complete;
                Navigation.RemovePage(this);
            };
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
