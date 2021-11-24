using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.ParametersModels
{
    public class GetProfileParameters
    {
        public string Email { get; set; }
        public List<string> Names { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
    }
}
