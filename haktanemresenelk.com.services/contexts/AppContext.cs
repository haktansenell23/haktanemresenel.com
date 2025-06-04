using haktanemresenel.com.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenelk.com.services.contexts
{
    public class AppContext : DbContext
    {
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<EducationInformation> EducationInformations { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public AppContext()
        {
                
        }
    }
}
