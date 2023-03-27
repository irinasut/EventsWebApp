using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            //var id = Participant.EventId;

            await _context.Participants.AddAsync(Participant);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public void OnGet()
        {
        }
    }
}
