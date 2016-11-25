using PCLConstruct.Client.Controls.Behaviors;
using PCLConstruct.Client.Helpers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLConstruct.Client.Controls.Interfaces;

namespace PCLConstruct.Client.Controls
{
    public class FormEntry : Entry, IValidatable
    {
        public Field field { get; set; }
        public FormLabel label { get; set; }
        public bool isValid { get; set; }
        public bool isFilled
        {
            get
            {
                return field.Required && !String.IsNullOrWhiteSpace(this.Text);
            }
        }

        public FormEntry(Field field, FormLabel associatedLabel)
        {
            this.label = associatedLabel;
            this.field = field;

            // Style modifications
            this.Margin = new Thickness(0, 0, 0, 10);

            // Assign a validation behavioour
            this.Behaviors.Add(new FormEntryBehavior.TextBehavior());
            this.Unfocused += (s,a) => { evaluateValidity(); };
        }

        public void evaluateValidity() {
            switch (field.type) {
                case "number":
                    double result;
                    isValid = (!field.Required || (field.Required && isFilled && double.TryParse(this.Text, out result)));
                    // also check min max etc
                    break;
                case "text":
                    // check regex, etc, minmax, etc
                    //default for now
                    isValid = (!field.Required || (field.Required && isFilled));
                    break;
            }

            Color labelAndTextColor = isValid ? Color.Default : Color.Red;
            this.TextColor = labelAndTextColor;
            this.label.TextColor = labelAndTextColor;
        }
    }

}
