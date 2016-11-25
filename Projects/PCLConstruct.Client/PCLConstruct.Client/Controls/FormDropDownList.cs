using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLConstruct.Client.Helpers.DTO;
using PCLConstruct.Client.Controls.Interfaces;
using PCLConstruct.Client.Controls.Behaviors;

namespace PCLConstruct.Client.Controls
{
    public class FormDropDownList : Picker, IValidatable
    {
        public Field field { get; set; }
        public FormLabel label { get; set; }
        public bool isValid { get; set; }
        public bool isFilled
        {
            get
            {
                return field.Required && this.SelectedIndex > -1;
            }
        }
        public FormDropDownList(Field field, FormLabel associatedLabel)
        {
            this.label = associatedLabel;
            this.field = field;
            this.Margin = new Thickness(0, 0, 0, 10);
            this.Behaviors.Add(new FormEntryBehavior.DropDownListBehavior());
        }

        public void evaluateValidity()
        {
            isValid = (!field.Required || (field.Required && isFilled));
            Color labelAndTextColor = isValid ? Color.Default : Color.Red;
            this.TextColor = labelAndTextColor;
            this.label.TextColor = labelAndTextColor;
        }
    }
}
