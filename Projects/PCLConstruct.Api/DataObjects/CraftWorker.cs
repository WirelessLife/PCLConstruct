using System;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace PCLConstruct.Api.DataObjects
{
    public class CraftWorker : EntityData
    {
        
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String IdentifierType { get; set; }
        public String IdentifierValue { get; set; }
    }
}
