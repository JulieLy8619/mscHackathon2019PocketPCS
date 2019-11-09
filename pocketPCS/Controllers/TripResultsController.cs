using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pcsHackathon2019.Models;
using pocketPCS.Data;

namespace pocketPCS.Controllers
{
    public class TripResultsController : Controller
    {
        private readonly ApplicationDbContext context;

        public TripResultsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(Move move)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var user = context.PocketUsersTable
            //    .Where(u => u.Id == userId)                
            //    .FirstOrDefault();

          

            //if ( user == null || user.Moves == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            //var move = user.Moves.FirstOrDefault();
            

            return View(move);
        }
    }
}