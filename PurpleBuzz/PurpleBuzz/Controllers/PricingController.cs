using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels;

namespace Front_to_Back.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;
        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            PricingHeader pricingHeader = await _context.PricingHeaders
                .Where(p => !p.SoftDelete)
                .FirstOrDefaultAsync();
            IEnumerable<PricingTitle> pricingTitles = await _context.PricingTitles
                .Include(p => p.PricingOffers)
                .Where(p => !p.SoftDelete)
                .ToListAsync();

            PricingVM model = new()
            { 
                PricingHeader = pricingHeader,
                PricingTitles = pricingTitles
            };


            return View(model);
        }
    }
}
