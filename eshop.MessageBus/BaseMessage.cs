using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class BaseMessage
    {
        public long? iD { get; set; }
        public DateTime? MessageCreated  { get; set; }
    }
}
