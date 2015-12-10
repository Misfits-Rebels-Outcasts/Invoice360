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
    
    public class InventoryProduct : EntityData
    {
        public string UserId { get; set; }

        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public bool Taxable { get; set; }
        public decimal NumberOfItems { get; set; }

    }
}