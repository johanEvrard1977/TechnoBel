using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ProfileTechnologieApi
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int TechnologieId { get; set; }
        public virtual ProfileApi Profile { get; set; }
        public virtual TechnologieApi Technologie { get; set; }
    }
}
