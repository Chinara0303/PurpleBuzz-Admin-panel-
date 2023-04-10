using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels;

namespace Front_to_Back.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context=context;   
        }
        public async Task<IActionResult> Index()
        {
            Banner banner = await _context.Banners
                .Where(b=>!b.SoftDelete)
                .FirstOrDefaultAsync();
            TeamMemberHeader teamMemberHeader = await _context.TeamMemberHeaders
                .Where(t => !t.SoftDelete)
                .FirstOrDefaultAsync();
            IEnumerable<TeamMember> teamMembers = await _context.TeamMembers
                .Where(tm => !tm.SoftDelete)
                .ToListAsync();
            WhyUsBanner whyUsBanner = await _context.WhyUsBanners
                .Where(w => !w.SoftDelete)
                .FirstOrDefaultAsync();

            IEnumerable<ObjectiveBanner> objectiveBanners = await _context.ObjectiveBanners
                .Where(o => !o.SoftDelete)
                .ToListAsync();

            Subscribe subscribe = await _context.Subscribes
              .Where(s => !s.SoftDelete)
              .FirstOrDefaultAsync();

            IEnumerable<Partner> partners = await _context.Partners
            .Where(p => !p.SoftDelete)
            .ToListAsync();

            AboutVM model = new()
            {
                Banner = banner,
                TeamMemberHeader = teamMemberHeader,
                TeamMembers = teamMembers,
                WhyUsBanner = whyUsBanner,
                ObjectiveBanners = objectiveBanners,
                Subscribe = subscribe,
                Partners = partners
            };
            return View(model);
        }
    }
}
