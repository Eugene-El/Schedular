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
        public List<byte[]> Files { get; set; }
        

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Event other = obj as Event;

            return Id == other.Id &&
                Title == other.Title &&
                Date == other.Date &&
                Descriptions == other.Descriptions &&
                Files.All(f => other.Files.Contains(f));
        }
    }
}
