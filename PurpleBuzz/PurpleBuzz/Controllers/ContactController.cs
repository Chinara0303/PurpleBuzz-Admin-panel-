using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Data;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels;

namespace Front_to_Back.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ContactBanner contactBanner = await _context.ContactBanners
                .Where(cb => !cb.SoftDelete)
                .FirstOrDefaultAsync();

            ContactHeader contactHeader = await _context.ContactHeaders
                .Where(ch => !ch.SoftDelete)
                .FirstOrDefaultAsync();
            IEnumerable<Contact> contacts = await _context.Contacts
                .Where(c => !c.SoftDelete)
                .ToListAsync();

            ContactVM model = new()
            {
                ContactBanner = contactBanner,
                ContactHeader = contactHeader,
                Contacts  = contacts
            };
            return View(model);

        }
    }
}
