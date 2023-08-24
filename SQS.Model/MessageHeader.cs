using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQS.Model
{
    public class MessageHeader
    {
        public Event Event { get; set; }
        public string DateTime { get; set; }
    }
}