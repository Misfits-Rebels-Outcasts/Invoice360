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
    public class InvoiceItemController : TableController<InvoiceItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<InvoiceItem>(context, Request, Services, enableSoftDelete: false);
        }

        // GET tables/InvoiceItem
        public IQueryable<InvoiceItem> GetAllInvoiceItem()
        {
            return Query(); 
        }

        // GET tables/InvoiceItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<InvoiceItem> GetInvoiceItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/InvoiceItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<InvoiceItem> PatchInvoiceItem(string id, Delta<InvoiceItem> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/InvoiceItem
        public async Task<IHttpActionResult> PostInvoiceItem(InvoiceItem item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            InvoiceItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/InvoiceItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteInvoiceItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}