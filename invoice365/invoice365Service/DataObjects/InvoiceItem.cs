using Microsoft.WindowsAzure.Mobile.Service;

namespace invoice365Service.DataObjects
{
    
    public class InvoiceItem : EntityData
    {
        public string UserId { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceId { get; set; }
        public string MasterItemId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool Taxable { get; set; }

    }
}