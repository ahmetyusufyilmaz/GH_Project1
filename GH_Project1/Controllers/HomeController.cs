using GH_Project1.Contexts;
using GH_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GH_Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ActivityManagementDbContext _context;

        public HomeController(ActivityManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var participants = await _context.Participants.ToListAsync();
            return View(participants);
        }

        public IActionResult Contact()
        {
            return View();
        }

       
    }
}