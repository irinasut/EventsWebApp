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

        public List<EventParticipantsData> EventParticipants { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
            EventParticipants = new List<EventParticipantsData>();

            var queryCount = (from ev in _context.Events
                         join pa in _context.Participants
                         on ev.ID equals pa.EventId group new {ev, pa} by new { ev.Name } into newgroup
                         select new
                         {
                             EventName = newgroup.Key.Name, 
                             Count = newgroup.Count()
                         }).ToList();
             foreach (var elem in queryCount)
            {
                EventParticipantsData q = new EventParticipantsData();
                q.Name = elem.EventName;
                q.Count = elem.Count;
                EventParticipants.Add(q);
            }
        }

    }
    public class EventParticipantsData
    {
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
