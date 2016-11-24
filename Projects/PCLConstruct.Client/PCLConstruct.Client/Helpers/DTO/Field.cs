using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLConstruct.Client.Helpers.DTO
{
    public class Field
    {
        public int id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string placeholder { get; set; }
        public string value { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public List<string> options { get; set; }

        public bool Required { get; set; }

    }
}
