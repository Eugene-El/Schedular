using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedularLib.Enums;
using SchedularLib.Models;
using SchedularLib.Managers;

namespace SchedularLib.Factories
{
    public class CalendarFactory : ICalendarFactory
    {

        public void CreateEvent(Event @event)
        {
            List<Event> events = CalendarFileManager.ReadCalendar(@event.Date.Year, (Months)@event.Date.Month);
            events.Add(@event);
            CalendarFileManager.WriteCalendar(events);
        }

        public Event GetByDateAndId(DateTime date, uint id)
        {
            return CalendarFileManager.ReadCalendar(date.Year, (Months)date.Month).FirstOrDefault(e => e.Date == date && e.Id == id);
        }

        public List<DateTime> GetEventDatesByMonthAndYear(int year, Months month)
        {
            return GetEventsByMonthAndYear(year, month).Select(e => e.Date).Distinct().ToList();
        }

        public List<Event> GetEventsByDate(DateTime date)
        {
            return CalendarFileManager.ReadCalendar(date.Year, (Months)date.Month).Where(e => e.Date == date).ToList();
        }

        public List<Event> GetEventsByMonthAndYear(int year, Months month)
        {
            return CalendarFileManager.ReadCalendar(year, month);
        }

        public void RemoveEvent(Event @event)
        {
            List<Event> events = CalendarFileManager.ReadCalendar(@event.Date.Year, (Months)@event.Date.Month);
            events.Remove(events.FirstOrDefault(e => e.Id == @event.Id));
            CalendarFileManager.WriteCalendar(events, @event.Date.Year, (Months)@event.Date.Month);
        }

        public void UpdateEvent(Event @event)
        {
            List<Event> events = CalendarFileManager.ReadCalendar(@event.Date.Year, (Months)@event.Date.Month);
            events.Find(e => e.Id == @event.Id).Update(@event);
            CalendarFileManager.WriteCalendar(events);
        }
    }
}
