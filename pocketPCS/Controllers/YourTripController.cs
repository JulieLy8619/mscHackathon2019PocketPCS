using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pcsHackathon2019.Models;
using pocketPCS.Data;

namespace pcsHackathon2019.Controllers
{
    public class YourTripController : Controller
    {
        private readonly ApplicationDbContext context;

        public YourTripController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Move move)
        {

            if (!ModelState.IsValid)
            {
                return View(move);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            move.UserId = userId;
            context.Moves.Add(move);
            context.SaveChanges();
            return RedirectToAction("Index", "Budget", move); 

        }

    }
}