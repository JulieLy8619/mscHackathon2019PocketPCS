using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pcsHackathon2019.Models;
using pocketPCS.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pcsHackathon2019.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext context;

        public CommentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //will list all the comments for that thread
        //need to get passed the threadID
        // GET: /<controller>/
        public async Task<IActionResult> Index(int id)
        {
            //need to query to only show comments for a given threadID
            //view needs to pass in the thread ID when this is called
            var coms = from c in context.CommentTable
                       select c;
            coms = coms.Where(e => e.ThreadID == id);
            return View(await coms.ToListAsync());
        }

        //should take us to the add comment form page
        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("ID,ThreadID,Username,Subject,Body")] Comment comment)
        {
            Comment newComment = comment;
            if (ModelState.IsValid)
            {
                context.CommentTable.Add(newComment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }
    }
}
