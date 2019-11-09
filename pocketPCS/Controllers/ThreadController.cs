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
    public class ThreadController : Controller
    {
        private readonly ApplicationDbContext context;

        public ThreadController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //will list all the threads
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await context.ThreadTable.ToListAsync());
        }

        //this name will need to match view page name
        //this will take us to the add thread form page
        public IActionResult AddThread()
        {
            return View();
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddThread([Bind("ID,Name")] Thread thread)
        {
            Thread newThread = thread;
            if (ModelState.IsValid)
            {
                context.ThreadTable.Add(newThread);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thread);
        }
    }
}
