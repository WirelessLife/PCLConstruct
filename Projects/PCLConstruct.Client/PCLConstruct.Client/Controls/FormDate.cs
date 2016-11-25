using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLConstruct.Client.Helpers.DTO;
using PCLConstruct.Client.Controls.Interfaces;

namespace PCLConstruct.Client.Controls
{
    class FormDate : DatePicker, IValidatable
    {
        public Field field { get; set; }
        public FormLabel label { get; set; }
        public bool isValid { get; set; }
        public bool isFilled
        {
            get
            {
                return field.Required && this.Date != null;
            }
        }
        public FormDate(Field field, FormLabel associatedLabel)
        {
            this.label = associatedLabel;
            this.field = field;
            this.Margin = new Thickness(0,0,0,10);
        }

        public void evaluateValidity()
        {
            //debug purposes
            isValid = true;
        }
    }
}
