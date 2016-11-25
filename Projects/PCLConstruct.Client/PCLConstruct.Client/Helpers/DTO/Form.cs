using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLConstruct.Client.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PCLConstruct.Client.Helpers.DTO
{
    public class Form : INotifyPropertyChanged
    {
       
        public string Id { get; set; }
        //public string description { get; set; }

        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; OnPropertyChanged();
            }
        }

        public string Data { get; set; }

        public string Status { get; set; }

        List<Section> _sections;
        public List<Section> sections
        {
            get { return _sections; }
            set
            {
                _sections = value; OnPropertyChanged();
            }
        }

        private FormStatus _status;
        public FormStatus status2
        {
            get { return _status; }
            set
            {
                _status = value;
                Status = value.ToString();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string x = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(x)); 

    }
}
