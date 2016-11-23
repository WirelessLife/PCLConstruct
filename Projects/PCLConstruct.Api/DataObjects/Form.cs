using System;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace PCLConstruct.Api.DataObjects
{
    public class Form : EntityData
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Staus { get; set; }

    }
}
