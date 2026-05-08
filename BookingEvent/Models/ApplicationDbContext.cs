using Microsoft.EntityFrameworkCore;
namespace BookingEvent.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


    }
}
