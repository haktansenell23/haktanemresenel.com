using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Models
{
    public class SessionModel
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsMasterAdmin { get; set; }
    }
}
