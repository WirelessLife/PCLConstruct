using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using PCLConstruct.Api.DataObjects;

namespace PCLConstruct.Api.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext() : base(Constants.SqlConnectionString)
        {
            
        }
        public DbSet<CraftWorker> Craftworkers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Job> Jobs { get; set; }



    }
}