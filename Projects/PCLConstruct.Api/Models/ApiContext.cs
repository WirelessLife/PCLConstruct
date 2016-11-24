using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

    }
}