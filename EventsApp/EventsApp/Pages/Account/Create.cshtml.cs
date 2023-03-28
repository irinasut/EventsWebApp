using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EventsApp.Pages.Account
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EventsContext _context;

        public CreateModel(EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Events Event { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Events.AddAsync(Event);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Index");

        }
    }
}
