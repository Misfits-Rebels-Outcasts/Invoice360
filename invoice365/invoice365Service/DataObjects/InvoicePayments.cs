using Microsoft.WindowsAzure.Mobile.Service;

namespace invoice365Service.DataObjects
{
    
    public class InvoicePayments : EntityData
    {
        public string UserId { get; set; }
        public string InvoiceId { get; set; }
        public string MasterPaymentId { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string Notes { get; set; }

        


    }
}