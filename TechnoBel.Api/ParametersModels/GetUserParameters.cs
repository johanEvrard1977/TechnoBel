using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionContact.ParametersModels
{
    public class GetUserParameters
    {
        public string role { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public List<string> Names { get; set; }
    }
}
