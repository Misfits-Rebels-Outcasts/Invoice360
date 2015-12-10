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

    public class EstimateItem : EntityData
    {
        public string UserId { get; set; }
        public string MasterItemId { get; set; }
        public string EstimateNumber { get; set; }
        public string EstimateId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool Taxable { get; set; }
        //public long MasterDocumentVersion { get; set; }

    }
}