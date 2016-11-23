using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCLConstruct.Client.Controls
{
    public class FormLabel : Label
    {
        public FormLabel() {
            // Append a colon
            this.Text += ":";

            // Style modifications
        }
    }
}
