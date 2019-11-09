using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pcsHackathon2019.Models;
using pocketPCS.Data;
using pocketPCS.Models;

namespace pcsHackathon2019.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.PocketUsersTable
                .Where(u => u.Id == userId)                
                .FirstOrDefault();

            int moveId;

            //if (user == null)
            //{
            //    user = new User();
            //    user.Id = userId;

            //    user.Moves = new List<Move>();
            //    move.Id = 1;
            //    move.UserId = userId;
            //    move.Budget = new Budget();
            //    move.Budget.Expenses = 4000;
            //    move.Budget.Allowances = 3000;
            //    user.Moves.Add(move);

            //    context.PocketUsersTable.Add(user);
            //}
            //else
            //{                
            //    moveId = user.Moves.Count() + 1;
            //    move.Id = moveId;
            //    move.UserId = userId;
            //    move.Budget = new Budget();
            //    move.Budget.Expenses = 4000;
            //    move.Budget.Allowances = 3000;

            //    context.Moves.Add(move);
            //}

            //var user = context.Users
            //    .Where(u => u.Id == userId)
            //    .Include(u => u.Moves)
            //    .FirstOrDefault();

            
            
            move.UserId = "";
            move.Name = move.StartStation + "-" + move.EndStation;
            move.Budget = new Budget();
            move.Budget.Expenses = 4000;
            move.Budget.Allowances = 3000;

            context.Moves.Add(move);

            context.SaveChanges();


            return RedirectToAction("Index", "TripResults", move); 
        }

    }
}