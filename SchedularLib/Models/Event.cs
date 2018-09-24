using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedularLib.Models
{
    [Serializable]
    public class Event
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Descriptions { get; set; }
        public byte[] File { get; set; }
    }
}
