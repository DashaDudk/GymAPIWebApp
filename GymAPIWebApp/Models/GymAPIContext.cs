using Microsoft.EntityFrameworkCore;

namespace GymAPIWebApp.Models
{
    public class GymAPIContext : DbContext
    {
        public virtual DbSet <User>  Users { get; set; }
        public virtual DbSet <UserGym> UserGyms { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public GymAPIContext (DbContextOptions<GymAPIContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
