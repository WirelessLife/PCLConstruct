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
    public class FormLabel : Label, IValidatable
    {
        public Field field { get; set; }
        public FormLabel label { get; set; }
        public bool isValid { get; set; }
        public bool isFilled
        {
            get {
                // it's a label. Don't worry about it
                return true;
            }
        }
        public FormLabel(Field field)
        {
            this.field = field;

            // Append a colon
            this.Text += ":";

            // Style modifications
        }

        public void evaluateValidity()
        {
            // It's a label
            isValid = true;
        }
    }
}
