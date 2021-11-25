using Microsoft.EntityFrameworkCore;
using TrainManagerApp.Models;

namespace TrainManagerApp.Data
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Train> Trains { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "dima@mail.ua";
            string adminPassword = "463882";

            UserRole adminRole = new UserRole { Id = 1, Name = adminRoleName };
            UserRole userRole = new UserRole { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
