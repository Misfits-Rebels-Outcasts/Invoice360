using Microsoft.WindowsAzure.Mobile.Service;

namespace invoice365Service.DataObjects
{

    public class Estimate : EntityData
    {
        public string UserId { get; set; }
        public string MasterItemId { get; set; }
        public string MasterPaymentId { get; set; }
        public string EstimateNumber { get; set; }
        public string DocumentName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string UpdateDate { get; set; }
        public bool TaxOnOff { get; set; }
        public decimal Tax { get; set; }
        public string TaxLabel { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public bool Inclusive { get; set; }
        public bool Multirate { get; set; }
        public bool SecondTaxOnOff { get; set; }
        public decimal SecondTax { get; set; }
        public string SecondTaxLabel { get; set; }
        public bool SecondTaxAccumulate { get; set; }
        public int Terms { get; set; }
        public decimal Discount { get; set; }
        public bool ShippingChargeAfterTax { get; set; }
        public decimal ShippingChargeAfterTaxAmount { get; set; }
        public string ShippingChargeAfterTaxDesc { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string ContactName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress3 { get; set; }
        public string CustomerContactName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone1 { get; set; }
        public string CustomerPhone2 { get; set; }
        public string CustomerFax { get; set; }

        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }

    }
}