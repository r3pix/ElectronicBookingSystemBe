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
        public DbSet<User> Users { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //dodacsety i  changetracker, przeciazyc savechanges

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //tutaj autouzupelnianie
            return base.SaveChangesAsync(cancellationToken);
        }

        public ElectronicBookingSystemDbContext(DbContextOptions<ElectronicBookingSystemDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectronicBookingSystemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
