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
    public class CalendarFileManager
    {
        public List<Event> ReadCalendar(int year, Months month)
        {
            string fileName = GetFileName(year, month);
            if (!File.Exists(fileName))
            {
                return new List<Event>();
            }
            else
            {
                // TODO
                // Read file
            }
        }

        public void WriteCalendar(List<Event> events)
        {

        }

        private static BinaryFormatter binaryFormatter = new BinaryFormatter();

        private string GetFileName(int year, Months month)
        {
            return year.ToString() + "_" + month.ToString().ToUpper() + ".cal";
        }
    }
}
