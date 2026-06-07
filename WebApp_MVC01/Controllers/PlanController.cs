using GymManagment.DAL.Repositories.Classes;
using GymManagment.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC01.WebAppContexts;

namespace WebApp_MVC01.Controllers
{
    public class PlanController : Controller
    {
        // Database Connection
        // private readonly AppDbContext context;

        private readonly IPlanRepository _planRepository; // = new PlanRepository(); // we have a problem here that new make the controller make repo make dbContext !

        public PlanController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        //public PlanController()
        //{
        //    context = new AppDbContext();
        //}

        // Actions
        //------------------------
        // Here we get all the plans
        // Get : BaseURL/Plan/Index -> when writing -> this show all plans
        public async Task<IActionResult> Index(CancellationToken ct = default)
        {
            var plans = await _planRepository.GetAllAsync(ct : ct); // pass by name
            return View(plans);
        }

        // GET : BaseURL/Plan/Details/{id}
        public async Task<IActionResult> Details(int id , CancellationToken ct)
        {
            var plan = await _planRepository.GetByIdAsync(id , ct);
            if (plan == null)
                return RedirectToAction(nameof(Index));

            return View(plan);

        }
    }
}
