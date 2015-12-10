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
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using invoice365Service.DataObjects;
using invoice365Service.Models;

namespace invoice365Service
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            //config.SetIsHosted(true);

            Database.SetInitializer(new invoice365Initializer());
        }
    }


    public class invoice365InitializerX : DropCreateDatabaseAlways<invoice365Context>
    {
        public override void InitializeDatabase(invoice365Context context)
        {
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            //    , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(invoice365Context context)
        {
            List<CompanyDetails> companyItems = new List<CompanyDetails>
            {
                new CompanyDetails { Id = Guid.NewGuid().ToString(), Name="Enterprise Inc.", Address1="1 Lombard Street", Address2="San Francisco", Address3="CA 9411X", ContactName="Mark Anders", Email="demo@invoicesoftware360.com", Phone1="(415) 826-62XX", Phone2="(415) 826-62YY", Fax="(415) 826-62ZZ",RegistrationNumber = "<Registration Number>",TemplateFileName="",TaxLabel="Tax1",SecondTaxLabel="Tax2", ShippingChargeAfterTaxDesc = "Shipping",CurrentInvoiceNumber = "1", CurrentQuoteNumber = "1", CurrentEstimatesNumber = "1",IncrementNumber="1",InvoiceName = "Invoice",QuoteName = "Quote",EstimateName = "Estimate",Country = "Default", Terms=30,Discount=0.00m, Tax = 0.00m,SecondTax = 0.00m,TaxOnOff = true,TaxInclusiveOnOff = false,SecondTaxOnOff = false,SecondTaxAccumulate = false,Tax1MultirateOnOff = false,ShippingChargeAfterTax = false,ShippingChargeAfterTaxAmount = 0.00m,OptimizedPDFOnOff = false,IndentOnOff = false,IndentWidth = 0m,StrictCurrencyRoundingOnOff = true, ActiveTick="Active",EmailMessage="",CCEmail="",BCCEmail="",QuoteOnOff=false,EstimateOnOff=false,InventorySortOption="ascending",CustomersSortOption="ascending",InvoiceHistorySortOption="descending",SoundOnOff=true},
            };

            foreach (CompanyDetails companyItem in companyItems)
            {
                context.Set<CompanyDetails>().Add(companyItem);
            }

            List<Customer> customerItems = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid().ToString(), Name="A Demo Customer", Address1="1100 High Street", Address2="San Francisco", Address3="CA 91X2X", ContactName="John Archer", Email="john@invoicesoftware360.com", Phone1="(416) 926-62XX", Phone2="", Fax="(416) 926-62ZZ" },
            };

            foreach (Customer customerItem in customerItems)
            {
                context.Set<Customer>().Add(customerItem);
            }

            base.Seed(context);
        }
    }

    public class invoice365Initializer : ClearDatabaseSchemaIfModelChanges<invoice365Context>
    //public class invoice365Initializer : ClearDatabaseSchemaAlways<invoice365Context>
    //public class invoice365Initializer : CreateDatabaseIfNotExists<invoice365Context>         
    {
        protected override void Seed(invoice365Context context)
        {
            /*
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            List<CompanyDetails> companyItems = new List<CompanyDetails>
            {
                new CompanyDetails { Id = Guid.NewGuid().ToString(), Name="Enterprise Inc.", Address1="1 Lombard Street", Address2="San Francisco", Address3="CA 9411X", ContactName="Mark Anders", Email="demo@invoicesoftware360.com", Phone1="(415) 826-62XX", Phone2="(415) 826-62YY", Fax="(415) 826-62ZZ",RegistrationNumber = "<Registration Number>",TemplateFileName="",TaxLabel="Tax1",SecondTaxLabel="Tax2", ShippingChargeAfterTaxDesc = "Shipping",CurrentInvoiceNumber = "1", CurrentQuoteNumber = "1", CurrentEstimatesNumber = "1",InvoiceName = "Invoice",QuoteName = "Quote",EstimateName = "Estimate",Country = "Default", Terms=30,Discount=0.00m, Tax = 0.00m,SecondTax = 0.00m,TaxOnOff = true,TaxInclusiveOnOff = false,SecondTaxOnOff = false,SecondTaxAccumulate = false,Tax1MultirateOnOff = false,ShippingChargeAfterTax = false,ShippingChargeAfterTaxAmount = 0.00m,OptimizedPDFOnOff = false,IndentOnOff = false,IndentWidth = 0m,StrictCurrencyRoundingOnOff = true, ActiveTick="Active",EmailMessage="",CCEmail="",BCCEmail="",QuoteOnOff=false,EstimateOnOff=false,InventorySortOption="ascending",CustomersSortOption="ascending",InvoiceHistorySortOption="descending",SoundOnOff=true},
                new CompanyDetails { Id = Guid.NewGuid().ToString(), Name="Second Demo Company", Address1="2 Lombard Street", Address2="San Francisco", Address3="CA 9411X", ContactName="Mark Anders", Email="demo@invoicesoftware360.com", Phone1="(415) 826-62XX", Phone2="(415) 826-62YY", Fax="(415) 826-62ZZ",RegistrationNumber = "<Registration Number>",TemplateFileName="",TaxLabel="Tax1",SecondTaxLabel="Tax2", ShippingChargeAfterTaxDesc = "Shipping",CurrentInvoiceNumber = "1", CurrentQuoteNumber = "1", CurrentEstimatesNumber = "1",InvoiceName = "Invoice",QuoteName = "Quote",EstimateName = "Estimate",Country = "Default", Terms=30,Discount=0.00m, Tax = 0.00m,SecondTax = 0.00m,TaxOnOff = true,TaxInclusiveOnOff = false,SecondTaxOnOff = false,SecondTaxAccumulate = false,Tax1MultirateOnOff = false,ShippingChargeAfterTax = false,ShippingChargeAfterTaxAmount = 0.00m,OptimizedPDFOnOff = false,IndentOnOff = false,IndentWidth = 0m,StrictCurrencyRoundingOnOff = true,ActiveTick="",EmailMessage="",CCEmail="",BCCEmail="",QuoteOnOff=false,EstimateOnOff=false,InventorySortOption="ascending",CustomersSortOption="ascending",InvoiceHistorySortOption="descending",SoundOnOff=false }
            };

            foreach (CompanyDetails companyItem in companyItems)
            {
                context.Set<CompanyDetails>().Add(companyItem);
            }

            List<Customer> customerItems = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid().ToString(), Name="A Demo Customer", Address1="1100 High Street", Address2="San Francisco", Address3="CA 91X2X", ContactName="John Archer", Email="john@invoicesoftware360.com", Phone1="(416) 926-62XX", Phone2="", Fax="(416) 926-62ZZ" },
                new Customer { Id = Guid.NewGuid().ToString(), Name="X Demo Customer", Address1="1000 High Street", Address2="San Francisco", Address3="CA 91X2X", ContactName="John Archer", Email="john@invoicesoftware360.com", Phone1="(416) 926-62XX", Phone2="", Fax="(416) 926-62ZZ" },
                new Customer { Id = Guid.NewGuid().ToString(), Name="Y Demo Customer", Address1="2000 High Street", Address2="San Francisco", Address3="CA 91X2X", ContactName="John Archer", Email="john@invoicesoftware360.com", Phone1="(416) 926-62XX", Phone2="", Fax="(416) 926-62ZZ" },
                new Customer { Id = Guid.NewGuid().ToString(), Name="Z Demo Customer", Address1="3000 High Street", Address2="San Francisco", Address3="CA 91X2X", ContactName="John Archer", Email="john@invoicesoftware360.com", Phone1="(416) 926-62XX", Phone2="", Fax="(416) 926-62ZZ" },
            };

            foreach (Customer customerItem in customerItems)
            {
                context.Set<Customer>().Add(customerItem);
            }

            List<InventoryProduct> inventoryItems = new List<InventoryProduct>
            {
                //new InventoryProduct { Id = Guid.NewGuid().ToString(), ProductCode="I360001", Name="Copy Paper (W)", Description="Carbonless Paper (White)", ListPrice=5.0, CostPrice=4.0, NumberOfItems=10.0, Discount=0.0, Taxable="Yes" }
                new InventoryProduct { Id = Guid.NewGuid().ToString(), ProductCode="I360001", Name="Copy Paper (W)", Type="inventory", Description="Carbonless Paper (White)", ListPrice=5.0m,CostPrice=4.0m, NumberOfItems=10.0m, Discount=0.0m, Taxable=true },
                new InventoryProduct { Id = Guid.NewGuid().ToString(), ProductCode="I360002", Name="Office Paper (W)", Type="inventory", Description="Multipurpose Paper (White)", ListPrice=5.5m,CostPrice=4.5m, NumberOfItems=80.0m, Discount=0.0m, Taxable=true },
                new InventoryProduct { Id = Guid.NewGuid().ToString(), ProductCode="I360008", Name="Office Repair Services", Type="service", Description="Annual Maintenance Service", ListPrice=5000m,CostPrice=0m, NumberOfItems=1m, Discount=0.0m, Taxable=true }
            };

            foreach (InventoryProduct inventoryItem in inventoryItems)
            {
                context.Set<InventoryProduct>().Add(inventoryItem);
            }
            */
            base.Seed(context);
        }
    }
}

