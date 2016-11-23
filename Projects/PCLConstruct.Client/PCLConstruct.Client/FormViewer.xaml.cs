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

        private object form;
        public FormViewer(Form form)
        {
            this.form = form;
            InitializeComponent();

            this.Title = form.name;

            StackLayout layout = new StackLayout();
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
                            break;
                        case "number":
                            FormEntry entNumber = new FormEntry
                            {
                                Placeholder = "",
                                Keyboard = Keyboard.Numeric
                            };
                            layout.Children.Add(entNumber);
                            break;
                        case "radio":
                            FormDropDownList entPicker = new FormDropDownList
                            {
                                Title = "Select..."
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
                                Format = "MMMM dd, yyyy"
                            };
                            layout.Children.Add(entDate);
                            break;
                        case "boolean":
                            FormBoolean entToggle = new FormBoolean
                            {

                            };
                            layout.Children.Add(entToggle);
                            break;
                    }


                }


            }


            FormContent.Content = layout;
        }
    }
}
