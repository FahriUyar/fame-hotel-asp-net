using Microsoft.EntityFrameworkCore;

namespace Fame_Hotel.Models
{
    public class FameHotelContext : DbContext
    {
        public FameHotelContext(DbContextOptions<FameHotelContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}