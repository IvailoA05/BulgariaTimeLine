using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgariaTimeLine.Models
{
    public class CenturyEvent
    {
        public string Century { get; set; }
        public List<Event> Events { get; set; }
    }
}
