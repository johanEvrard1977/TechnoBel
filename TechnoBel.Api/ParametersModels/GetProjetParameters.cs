using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.ParametersModels
{
    public class GetProjetParameters
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<string> Names { get; set; }
        public string UserName { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public List<string> Sujets { get; set; }
    }
}
