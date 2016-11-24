﻿namespace PCLConstruct.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xamarin.Forms;
    using System.Linq;
    using PCLConstruct.Client.Security;
    using Views;
    /// <summary>
    /// The list of jobs and craft workers scheduled to arrive on site
    /// </summary>
    public partial class CraftWorkerArrivalList : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// Determines if the tray is already opened
        /// </summary>
        private bool TrayOpened = true;
        private string CurrentProjectNumber;

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

            this.ExpandTray.GestureRecognizers.Add(new TapGestureRecognizer(this.ExpandTrayOnTap));
            //this.CollapseTray.Clicked += CollapseTray_Clicked;
            this.CollapseTray.GestureRecognizers.Add(new TapGestureRecognizer(this.CollapseTrayOnTap));

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
                    ProjectNumber = "150007",
                    ProjectName = "Test Project C this is a very long project name to test wrapping",
                    ProjectLocation = "Edmonton, Alberta"
                },
                new Job
                {
                    ProjectNumber = "150000",
                    ProjectName = "No worker Project",
                    ProjectLocation = "Edmonton, Alberta"
                }
            };

            this.AdministratorNameLabel.Text = userName;

            this.JobList.ItemSelected += this.JobList_ItemSelected;

            this.CraftWorkerList.ItemTapped += this.CraftWorkerList_ItemTapped;

            this.LogoutButton.Clicked += LogoutButton_Clicked;
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            AzureADAuth auth = new AzureADAuth();
            auth.ClearCache();
            auth.AuthenticateUser();
        }

        private void CollapseTrayOnTap(View arg1, object arg2)
        {
            this.HideTray();
        }

        private void ExpandTrayOnTap(View arg1, object arg2)
        {
            this.ShowTray();
        }

        private void HideTray()
        {
            //Portrait
            if (height > width)
            {
                this.TrayOpened = false;

                this.JobListStackLayout.IsVisible = false;
                this.CraftWorkersStackLayout.IsVisible = true;

                this.MasterColumn.Width = GridLength.Auto;
                this.DetailColumn.Width = GridLength.Star;

            }
        }

        private void ShowTray()
        {
            if (height > width)
            {
                this.TrayOpened = true;

                this.JobListStackLayout.IsVisible = true;
                this.CraftWorkersStackLayout.IsVisible = false;

                this.MasterColumn.Width = GridLength.Star;
                this.DetailColumn.Width = GridLength.Auto;
            }
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

     
           var Selectionpage = new FormSelectionPage((CraftWorker)e.Item);

            await Navigation.PushAsync(
                    Selectionpage
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
                // Shows the welcome label and hides the list label. The list won"t have any items in it
                this.WelcomeLabel.IsVisible = true;
                this.ListLabel.IsVisible = false;
                this.CraftWorkerList.ItemsSource = new List<CraftWorker>();
                return;
            }

            // Shows the list label and hides the welcome label
            this.WelcomeLabel.IsVisible = false;
            this.ListLabel.IsVisible = true;

            CurrentProjectNumber = ((Job)e.SelectedItem).ProjectNumber;

            var newtempCraftWorkerList = tempCraftWorkerList.Where(x => x.ProjectNumber == CurrentProjectNumber);

            if (newtempCraftWorkerList.Any())
            {
                this.CraftWorkerList.ItemsSource = tempCraftWorkerList.Where(x => x.ProjectNumber == CurrentProjectNumber);
            }
            else {
                this.WelcomeLabel.IsVisible = true;
                this.WelcomeLabel.Text = "No workers found for this project.";
                this.CraftWorkerList.ItemsSource = new List<CraftWorker>();
            }
            

            //If portrait, hide the master column and bring out the detial. 
            this.HideTray();
        }

        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
            }
            else
            {
                // If the width / height is the same, excape early.
                return;
            }

            if (height > width)
            {
                // This is our portrait view
                this.TrayOpened = true;

                this.ExpandTray.IsVisible = true;
                this.CollapseTray.IsVisible = true;

                this.DetailColumn.Width = GridLength.Star;
                this.MasterColumn.Width = GridLength.Auto;

                this.JobListStackLayout.IsVisible = true;
                this.CraftWorkersStackLayout.IsVisible = false;
            }
            else
            {
                // This is our landscape view
                this.ExpandTray.IsVisible = false;
                this.CollapseTray.IsVisible = false;

                this.JobListStackLayout.IsVisible = true;
                this.CraftWorkersStackLayout.IsVisible = true;
                this.DetailColumn.Width = new GridLength(75.0, GridUnitType.Star);
                this.MasterColumn.Width = new GridLength(25.0, GridUnitType.Star);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            // If you want to stop the back button
            return false;
        }

        List<CraftWorker> tempCraftWorkerList = new List<CraftWorker>
            {
                new CraftWorker
                {
                    ProjectNumber = "150008",
                    FirstName = "Anna",
                    LastName = "Song",
                    Status = "Completed",
                    IDType = "Drivers licence",
                    IDValue = "123456789"
                },
                new CraftWorker {
                    ProjectNumber = "150009",
                    FirstName = "Kyle",
                    LastName = "Franklin",
                    Status = "Not Started",
                    IDType = "Union ID",
                    IDValue ="789456123"
                },
                new CraftWorker {
                    ProjectNumber = "156000",
                    FirstName = "Kennedy",
                    LastName = "Roulston",
                    Status = "Incomplete",
                    IDType = "Union ID",
                    IDValue ="6743"
                },
                new CraftWorker {
                    ProjectNumber = "156000",
                    FirstName = "Steven",
                    LastName = "Briggs",
                    Status = "Not Started",
                    IDType = "Drivers License",
                    IDValue ="54546-654654"
                },
                new CraftWorker {
                    ProjectNumber = "150007",
                    FirstName = "Kevin",
                    LastName = "Chew",
                    Status = "Completed",
                    IDType = "Union ID",
                    IDValue ="45435-654778"
                }
            };
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

        public string ProjectNumber { get; set; }

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
                switch (this.Status)
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
