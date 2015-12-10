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
    public class InvoicePaymentsController : TableController<InvoicePayments>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<InvoicePayments>(context, Request, Services, enableSoftDelete: false);
        }

        // GET tables/InvoicePayments
        public IQueryable<InvoicePayments> GetAllInvoicePayments()
        {
            return Query(); 
        }

        // GET tables/InvoicePayments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<InvoicePayments> GetInvoicePayments(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/InvoicePayments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<InvoicePayments> PatchInvoicePayments(string id, Delta<InvoicePayments> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/InvoicePayments
        public async Task<IHttpActionResult> PostInvoicePayments(InvoicePayments item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            InvoicePayments current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/InvoicePayments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteInvoicePayments(string id)
        {
             return DeleteAsync(id);
        }

    }
}