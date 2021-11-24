using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class FiliereTechonologie
    {
        public int Id { get; set; }
        public int FiliereId { get; set; }
        public int TechnologieId { get; set; }
        public virtual Filiere Filiere { get; set; }
        public virtual Technologie Technologie { get; set; }
    }
}
