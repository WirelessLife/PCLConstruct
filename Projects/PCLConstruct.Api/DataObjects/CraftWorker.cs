using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace PCLConstruct.Api.DataObjects
{
    public class CraftWorker : EntityData
    {
        
        public Guid Id { get; set; }

        public Job Job { get; set; }        

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String IdentifierType { get; set; }
        public String IdentifierValue { get; set; }

        public string ProjectNumber { get; set;}

        public string Status { get; set; }

        [NotMapped]
        public string CraftWorkerName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        [NotMapped]
        public string CraftWorkerID
        {
            get
            {
                return this.IdentifierType + " - " + this.IdentifierValue;
            }
        }

        [NotMapped]
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
