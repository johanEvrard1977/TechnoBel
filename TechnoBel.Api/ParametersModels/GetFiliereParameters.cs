using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.ParametersModels
{
    public class GetFiliereParameters
    {
        public List<string> Names { get; set; }
        public string Name { get; set; }
        public int Annee { get; set; }
    }
}
