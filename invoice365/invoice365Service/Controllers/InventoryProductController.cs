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
    public class InventoryProductController : TableController<InventoryProduct>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<InventoryProduct>(context, Request, Services, enableSoftDelete:true);
        }

        // GET tables/InventoryProduct
        public IQueryable<InventoryProduct> GetAllInventoryProduct()
        {
            return Query(); 
        }

        // GET tables/InventoryProduct/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<InventoryProduct> GetInventoryProduct(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/InventoryProduct/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<InventoryProduct> PatchInventoryProduct(string id, Delta<InventoryProduct> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/InventoryProduct
        public async Task<IHttpActionResult> PostInventoryProduct(InventoryProduct item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            InventoryProduct current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/InventoryProduct/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteInventoryProduct(string id)
        {
             return DeleteAsync(id);
        }

    }
}