using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pcsHackathon2019.Controllers
{
    public class AdditionalExpenseController : Controller
    {
        private readonly ApplicationDbContext context;

        public AdditionalExpenseController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //need to check table name in data folder-> dbcontext
        //if I add myown then add this to dbcontext file
        //    public DbSet<AddExpenseClass> BoardTable { get; set; }

        /// <summary>
        /// gets all additional expenses added by users
        /// </summary>
        /// <returns>list of expenses</returns>
        public async Task<IActionResult> Index()
        {
            return View(await context.BoardTable.ToListAsync());
        }

        //if want to add search
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var exps = from e in context.BoardTable
        //               select e;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        exps = exps.Where(n => n.Name.Contains(searchString));
        //    }
        //    return View(await exps.ToListAsync());
        //}



        //this name will need to match view page name
        //this will take us to the add expense form page
        public IActionResult AddExpense()
        {
            return View();
        }

        //will need to double check if those are property names from model for the BIND
        //this currently doesn't exists in the MODELS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExpense([Bind("ID,Start,End,Amount,Description")] AddExpenseClass expense)
        {
            AddExpenseClass newExpense = expense;
            if (ModelState.IsValid)
            {
                await context.BoardTable.Add(newExpense);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }



    }
}
