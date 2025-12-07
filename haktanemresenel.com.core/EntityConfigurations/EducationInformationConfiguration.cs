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
    public class EducationInformationConfiguration : IEntityTypeConfiguration<EducationInformation>
    {
        public void Configure(EntityTypeBuilder<EducationInformation> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(e => e.LandingPageOwner)       
           .WithMany(o => o.EducationInformations) 
           .HasForeignKey(e => e.LandingPageOwnerId) 
           .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}
