using haktanemresenel.com.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.repository.Repository.contexts
{
    public class AppContext : DbContext
    {
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<EducationInformation> EducationInformations { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public AppContext():base()
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            base.OnConfiguring(optionsBuilder);
        }

    }

}
