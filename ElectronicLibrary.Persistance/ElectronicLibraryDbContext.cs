using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance
{
    public class ElectronicLibraryDbContext : DbContext
    {

        //dodacsety

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
