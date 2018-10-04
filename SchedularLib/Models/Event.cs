using SchedularLib.Managers;
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
        public Event()
        {
            Id = IdManager.GetId();
        }

        public uint Id { get; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Descriptions { get; set; }
        public List<AttachedFile> Files { get; set; }


        public void Update(Event @event)
        {
            Title = @event.Title;
            Date = @event.Date;
            Descriptions = @event.Descriptions;
            Files = @event.Files;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^
                Title.GetHashCode() ^
                Descriptions.GetHashCode() ^
                Date.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Event other = obj as Event;

            return Id == other.Id &&
                Title == other.Title &&
                Date == other.Date &&
                Descriptions == other.Descriptions &&
                (((Files == null || !Files.Any()) && (other.Files == null || !other.Files.Any())) ||
                Files.All(f => other.Files.Contains(f)));
        }
    }
}
