using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;

namespace PurpleBuzz.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class SliderInfoController : Controller
    {
        private readonly AppDbContext _context;
        public SliderInfoController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderInfo> sliderInfos = await _context.SliderInfos
                .Where(s => !s.SoftDelete)
                .ToListAsync();

            return View(sliderInfos);
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
            SliderInfo sliderInfo = await _context.SliderInfos
                .FirstOrDefaultAsync(si => si.Id == id);
            if (sliderInfo is null) return NotFound();
            return View(sliderInfo);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id is null) return BadRequest();
            SliderInfo sliderInfo = await _context.SliderInfos
                .FirstOrDefaultAsync(si => si.Id == id);
            if (sliderInfo is null) return NotFound();

            return View(sliderInfo);
        }
    }
}
