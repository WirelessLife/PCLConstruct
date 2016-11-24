using System;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace PCLConstruct.Api.DataObjects
{
    public class Form : EntityData
    {
        public Guid Id { get; set; }
        public CraftWorker CraftWorker { get; set; }
        public Guid CraftWorkerId { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }

        public string Data { get; set; }
    }
}
