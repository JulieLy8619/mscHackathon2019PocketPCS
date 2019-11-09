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

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var user = context.PocketUsersTable
            //    .Where(u => u.Id == userId)                
            //    .FirstOrDefault();

            var move = context.Moves.FirstOrDefault();
            move.Budget = new Budget();
            move.Budget.Expenses = 4000;
            move.Budget.Allowances = 3000;

            //if ( user == null || user.Moves == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            //var move = user.Moves.FirstOrDefault();


            return View(move);
        }
    }
}