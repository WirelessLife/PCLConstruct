using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCLConstruct.Client.Controls
{
    public class FormEntry :Entry
    {
        public FormEntry() {
            // Style modifications
            this.Margin = new Thickness(0, 0, 0, 10);
        }
    }
}
