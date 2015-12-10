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
    public class QuoteController : TableController<Quote>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<Quote>(context, Request, Services, enableSoftDelete: true);
        }

        // GET tables/Quote
        public IQueryable<Quote> GetAllQuote()
        {
            return Query(); 
        }

        // GET tables/Quote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Quote> GetQuote(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Quote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Quote> PatchQuote(string id, Delta<Quote> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/Quote
        public async Task<IHttpActionResult> PostQuote(Quote item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;

            Quote current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Quote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteQuote(string id)
        {
             return DeleteAsync(id);
        }

    }
}