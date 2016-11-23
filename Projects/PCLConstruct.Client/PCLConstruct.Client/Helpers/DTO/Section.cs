using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLConstruct.Client.Helpers.DTO
{
    public class Section
    {
        public string text { get; set; }
        public List<Field> fields { get; set; }
    }
}
