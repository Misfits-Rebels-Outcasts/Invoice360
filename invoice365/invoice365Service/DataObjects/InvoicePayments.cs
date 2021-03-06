﻿//
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