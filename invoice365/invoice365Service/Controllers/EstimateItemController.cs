//
// Invoice 360
//
// Copyright (c) 2012-2015 invoicesoftware360.com (http://invoicesoftware360.com/GPL-LICENSE.txt)
// Licensed under the GPL (GPL-LICENSE.txt) licenses.
//
// http://www.invoicesoftware360.com
//
//

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using invoice365Service.DataObjects;
using invoice365Service.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace invoice365Service.Controllers
{
    public class EstimateItemController : TableController<EstimateItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<EstimateItem>(context, Request, Services, enableSoftDelete: false);
        }

        // GET tables/EstimateItem
        public IQueryable<EstimateItem> GetAllEstimateItem()
        {
            return Query(); 
        }

        // GET tables/EstimateItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EstimateItem> GetEstimateItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EstimateItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EstimateItem> PatchEstimateItem(string id, Delta<EstimateItem> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/EstimateItem
        public async Task<IHttpActionResult> PostEstimateItem(EstimateItem item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            EstimateItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EstimateItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEstimateItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}