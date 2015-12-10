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
    public class TodoItem : EntityData
    {
        public string UserId { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }


    }
}