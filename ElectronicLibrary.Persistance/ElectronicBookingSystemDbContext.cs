using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance
{
    public class ElectronicBookingSystemDbContext : DbContext, IElectronicBookingSystemDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Address> Addresses { get; set; }

        //dodacsety i  changetracker, przeciazyc savechanges



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CorrectModificationFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsyncWithoutUser()
        {
            return await base.SaveChangesAsync();
        }

        private void CorrectModificationFields()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Modified)
                {
                    ((BaseEntity)entry.Entity).LMDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).LMEmail = _currentUserService?.Email;
                }
                else if(entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).LMDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).LMEmail = _currentUserService?.Email;
                    ((BaseEntity)entry.Entity).CreateDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).CreateEmail = _currentUserService?.Email;
                }
            }
        }

        public ElectronicBookingSystemDbContext()
        {

        }

        public ElectronicBookingSystemDbContext(DbContextOptions<ElectronicBookingSystemDbContext> options) : base(options)
        {

        }

        public ElectronicBookingSystemDbContext(DbContextOptions<ElectronicBookingSystemDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectronicBookingSystemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
