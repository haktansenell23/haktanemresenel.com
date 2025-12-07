using haktanemresenel.com.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Entities
{
    public class Ability
    {

        public Guid Id { get; set; }
        public Guid EducationInformationId { get; set; }
        public AbilitiyEnum AbilityType { get; set; }
    }
}
