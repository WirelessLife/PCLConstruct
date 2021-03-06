﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace PCLConstruct.Api.DataObjects
{
    public class Job : EntityData
    {
        
        public Guid Id { get; set; }
        public String ProjectNumber { get; set; }
        public String Location { get; set; }
        public String Name { get; set; }

        [NotMapped]
        public String ProjectDisplayValue
        { get
            {
                return this.ProjectNumber + " - " + this.Name;
            }
                }
    }
}