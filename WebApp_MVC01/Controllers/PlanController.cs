using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC01.WebAppContexts;

namespace WebApp_MVC01.Controllers
{
    public class PlanController : Controller
    {
        // Database Connection
        private readonly AppDbContext context;

        public PlanController()
        {
            context = new AppDbContext();
        }

        // Actions
        //------------------------
        // Here we get all the plans
        // Get : BaseURL/Plan/Index -> when writing -> this show all plans
        public async Task<IActionResult> Index()
        {
            var plans = await context.Plans.ToListAsync();
            return View(plans);
        }

        // GET : BaseURL/Plan/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var plan = await context.Plans.FindAsync(id);
            if (plan == null)
                return RedirectToAction(nameof(Index));

            return View(plan);

        }
    }
}
