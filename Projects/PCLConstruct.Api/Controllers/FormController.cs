using System;
using System.Collections.Generic;
using System.Configuration;
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
    
    public class FormController : TableController<Form>
    {
        TelemetryClient tc = new TelemetryClient();

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            
            DomainManager = new EntityDomainManager<Form>(new ApiContext(), Request);
        }

        // GET tables/Form
        //chagned returned type from  IQueryable<Form>
        //public IEnumerable<Form> GetAllForm()
        //{
        //    try
        //    {
        //        IEnumerable<Form> result = Query();
        //        var temp = result.ToList();
        //    return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        tc.TrackException(ex);
        //        throw;
        //    }
        //}



        public IEnumerable<Form> GetForms(Guid id)
        {
            try
            {
                IEnumerable<Form> result = Query().Where(f => f.CraftWorker.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                tc.TrackException(ex);
                throw;
            }

        }




        // GET tables/Form/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public SingleResult<Form> GetForm(string id)
        //{
        //    try
        //    {
        //         SingleResult<Form> result = Lookup(id);
        //    return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        tc.TrackException(ex);
        //        throw;
        //    }

        //}

        // PATCH tables/Form/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Form> PatchForm(string id, Delta<Form> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Form
        public async Task<IHttpActionResult> PostForm(Form item)
        {
            Form current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Form/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteForm(string id)
        {
            return DeleteAsync(id);
        }
    }
}