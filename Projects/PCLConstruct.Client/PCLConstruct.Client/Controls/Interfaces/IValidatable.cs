using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Helpers.DTO;

namespace PCLConstruct.Client.Controls.Interfaces
{
    interface IValidatable
    {
        Field field { get; set; }
        FormLabel label { get; set; }
        bool isValid { get; set; }
        void evaluateValidity();
    }
}
