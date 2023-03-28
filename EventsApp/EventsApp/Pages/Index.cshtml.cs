using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Data;
using EventsApp.Models;

/*
 * Home page of the Event Web Application. 
 * Connects to the database and displays all upcoming events for participants to register. 
 */

namespace EventsApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EventsContext _context;

        public IndexModel(EventsContext context)
        {
            _context = context;
        }

        public List<Events> Events { get; set; }
        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}