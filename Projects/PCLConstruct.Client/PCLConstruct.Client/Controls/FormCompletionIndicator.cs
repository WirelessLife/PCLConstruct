using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCLConstruct.Client.Controls
{
    public enum FormStatus {
       Nothing,
       Incomplete,
       Complete,
       InProgress
    }
    public class FormCompletionIndicator : ContentView
    {
        private Label indicator;


        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
    propertyName: nameof(Status),
    returnType: typeof(FormStatus),
    declaringType: typeof(FormCompletionIndicator),
    defaultValue: FormStatus.Nothing,
    propertyChanged: (obj, oldValue, newValue)=>
    {
        var fci = obj as FormCompletionIndicator;
        fci.refreshStatus();
    });

        public FormStatus Status
        {
            get
            {
                var ret = GetValue(StatusProperty);
                return ret == null ? FormStatus.Nothing : (FormStatus)ret;
            }
            set
            {
                SetValue(StatusProperty, value);
            }
        }

        public FormCompletionIndicator() {
            indicator = new Label();
            this.Content = indicator;
            refreshStatus();
        }

        private void refreshStatus() {
            switch (Status)
            {
                case FormStatus.Complete:
                    // set image to green
                    indicator.Text = "Complete";
                    break;

                case FormStatus.InProgress:
                    // set image to yellow
                    indicator.Text = "In Progress";
                    break;

                case FormStatus.Incomplete:
                    // set image to red
                    indicator.Text = "Incomplete";
                    break;

                case FormStatus.Nothing:
                    // set image to red
                    indicator.Text = "[nothing]";
                    break;

                default:
                    // set image to empty
                    indicator.Text = "";
                    break;
            }
        }


    }
}
