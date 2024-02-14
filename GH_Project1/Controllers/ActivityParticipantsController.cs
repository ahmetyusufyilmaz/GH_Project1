using GH_Project1.Contexts;
using GH_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GH_Project1.Controllers
{
    public class ActivityParticipantsController : Controller
    {
        private readonly ActivityManagementDbContext _context;
        public ActivityParticipantsController(ActivityManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ap = await _context.ActivityParticipants.ToListAsync();
            return View(ap);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Participants = _context.Participants.OrderBy(b => b.FirstName).ToList();

            ViewBag.Activities = _context.Activities.OrderBy(b => b.Title).ToList();

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityParticipants activityParticipants)
        {
            if (ModelState.IsValid)
            {
                activityParticipants.ActivityName = _context.Activities.Find(activityParticipants.ActivityId)?.Title;
                activityParticipants.ParticipantName = _context.Participants.Find(activityParticipants.ParticipantId)?.FullName;

                var activity = _context.Activities.Find(activityParticipants.ActivityId);
              

                _context.Add(activityParticipants);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activityParticipants);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ActivityParticipants == null)
            {
                return NotFound();
            }

            var acparticipant = await _context.ActivityParticipants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acparticipant == null)
            {
                return NotFound();
            }

            return View(acparticipant);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var acparticipant = await _context.ActivityParticipants.FindAsync(id);
            if (acparticipant != null)
            {
                _context.ActivityParticipants.Remove(acparticipant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
