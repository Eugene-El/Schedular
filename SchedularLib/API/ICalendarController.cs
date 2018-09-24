using SchedularLib.Enums;
using SchedularLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedularLib.API
{
    public interface ICalendarController
    {

        List<Event> GetEventsByMonthAndYear(int year, Months month);

        List<DateTime> GetEventDatesByMonthAndYear(int year, Months month);

        List<Event> GetEventsByDate(DateTime date);

        Event GetByDateAndId(DateTime date, uint id);

        void CreateEvent(Event @event);

        void UpdateEvent(Event @event);

    }
}
