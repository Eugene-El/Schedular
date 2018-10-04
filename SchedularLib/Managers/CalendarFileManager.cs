using SchedularLib.Enums;
using SchedularLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchedularLib.Managers
{
    public static class CalendarFileManager
    {
        public static List<Event> ReadCalendar(int year, Months month)
        {
            string fileName = GetFileName(year, month);
            if (!File.Exists(fileName))
            {
                return new List<Event>();
            }
            else
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    List<Event> events = (List<Event>)binaryFormatter.Deserialize(fs);
                    if (events == null)
                        return new List<Event>();
                    else
                        return events;
                }
            }
        }

        public static void WriteCalendar(List<Event> events)
        {
            // TO DO (may be)
            // May be scheck for all events in one year, in one month

            string fileName = GetFileName(events.FirstOrDefault().Date.Year, (Months)events.FirstOrDefault().Date.Month);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, events);
            }
        }

        public static void WriteCalendar(List<Event> events, int year, Months month)
        {
            string fileName = GetFileName(year, month);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, events);
            }
        }

        public static void RemoveCalendar(int year, Months month)
        {
            string fileName = GetFileName(year, month);
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        public static void DropAllCalendars()
        {
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()).Where(s => s.EndsWith(fileFormat)))
                File.Delete(file);

            IdManager.DropIds();
        }

        public static bool DoesCalendarExists(int year, Months month)
        {
            return File.Exists(GetFileName(year, month));
        }

        private static BinaryFormatter binaryFormatter = new BinaryFormatter();

        private static string GetFileName(int year, Months month)
        {
            return year.ToString() + "_" + month.ToString().ToUpper() + fileFormat;
        }

        private static string fileFormat = ".cal";
    }
}
