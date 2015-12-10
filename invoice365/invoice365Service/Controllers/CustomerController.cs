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
      //  [AuthorizeLevel(AuthorizationLevel.User)]

    public class CustomerController : TableController<Customer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();            
            DomainManager = new EntityDomainManager<Customer>(context, Request, Services, enableSoftDelete: true);


        }

        // GET tables/Customer
        public IQueryable<Customer> GetAllCustomer()
        {
            return Query(); 
        }

        // GET tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Customer> GetCustomer(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Customer> PatchCustomer(string id, Delta<Customer> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostCustomer(Customer item)
        {
            /*
            var currentUser = User as ServiceUser;
            item.Address3 = currentUser.Id;
            */
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            Customer current = await InsertAsync(item);

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCustomer(string id)
        {
             return DeleteAsync(id);
        }

    }
}