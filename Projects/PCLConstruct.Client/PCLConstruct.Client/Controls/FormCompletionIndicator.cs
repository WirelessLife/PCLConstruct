using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCLConstruct.Client.Controls
{
    public enum FormStatus
    {
        NotStarted,
        Complete,
        InProgress
    }
    public class FormCompletionIndicator : ContentView
    {
        private Image indicator;


        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
            propertyName: nameof(Status),
            returnType: typeof(FormStatus),
            declaringType: typeof(FormCompletionIndicator),
            defaultValue: FormStatus.NotStarted,
            propertyChanged: (obj, oldValue, newValue) =>
            {
                var fci = obj as FormCompletionIndicator;
                fci.refreshStatus();
            }
        );

        public FormStatus Status
        {
            get
            {
                var ret = GetValue(StatusProperty);
                return ret == null ? FormStatus.NotStarted : (FormStatus)ret;
            }
            set
            {
                SetValue(StatusProperty, value);
            }
        }

        public FormCompletionIndicator()
        {
            indicator = new Image() {
                WidthRequest = 32,
                HeightRequest = 32
            };
            this.Content = indicator;
            refreshStatus();
        }

        private void refreshStatus()
        {
            switch (Status)
            {
                case FormStatus.Complete:
                    indicator.Source = "Completed.png";
                    break;

                case FormStatus.InProgress:
                    indicator.Source = "Incompleted.png";
                    break;

                case FormStatus.NotStarted:
                    indicator.Source = "NotStarted.png";
                    break;

                default:
                    break;
            }
        }


    }
}
