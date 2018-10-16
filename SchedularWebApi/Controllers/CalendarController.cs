using Microsoft.AspNetCore.Mvc;
using SchedularLib.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedularWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private ICalendarFactory calendarFactory;

        public CalendarController()
        {
            calendarFactory = new CalendarFactory();
        }

        [HttpGet]
        public List<int> Test()
        {
            return new List<int>() { 1, 2, 3, 4 };
        }
    }
}
