using haktanemresenel.com.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.EntityConfigurations
{
    public class AdminUserConfiguration : IEntityTypeConfiguration<AdminUser>
    {
        public void Configure(EntityTypeBuilder<AdminUser> builder)
        {

            builder.HasKey(x => x.Id);  

            builder.Property(y=>y.NameSurname).IsRequired();

            builder.Property(y => y.NameSurname).IsRequired();

            builder.Property(y => y.Password).IsRequired();

        }
    }
}
