using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class FiliereTechonologieApi
    {
        public int Id { get; set; }
        public int FiliereId { get; set; }
        public int TechnologieId { get; set; }
        public virtual FiliereApi Filiere { get; set; }
        public virtual TechnologieApi Technologie { get; set; }
    }
}
