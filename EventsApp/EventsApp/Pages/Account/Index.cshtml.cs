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
                              on ev.ID equals pa.EventId
                              group new { ev, pa } by new { ev.Name } into newgroup
                              select new
                              {
                                  EventName = newgroup.Key.Name,
                                  Count = newgroup.Count()
                              }).ToList();
            foreach (var elem in queryCount)
            {
                EventParticipantsData q = CreateEventParticipantsData(elem.EventName, elem.Count);
                EventParticipants.Add(q);
            }

            // adding events with no participants
            foreach (var elem in _context.Events)
            {
                var a = EventParticipants.Find(el => el.Name == elem.Name);

                if (a == null)
                {
                    EventParticipantsData q = CreateEventParticipantsData(elem.Name, 0);
                    EventParticipants.Add(q);
                }
            }

            EventParticipants.Sort((a, b) => a.Count < b.Count ? 1 : -1);

        }

        public EventParticipantsData CreateEventParticipantsData(string name, int count)
        {
            EventParticipantsData data = new EventParticipantsData();
            data.Name = name;
            data.Count = count;

            return data;
        }
    }


    public class EventParticipantsData
    {
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
