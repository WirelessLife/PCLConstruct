﻿using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PCLConstruct.Api.DataObjects;


namespace PCLConstruct.Api.Controllers
{
    public class FormController : TableController<Form>
    {
        

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            


            DomainManager = new StorageDomainManager<Form>(Constants.TableStorageConnectionString, Constants.FormTableName , Request);
        }

        // GET tables/Form
        public IQueryable<Form> GetAllForm()
        {
            return Query();
        }

        // GET tables/Form/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Form> GetForm(string id)
        {
            return Lookup(id);
        }

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