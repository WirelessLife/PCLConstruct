using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCLConstruct.Client.Controls
{
    public class FormSectionLabel : Label
    {
        public FormSectionLabel() {
            // Style modifications
            this.FontAttributes = Xamarin.Forms.FontAttributes.Bold;
            this.FontSize = 20;
            this.Margin = new Thickness(0,0,0,10);
        }
    }
}
