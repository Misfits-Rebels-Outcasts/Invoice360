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