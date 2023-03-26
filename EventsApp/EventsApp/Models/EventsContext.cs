using Microsoft.EntityFrameworkCore;
using System;

namespace EventsApp.Models
{
    public class EventsContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EventsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // create models -> representing database tables
        public DbSet<EventsModel> Events { get; set; }
        public DbSet<ParticipantsModel> Participants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("EventsContext"));
        }
    }
}
