using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchedularLib.Models;
using SchedularLib.Factories;
using SchedularLib.Managers;
using SchedularLib.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SchedularLib.Tests.Factories
{
    [TestClass]
    public class CalendarFactoryTests
    {
        private ICalendarFactory calendarFactory;
        private DateTime date;
        private Event singleEvent;
        private List<Event> events;

        [TestInitialize]
        public void TestInitialize()
        {
            calendarFactory = new CalendarFactory();

            date = DateTime.Now;
            singleEvent = new Event()
            {
                Title = "Testing party event",
                Date = date,
                Descriptions = "Testing description"
            };
            events = new List<Event>() {
                new Event() {
                    Title = "Event #1",
                    Date = date,
                    Descriptions = "Description #1"
                },
                new Event() {
                    Title = "Event #2",
                    Date = date,
                    Descriptions = "Description #2",
                    Files = new List<AttachedFile>() {
                        new AttachedFile() {
                            Name = "File #1"
                        }
                    }
                },
                new Event() {
                    Title = "Event #3",
                    Date = new DateTime(2007, 3, 12),
                    Descriptions = "Description #3"
                }
            };
        }

        [TestMethod]
        public void TestCreateGetEvent()
        {
            calendarFactory.CreateEvent(singleEvent);

            Assert.IsTrue(CalendarFileManager.DoesCalendarExists(date.Year, (Months)date.Month));
            Assert.AreEqual(singleEvent, calendarFactory.GetByDateAndId(date, singleEvent.Id));
        }

        [TestMethod]
        public void TestUpdateEvent()
        {
            calendarFactory.CreateEvent(singleEvent);
            singleEvent.Descriptions = "Changed description";

            calendarFactory.UpdateEvent(singleEvent);

            Assert.AreEqual(singleEvent, calendarFactory.GetByDateAndId(date, singleEvent.Id));
        }

        [TestMethod]
        public void TestRemoveEvent()
        {
            calendarFactory.CreateEvent(singleEvent);

            calendarFactory.RemoveEvent(singleEvent);

            CollectionAssert.DoesNotContain(calendarFactory.GetEventsByMonthAndYear(date.Year, (Months)date.Month), singleEvent);
        }

        [TestMethod]
        public void TestGetEventsByDate()
        {
            foreach (Event @event in events)
                calendarFactory.CreateEvent(@event);

            CollectionAssert.AreEquivalent(events.Where(e => e.Date == date).ToList() , calendarFactory.GetEventsByDate(date));
        }

        [TestMethod]
        public void TestGetEventDatesByMonthAndYear()
        {
            foreach (Event @event in events)
                calendarFactory.CreateEvent(@event);

            CollectionAssert.AreEquivalent(events.Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year).Select(e => e.Date).Distinct().ToList() , calendarFactory.GetEventDatesByMonthAndYear(date.Year, (Months)date.Month));
        }

        [TestMethod]
        public void TestGetEventsByMonthAndYear()
        {
            foreach (Event @event in events)
                calendarFactory.CreateEvent(@event);

            CollectionAssert.AreEquivalent(events.Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year).ToList(), calendarFactory.GetEventsByMonthAndYear(date.Year, (Months)date.Month));
        }

        [TestMethod]
        public void TestGetByDateAndId()
        {
            foreach (Event @event in events)
                calendarFactory.CreateEvent(@event);

            Event soloEvent = events.First();
            Assert.AreEqual(soloEvent, calendarFactory.GetByDateAndId(soloEvent.Date, soloEvent.Id));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CalendarFileManager.DropAllCalendars();
        }
    }
}
