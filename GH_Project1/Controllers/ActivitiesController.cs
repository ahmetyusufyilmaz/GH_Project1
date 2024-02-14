using GH_Project1.Contexts;
using GH_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GH_Project1.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ActivityManagementDbContext _context;
        public ActivitiesController(ActivityManagementDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var activities = await _context.Activities.ToListAsync();
            return View(activities);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Date,Place")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.Participants) 
                .ThenInclude(ap => ap.Participant) 
                .FirstOrDefaultAsync(x => x.Id == id);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
