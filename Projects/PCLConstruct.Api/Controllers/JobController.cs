﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PCLConstruct.Api.DataObjects;


namespace PCLConstruct.Api.Controllers
{
    public class JobController : TableController<Job>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            
            DomainManager = new StorageDomainManager<Job>(Constants.TableStorageConnectionString, Constants.JobTableName,Request);
        }

        // GET tables/Job
        public IQueryable<Job> GetAllJobs()
        {
            return Query();
        }

        // GET tables/Job/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Job> GetJob(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Job/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Job> PatchJob(string id, Delta<Job> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Job
        public async Task<IHttpActionResult> PostJob(Job item)
        {
            Job current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Job/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteJob(string id)
        {
            return DeleteAsync(id);
        }
    }
}