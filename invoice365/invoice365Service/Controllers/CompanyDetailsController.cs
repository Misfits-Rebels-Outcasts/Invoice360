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
using System;

namespace invoice365Service.Controllers
{
    //[AuthorizeLevel(AuthorizationLevel.User)]
    public class CompanyDetailsController : TableController<CompanyDetails>
    {
        //string userId = "";
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            invoice365Context context = new invoice365Context();
            DomainManager = new EntityDomainManager<CompanyDetails>(context, Request, Services, enableSoftDelete: true);
            //Services.Log.Info("Start:" + DateTime.Now);
            //var currentUser = User as ServiceUser;
            //Services.Log.Info("CDC2:" + currentUser.Id);
            //System.Security.Principal.IPrincipal currentUser = (ServiceUser)this.User;
            //Services.Log.Info("CDC1:" + currentUser.Id);
            //Services.Log.Info("CDC2:" + currentUser.Identity.Name);

            //if (currentUser != null)
            //{
            //    Services.Log.Info("Hello:" + currentUser.Id);
                //userId = currentUser.Id;
            //}

        }

        // GET tables/CompanyDetails
        public IQueryable<CompanyDetails> GetAllCompanyDetails()
        {
            return Query(); 
        }

        // GET tables/CompanyDetails/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CompanyDetails> GetCompanyDetails(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CompanyDetails/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CompanyDetails> PatchCompanyDetails(string id, Delta<CompanyDetails> patch)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                patch.TrySetPropertyValue("UserId", currentUser.Id);

            return UpdateAsync(id, patch);
        }

        // POST tables/CompanyDetails
        public async Task<IHttpActionResult> PostCompanyDetails(CompanyDetails item)
        {
            var currentUser = User as ServiceUser;
            if (currentUser != null && currentUser.Id != null && currentUser.Id != "")
                item.UserId = currentUser.Id;
            //Services.Log.Info("CDC1:" + currentUser.Id);
            //Services.Log.Info("CDC2:" + item.UserId);

            CompanyDetails current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CompanyDetails/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCompanyDetails(string id)
        {
             return DeleteAsync(id);
        }

    }
}