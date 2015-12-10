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
    
    public class Customer : EntityData
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

        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }

    }
}