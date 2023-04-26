using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels.FormVM
{
    public class FormMessageListVM
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string FormDescription { get; set; }
        public DateTime FormDateTime{ get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<MessageList>? MessageList { get; set; }
    }
    public class MessageList
    {
        //public int FromMessageId { get; set; }
        public string UserName { get; set; }
        public string FormMessage { get; set; }
        public DateTime CreateMessage { get; set; }
    }
}
