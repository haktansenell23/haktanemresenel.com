using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Entities
{
    public class EducationInformation
    {
        public Guid Id { get; set; }

        public Guid LandingPageOwnerId { get; set; }
        public LandingPageOwner LandingPageOwner { get; set; }

        public string EducationSchoolName { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ExtraInformations { get; set; }
    }
}
