//
// Invoice 360
//
// Copyright (c) 2012-2015 invoicesoftware360.com (http://invoicesoftware360.com/GPL-LICENSE.txt)
// Licensed under the GPL (GPL-LICENSE.txt) licenses.
//
// http://www.invoicesoftware360.com
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Threading.Tasks;
using System.Data.Entity;
using Net.Invoice360.Value;
using System.Data.SqlClient;

namespace invoice365Service.Controllers
{
    public class InitController : ApiController
    {
        public ApiServices Services { get; set; }


        // GET api/Init
        public string Get()
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();

            Services.Log.Info("Hello from custom controller!");
            var result = "";
            using (invoice365Service.Models.invoice365Context context = new invoice365Service.Models.invoice365Context())
            {
                Services.Log.Info("Inside1");
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    Services.Log.Info("Inside2");
                    try
                    {
                        string conStr = @"Select Id FROM "+ schema+".CompanyDetails where ActiveTick='Active' and Deleted='False'";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        result = context.Database.SqlQuery<string>(conStr).Single();
                        Services.Log.Info("Hello result:"+result);

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                        Services.Log.Info(ex.ToString());
                    }
                }
            }
            return result;
        }
        public async Task<ValueObject> Post(string companyName)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();

            using (invoice365Service.Models.invoice365Context context = new invoice365Service.Models.invoice365Context())
            {
                //string conStr = string.Format("DELETE FROM [{0}].CUSTOMERS", context.Database.Connection.Database);
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        string conStr = @"DELETE FROM "+ schema+".Customers";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);
                        
                        conStr = @"DELETE FROM " + schema + ".InventoryProducts";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".EstimateItems";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".Estimates";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".QuoteItems";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".Quotes";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".InvoiceItems";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".Invoices";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        conStr = @"DELETE FROM " + schema + ".CompanyDetails";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);

                        //new CompanyDetails { Id = Guid.NewGui                                                TaxLabel = "Tax1", SecondTaxLabel = "Tax2",                                      ShippingChargeAfterTaxDesc = "Shipping", CurrentInvoiceNumber = "1", CurrentQuoteNumber = "1", CurrentEstimatesNumber = "1", InvoiceName = "Invoice", QuoteName = "Quote", EstimateName = "Estimate", Country = "Default", Terms = 30, Discount = 0.00m, Tax = 0.00m, SecondTax = 0.00m, TaxOnOff = true, TaxInclusiveOnOff = false, SecondTaxOnOff = false, SecondTaxAccumulate = false, Tax1MultirateOnOff = false, ShippingChargeAfterTax = false, ShippingChargeAfterTaxAmount = 0.00m, OptimizedPDFOnOff = false, IndentOnOff = false, IndentWidth = 0m, StrictCurrencyRoundingOnOff = true, ActiveTick = "Active", EmailMessage = "", CCEmail = "", BCCEmail = "", QuoteOnOff = false, EstimateOnOff = false, InventorySortOption = "ascending", CustomersSortOption = "ascending", InvoiceHistorySortOption = "descending", SoundOnOff = true },

                        string newID = Guid.NewGuid().ToString();
                        //conStr = @"insert into invoice365.CompanyDetails (Id,UserID,Name,Address1,Address2,Address3,ContactName,Email,Phone1,Phone2,Fax,RegistrationNumber,TemplateFileName,TaxLabel,SecondTaxLabel,CurrentInvoiceNumber,CurrentQuoteNumber,CurrentEstimatesNumber,InvoiceName,QuoteName,EstimateName,Country,ShippingChargeAfterTaxDesc, QuoteOnOff,EstimateOnOff,SoundOnOff,CustomersSortOption, InventorySortOption, InvoiceHistorySortOption, Terms,Discount,Tax,SecondTax,TaxOnOff,TaxInclusiveOnOff,SecondTaxOnOff,SecondTaxAccumulate,Tax1MultirateOnOff,ShippingChargeAfterTax,ShippingChargeAfterTaxAmount,OptimizedPDFOnOff,IndentOnOff,IndentWidth,StrictCurrencyRoundingOnOff," + "\"Default\""+",ActiveTick,EmailMessage,CCEmail,BCCEmail,Deleted)"
                        //                                          +"values('"+newID+ "','jupiter','Enterprise Inc.', '1 Lombard Street', 'San Francisco','CA 9411X', 'Mark Anders','demo@invoicesoftware360.com','(415) 826 - 62XX','(415) 826-62YY', '(415) 826-62ZZ', '<Registration Number>','','Tax1','Tax2','1','1','1','Invoice','Quote','Estimate','Default','Shipping', 0,0,0,'ascending','ascending','descending',15,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,'Active','','','',0)";
                        conStr = @"insert into " + schema + ".CompanyDetails (Id,UserID,Name,Address1,Address2,Address3,ContactName,Email,Phone1,Phone2,Fax,RegistrationNumber,TemplateFileName,TaxLabel,SecondTaxLabel,CurrentInvoiceNumber,CurrentQuoteNumber,CurrentEstimatesNumber,IncrementNumber,InvoiceName,QuoteName,EstimateName,Country,ShippingChargeAfterTaxDesc, QuoteOnOff,EstimateOnOff,SoundOnOff,CustomersSortOption, InventorySortOption, InvoiceHistorySortOption, Terms,Discount,Tax,SecondTax,TaxOnOff,TaxInclusiveOnOff,SecondTaxOnOff,SecondTaxAccumulate,Tax1MultirateOnOff,ShippingChargeAfterTax,ShippingChargeAfterTaxAmount,OptimizedPDFOnOff,IndentOnOff,IndentWidth,StrictCurrencyRoundingOnOff," + "\"Default\""+",ActiveTick,EmailMessage,CCEmail,BCCEmail,Deleted)"
                                                                  +"values('"+newID+ "','jupiter','"+companyName+"', '1 Lombard Street', 'San Francisco','CA 9411X', 'Mark Anders','demo@invoicesoftware360.com','(415) 826 - 62XX','(415) 826-62YY', '(415) 826-62ZZ', '<Registration Number>','','Tax1','Tax2','1','1','1','1','Invoice','Quote','Estimate','Default','Shipping', 0,0,0,'ascending','ascending','descending',15,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,'Active','','','',0)";
                        System.Diagnostics.Debug.WriteLine(conStr);
                        context.Database.ExecuteSqlCommand(conStr);
            
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
            }
                /*
                string conStr = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database);
                System.Diagnostics.Debug.WriteLine("X:"+conStr);
                try
                {
                    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                    , conStr);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    Services.Log.Info("A:" + ex.ToString());

                }
                */
                /*
                try
                {
                    context.Database.Connection.Close();
                    SqlConnection.ClearAllPools();
                    Database database = context.Database;
                    database.Delete();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    Services.Log.Info("B:"+ex.ToString());
                }
            }

            Database.SetInitializer(new invoice365InitializerX());
            */
                /*
                using (invoice365Service.Models.invoice365Context context = new invoice365Service.Models.invoice365Context())
                {
                    // Get the database from the context.
                    var database = context.Database;
                    try
                    {
                        //System.Data.SqlClient.
                        //SqlConnection
                        database.Delete();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex)
                    }


                }*/

                /*
                    using (invoice365Service.Models.invoice365Context context = new invoice365Service.Models.invoice365Context())
                    {
                        // Get the database from the context.
                        var database = context.Database;

                        // Create a SQL statement that sets all uncompleted items
                        // to complete and execute the statement asynchronously.
                        var sql = @"UPDATE todolist.TodoItems SET Complete = 1 " +
                                    @"WHERE Complete = 0; SELECT @@ROWCOUNT as count";

                        var result = new MarkAllResult();
                        result.count = await database.ExecuteSqlCommandAsync(sql);

                        // Log the result.
                        Services.Log.Info(string.Format("{0} items set to 'complete'.",
                            result.count.ToString()));

                        return result;
                    }
                    */
                return new XSuccess();
        }
        
    }
    
}
