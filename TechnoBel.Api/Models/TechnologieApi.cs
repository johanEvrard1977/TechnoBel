using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class TechnologieApi : BasicInformationApi
    {
        public IEnumerable<UserTechnologieApi> UserTechnologies { get; set; }
        public IEnumerable<FiliereTechonologieApi> FiliereTechonologies { get; set; }
        public virtual IEnumerable<Projet_TechnologieApi> Projet_Technologies { get; set; }
        public virtual IEnumerable<ProfileTechnologieApi> ProfileTechnologies { get; set; }
    }
}
