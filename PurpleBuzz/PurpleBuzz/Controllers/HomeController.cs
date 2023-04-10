using PurpleBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.ViewModels;
using System.Diagnostics;

namespace PurpleBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderInfo> sliderInfos = await _context.SliderInfos.
                Where(s=>!s.SoftDelete)
                .ToListAsync();
            SliderImage sliderImage = await _context.SliderImages.
                Where(s=>!s.SoftDelete)
                .FirstOrDefaultAsync();
            Service service = await _context.Services
                .Where(s => !s.SoftDelete)
                .FirstOrDefaultAsync();
            IEnumerable<Work> works = await _context.Works
                .Where(w => !w.SoftDelete)
                .ToListAsync();
            IEnumerable<Product> products = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(w => !w.SoftDelete)
                .Take(8)
                .ToListAsync();
            IEnumerable<Category> categories = await _context.Categories
                .Where(c => !c.SoftDelete)
                .ToListAsync();
            HomeVM model = new()
            { 
                SliderImage=sliderImage,
                SliderInfos=sliderInfos,
                Service = service,
                Works = works,
                Products = products,
                Categories = categories
            };

            return View(model);
        }

    }
}