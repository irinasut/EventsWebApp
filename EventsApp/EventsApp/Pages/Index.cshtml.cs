using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Data;
using EventsApp.Models;

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