using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Technologie : BasicInformation
    {
        public IEnumerable<UserTechnologie> UserTechnologies { get; set; }
        public IEnumerable<FiliereTechonologie> FiliereTechonologies { get; set; }
        public virtual IEnumerable<Projet_Technologie> Projet_Technologies { get; set; }
        public virtual IEnumerable<ProfileTechnologie> ProfileTechnologies { get; set; }
    }
}
