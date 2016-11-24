namespace PCLConstruct.Client
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xamarin.Forms;

    /// <summary>
    /// The list of jobs and craft workers scheduled to arrive on site
    /// </summary>
    public partial class CraftWorkerArrivalList : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes the Craft Worker Arrival page
        /// </summary>
        /// <param name="userName">the username of the authenticated user</param>
        /// <remarks>
        /// Need to hook up the job list to real data
        /// </remarks>
        public CraftWorkerArrivalList(string userName)
        {
            InitializeComponent();
            this.ListLabel.IsVisible = false;

            this.JobList.ItemsSource = new List<Job>
            {
                new Job
                {
                    ProjectNumber = "150009",
                    ProjectName = "Edmonton Arena",
                    ProjectLocation = "Location not available"
                },
                new Job {
                    ProjectNumber = "156000",
                    ProjectName = "EIA Upgrade",
                    ProjectLocation = "Location not available"
                },
                new Job
                {
                    ProjectNumber = "150008",
                    ProjectName = "Test Project C",
                    ProjectLocation = "Edmonton, Alberta"
                },                
                new Job
                {
                    ProjectNumber = "150008",
                    ProjectName = "Test Project C this is a very long project name to test wrapping",
                    ProjectLocation = "Edmonton, Alberta"
                }
            };

            this.AdministratorNameLabel.Text = userName;

            this.JobList.ItemSelected += this.JobList_ItemSelected;

            this.CraftWorkerList.ItemTapped += this.CraftWorkerList_ItemTapped;
        }

        /// <summary>
        /// Handles when a craft worker item is selected
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments of the event</param>
        /// <remarks>
        /// TODO: This will need to load the form for this worker instead of displaying an alert.
        /// </remarks>
        private async void CraftWorkerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            await Navigation.PushAsync(
                    new FormSelectionPage((CraftWorker)e.Item)
                );
        }

        /// <summary>
        /// Handles when a job item is selected. Loads the Craft Worker list.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments of the event</param>
        /// <remarks>
        /// TODO: Need to hook this up to real data
        /// </remarks>
        private void JobList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                // Shows the welcome label and hides the list label. The list won't have any items in it
                this.WelcomeLabel.IsVisible = true;
                this.ListLabel.IsVisible = false;
                this.CraftWorkerList.ItemsSource = new List<CraftWorker>();
                return;
            }

            // Shows the list label and hides the welcome label
            this.WelcomeLabel.IsVisible = false;
            this.ListLabel.IsVisible = true;

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

    /// <summary>
    /// A POCO for the jobs
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Gets or sets the project number of the job
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// Gets or sets the project location of the job
        /// </summary>
        public string ProjectLocation { get; set; }

        /// <summary>
        /// Gets or sets the project name of the job
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets the concatenated project display name. Formatted as ProjectNumber - ProjectName
        /// </summary>
        public string ProjectDisplayValue
        {
            get
            {
                return this.ProjectNumber + " - " + this.ProjectName;
            }
        }
    }

    /// <summary>
    /// A POCO for the craft workers
    /// </summary>
    public class CraftWorker
    {
        /// <summary>
        /// Gets or sets the firstname of the craft worker
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the lastname of the craft worker
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the status of the form
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the id type for this worker to identify who he is
        /// </summary>
        public string IDType { get; set; }

        /// <summary>
        /// Gets or sets the value for the id type provided
        /// </summary>
        public string IDValue { get; set; }

        /// <summary>
        /// Gets the concated craft worker name. Formatted Lastname, Firstname
        /// </summary>
        public string CraftWorkerName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        /// <summary>
        /// Gets the concatenated unique identifier provided for this worker
        /// </summary>
        public string CraftWorkerID
        {
            get
            {
                return this.IDType + " - " + this.IDValue;
            }
        }

        /// <summary>
        /// Gets the image to use as the source for completed status of the form
        /// </summary>
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
