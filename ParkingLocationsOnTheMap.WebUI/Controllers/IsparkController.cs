using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLocationsOnTheMap.WebUI.Controllers
{
    public class IsparkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
