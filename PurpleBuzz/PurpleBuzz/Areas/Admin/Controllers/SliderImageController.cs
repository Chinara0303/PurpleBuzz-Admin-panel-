using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;

namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderImageController : Controller
    {
        private readonly AppDbContext _context;

        public SliderImageController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           SliderImage sliderImage = await _context.SliderImages
                .Where(s => !s.SoftDelete)
                .FirstOrDefaultAsync();

            return View(sliderImage);
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
            SliderImage sliderImage = await _context.SliderImages
                .FirstOrDefaultAsync(si => si.Id == id);
            return View(sliderImage);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            SliderImage sliderImage = await _context.SliderImages
                .FirstOrDefaultAsync(si => si.Id == id);
            return View(sliderImage);
        }
    }
}
