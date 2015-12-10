//
// Invoice 360
//
// Copyright (c) 2012-2015 invoicesoftware360.com (http://invoicesoftware360.com/GPL-LICENSE.txt)
// Licensed under the GPL (GPL-LICENSE.txt) licenses.
//
// http://www.invoicesoftware360.com
//
//
using Microsoft.WindowsAzure.Mobile.Service;

namespace invoice365Service.DataObjects
{
    
    public class CompanyDetails : EntityData
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string RegistrationNumber { get; set; }
        public string TemplateFileName { get; set; }
        public string TaxLabel { get; set; }
        public string SecondTaxLabel { get; set; }
        public string CurrentInvoiceNumber { get; set; }
        public string CurrentQuoteNumber { get; set; }
        public string CurrentEstimatesNumber { get; set; }
        public string IncrementNumber { get; set; }
        public string InvoiceName { get; set; }
        public string QuoteName { get; set; }
        public string EstimateName { get; set; }
        public string Country { get; set; }        
        public string ShippingChargeAfterTaxDesc { get; set; }
        public bool QuoteOnOff { get; set; }
        public bool EstimateOnOff { get; set; }
        public bool SoundOnOff { get; set; }
        public string CustomersSortOption { get; set; }
        public string InventorySortOption { get; set; }
        public string InvoiceHistorySortOption { get; set; }
        public int Terms { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal SecondTax { get; set; }
        public bool TaxOnOff { get; set; }
        public bool TaxInclusiveOnOff { get; set; }
        public bool SecondTaxOnOff { get; set; }
        public bool SecondTaxAccumulate { get; set; }
        public bool Tax1MultirateOnOff { get; set; }
        public bool ShippingChargeAfterTax { get; set; }
        public decimal ShippingChargeAfterTaxAmount { get; set; }
        public bool OptimizedPDFOnOff { get; set; }
        public bool IndentOnOff { get; set; }
        public decimal IndentWidth { get; set; }
        public bool StrictCurrencyRoundingOnOff { get; set; }
        public bool Default { get; set; }
        public string ActiveTick { get; set; }

        public string EmailMessage { get; set; }
        public string CCEmail { get; set; }
        public string BCCEmail { get; set; }
        /*
        public string ApplicationURL { get; set; }
        public string ApplicationKey { get; set; }
        public string Authority { get; set; }
        public string ClientId { get; set; }
        */
        

        /*
            Terms=0;
            Discount=0.00;
            Tax = 0.00;
            SecondTax = 0.00;         
            TaxOnOff = true;
            TaxInclusiveOnOff = false;
            SecondTaxOnOff = false;
            SecondTaxAccumulate = false;
            Tax1MultirateOnOff = false;         
            ShippingChargeAfterTax = false;
            ShippingChargeAfterTaxAmount = 0.00;

            OptimizedPDFOnOff = false;
            IndentOnOff = false;
            IndentWidth = 0;
            StrictCurrencyRoundingOnOff = true;
*/
    }
}