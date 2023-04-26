using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven_5
{
    public class Order
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public DateTimeOffset OrderedAt { get; set; }
    }
}
