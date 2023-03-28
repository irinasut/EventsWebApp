using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/*
 * Registration Page of the Event Web Application. 
 * Allows participants to register for a specific event. 
 * Stores the participant's data in the database (Participant table). 
 * Redirects the participant to the Home Page after submitting the information. 
 */

namespace EventsApp.Pages
{
    public class RegistrationModel : PageModel
    {

        private readonly EventsContext _context;

        public RegistrationModel(EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participants Participant { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Participants.AddAsync(Participant);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
