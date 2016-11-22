using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;

using Xamarin.Forms;

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
            foreach (Section section in form.sections)
            {
                Label lblSection = new Label();
                lblSection.Text = section.text;


                layout.Children.Add(lblSection);


            }


            FormContent.Content = layout;
        }
    }
}
