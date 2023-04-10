using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;

namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext _context;
        public RecentWorkController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Work> works = await _context.Works
                .Where(w=>!w.SoftDelete)
                .ToListAsync();
                
            return View(works);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();
            Work work = await _context.Works
                .FirstOrDefaultAsync(w => w.Id == id);
            if (work is null) return NotFound();
            return View(work);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id is null) return BadRequest();
            Work work = await _context.Works
                .FirstOrDefaultAsync(w => w.Id == id);
            if (work is null) return NotFound();
            return View(work);
        }
    }
}
