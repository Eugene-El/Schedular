using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchedularLib.Managers;
using SchedularLib.Models;
using System.Collections.Generic;
using SchedularLib.Enums;
using System.Linq;
using System.IO;

namespace SchedularLib.Tests.Managers
{
    [TestClass]
    public class CalendarFileManagerTests
    {
        private DateTime date;
        private List<Event> expectedEvents;

        [TestInitialize]
        public void TestInitialize()
        {
            date = new DateTime(2007, 9, 26);
            expectedEvents = new List<Event>() {
                new Event() {
                    Id = 1,
                    Date = date,
                    Title = "Testing event 1",
                    Files = new List<byte[]>(),
                    Descriptions = ""
                },
                new Event() {
                    Id = 2,
                    Date = date,
                    Title = "Testing event 2",
                    Files = new List<byte[]>(),
                    Descriptions = ""
                }
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CalendarFileManager.RemoveCalendar(date.Year, (Months)date.Month);
        }


        [TestMethod]
        public void TestWriteReadFile()
        {
            CalendarFileManager.WriteCalendar(expectedEvents);
            List<Event> actualEvents = CalendarFileManager.ReadCalendar(date.Year, (Months)date.Month);

            CollectionAssert.AreEqual(expectedEvents, actualEvents);
        }

        [TestMethod]
        public void TestCalendarRemove()
        {
            CalendarFileManager.WriteCalendar(expectedEvents);

            CalendarFileManager.RemoveCalendar(date.Year, (Months)date.Month);
            List<Event> actualEvents = CalendarFileManager.ReadCalendar(date.Year, (Months)date.Month);

            CollectionAssert.AreEqual(new List<Event>(), actualEvents);
        }
    }
}
