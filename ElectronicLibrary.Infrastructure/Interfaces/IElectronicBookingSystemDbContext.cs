using ElectronicBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBookingSystem.Infrastructure.Interfaces
{
    public interface IElectronicBookingSystemDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}