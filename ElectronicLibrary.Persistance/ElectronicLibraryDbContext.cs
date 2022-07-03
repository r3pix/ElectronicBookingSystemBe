using ElectronicLibrary.Domain.Entities;
using ElectronicLibrary.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance
{
    public class ElectronicLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Service> Services { get; set; }
        //dodacsety i  changetracker, przeciazyc savechanges

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //tutaj autouzupelnianie
            return base.SaveChangesAsync(cancellationToken);
        }

        public ElectronicLibraryDbContext(DbContextOptions<ElectronicLibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectronicLibraryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
