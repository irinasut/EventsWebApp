using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;

namespace EventsApp.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventsContext _context;

        public IndexModel(EventsContext context)
        {
            _context = context;
        }
        public List<Events> Events { get; set; }

        public List<Query> Queries { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
            Queries = new List<Query>();

            var EventParticipants = (from pa in _context.Participants
                         join ev in _context.Events
                         on pa.EventId equals ev.ID group new {ev, pa} by new { ev.Name } into newgroup
                         select new
                         {
                             EventName = newgroup.Key.Name, 
                             Count = newgroup.Count()
                         }).ToList();
            foreach (var elem in EventParticipants)
            {
                Query q = new Query();
                q.Name = elem.EventName;
                q.Count = elem.Count;
                Queries.Add(q);
            }
            Console.WriteLine(Queries);
        }

    }
    public class Query
    {
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
