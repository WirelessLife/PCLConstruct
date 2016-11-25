using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server;
using PCLConstruct.Api.DataObjects;
using PCLConstruct.Api.Models;

namespace PCLConstruct.Api.Controllers
{
    
    public class CraftWorkerController : TableController<CraftWorker>
    {
        TelemetryClient tc = new TelemetryClient();

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);


            //.DomainManager = new StorageDomainManager<CraftWorker>(Constants.TableStorageConnectionString, Constants.CraftWorkerTableName, Request);
            DomainManager = new EntityDomainManager<CraftWorker>(new ApiContext(), Request);
        }

        // GET tables/CraftWorker
        // Changed return type from IQueryable 
        //public IEnumerable<CraftWorker> GetAllCraftWorkers()
        //{
        //    try
        //    {
        //        return Query();
        //    }
        //    catch (Exception ex)
        //    {
        //        tc.TrackException(ex);
        //        throw;
        //    }

            
        //}


        public IEnumerable<CraftWorker> GetCraftWorker(Guid id)
        {
            try
            {
                return Query().Where(c => c.Job.Id.Equals(id));
            }
            catch (Exception ex)
            {
                tc.TrackException(ex);
                throw;
            }

        }




        // GET tables/CraftWorker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public SingleResult<CraftWorker> GetCraftWorker(string id)
        //{
        //    return Lookup(id);
        //}

        // PATCH tables/CraftWorker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CraftWorker> PatchCraftWorker(string id, Delta<CraftWorker> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/CraftWorker
        public async Task<IHttpActionResult> PostCraftWorker(CraftWorker item)
        {
            CraftWorker current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CraftWorker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCraftWorker(string id)
        {
            return DeleteAsync(id);
        }
    }
}