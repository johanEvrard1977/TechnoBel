using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserTechnologieApi
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TechnologieId { get; set; }
        public virtual UserApi User { get; set; }
        public virtual TechnologieApi Technologie { get; set; }
    }
}
