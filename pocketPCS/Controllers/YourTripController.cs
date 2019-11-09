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

            //if (!ModelState.IsValid)
            //{
            //    return View(move);
            //}

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users
                .Where(u => u.Id == userId)                
                .FirstOrDefault(); 

            if(user == null)
            {
                user = new User();
                user.Id = userId;
            }

            //var user = context.Users
            //    .Where(u => u.Id == userId)
            //    .Include(u => u.Moves)
            //    .FirstOrDefault();

            int moveId; 
            if(user.Moves == null)
            {
                user.Moves = new List<Move>();
                moveId = 1;
                move.UserId = userId;
                user.Moves.Add(move);

                context.Users.Add(user);
            }
            else
            {
                moveId = user.Moves.Count() + 1;
                move.Id = moveId;
                move.UserId = userId;

                context.Moves.Add(move);
                
            }
            context.SaveChanges();


            return RedirectToAction("Index", "TripResults"); 
        }

    }
}