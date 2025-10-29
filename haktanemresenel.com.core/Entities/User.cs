using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string NameSurname { get; set; }

        public string Password { get; set; }
    }
}
