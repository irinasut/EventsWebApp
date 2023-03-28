using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

/*
 * Secured Create Page for an authenticated user. 
 * Allows user to create new events, saves the event information in the database.
 * Redirects user to the home page for autheticated users. 
 */

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
