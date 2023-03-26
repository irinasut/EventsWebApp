using EventsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Data
{
    public class EventsContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EventsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // create models -> representing database tables
        public DbSet<Events> Events { get; set; }
        public DbSet<Participants> Participants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("EventsContext"));
        }
    }
}
