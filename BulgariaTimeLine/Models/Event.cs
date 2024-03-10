using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgariaTimeLine.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Tags { get; set; }
        public string Text { get; set; }
        //public byte[] Image { get; set; }
        public string Video { get; set; }
    }
}
