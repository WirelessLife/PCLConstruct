using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace PCLConstruct.Client
{
    public partial class CraftWorkerArrivalList : ContentPage, INotifyPropertyChanged
    {
        public CraftWorkerArrivalList()
        {
            InitializeComponent();

            this.JobList.ItemsSource = new List<Job>
            {
                new Job
                {
                    ProjectNumber = "150009",
                    ProjectName = "Edmonton Arena"
                },
                new Job {
                    ProjectNumber = "156000",
                    ProjectName = "EIA Upgrade"
                },
                new Job
                {
                    ProjectNumber = "150008",
                    ProjectName = "Test Project C",
                    ProjectLocation = "Edmonton, Alberta"
                }
            };

            this.AdministratorNameLabel.Text = "Anna Song";

            this.JobList.ItemSelected += JobList_ItemSelected;

            this.CraftWorkerList.ItemSelected += CraftWorkerList_ItemSelected;
        }

        private void CraftWorkerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            DisplayAlert("Item Selected", ((CraftWorker)e.SelectedItem).CraftWorkerName, "Ok");
        }

        private void JobList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            this.CraftWorkerList.ItemsSource = new List<CraftWorker>
            {
                new CraftWorker
                {
                    FirstName = "Anna",
                    LastName = "Song",
                    Status = "Completed"
                },
                new CraftWorker {
                    FirstName = "Kyle",
                    LastName = "Franklin",
                    Status = "Not Started"
                }
            };
        }
    }

    public class Job
    {
        public string ProjectNumber { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectName { get; set; }

        public string ProjectDisplayValue
        {
            get
            {
                return this.ProjectNumber + " - " + this.ProjectName;
            }
        }
    }

    public class CraftWorker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }

        public string CraftWorkerName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }
    }
}
