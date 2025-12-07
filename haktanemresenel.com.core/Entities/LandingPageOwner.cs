using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Entities
{
    public class LandingPageOwner
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string ResumeInformation { get; set; }
        public string NameSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<EducationInformation> EducationInformations { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Projects> Projects { get; set; }
    }
}
