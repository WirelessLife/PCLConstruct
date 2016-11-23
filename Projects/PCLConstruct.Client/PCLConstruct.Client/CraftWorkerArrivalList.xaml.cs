using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace PCLConstruct.Client
{
    public partial class CraftWorkerArrivalList : ContentPage, INotifyPropertyChanged
    {
        public bool IsJobNotSelected {
            get {
                return JobList.SelectedItem == null;
            }
        }

        public CraftWorkerArrivalList()
        {
            InitializeComponent();
            this.ListLable.IsVisible = false;

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
                this.WelcomeLabel.IsVisible = true;
                this.ListLable.IsVisible = false;
                return;
            }
            this.WelcomeLabel.IsVisible = false;
            this.ListLable.IsVisible = true;

            this.CraftWorkerList.ItemsSource = new List<CraftWorker>
            {
                new CraftWorker
                {
                    FirstName = "Anna",
                    LastName = "Song",
                    Status = "Completed",
                    IDType = "Drivers licence",
                    IDValue = "123456789"
                },
                new CraftWorker {
                    FirstName = "Kyle",
                    LastName = "Franklin",
                    Status = "Not Started",
                    IDType = "Union ID",
                    IDValue ="789456123"
                },
                new CraftWorker {
                    FirstName = "Kennedy",
                    LastName = "Roulston",
                    Status = "Incomplete",
                    IDType = "Union ID",
                    IDValue ="6743"
                },
                new CraftWorker {
                    FirstName = "Steven",
                    LastName = "Briggs",
                    Status = "Not Started",
                    IDType = "Drivers License",
                    IDValue ="54546-654654"
                },
                new CraftWorker {
                    FirstName = "Kevin",
                    LastName = "Chew",
                    Status = "Completed",
                    IDType = "Union ID",
                    IDValue ="45435-654778"
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
        public string IDType { get; set; }

        public string IDValue { get; set; }
        public string CraftWorkerName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }
        public string CraftWorkerID
        {
            get
            {
                return this.IDType + " - " + this.IDValue;
            }
        }

        public string ImageName
        {
            get
            {
                switch(this.Status)
                {
                    case "Not Started":
                        return "NotStarted.png";
                    case "Completed":
                        return "Completed.png";
                    case "Incomplete":
                        return "Incompleted.png";
                }

                return "NotStarted.png";
            }
        }

    }
}
