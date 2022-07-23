using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance
{
    public class ElectronicBookingSystemDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //dodacsety i  changetracker, przeciazyc savechanges

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CorrectModificationFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void CorrectModificationFields()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Modified)
                {
                    ((BaseEntity)entry.Entity).LMDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).LMEmail = _currentUserService.Email;
                }
                else if(entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).LMDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).LMEmail = _currentUserService.Email;
                    ((BaseEntity)entry.Entity).CreateDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).CreateEmail = _currentUserService.Email;
                }
            }
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
