using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLConstruct.Client.Helpers.DTO
{
    public class Form
    {
        public string name { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public List<Section> sections { get; set; }
    }
}
