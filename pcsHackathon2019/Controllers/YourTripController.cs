using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pcsHackathon2019.Controllers
{
    public class YourTripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Move move)
        {
            RedirectToAction("Index", "Budget", move);
        }

    }
}