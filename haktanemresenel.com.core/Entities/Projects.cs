using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Entities
{
    public class Projects 
    {
        
        public Guid Id { get; set; }
        public Guid LandingPageOwnerId { get; set; }
        public string WorkedCompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
