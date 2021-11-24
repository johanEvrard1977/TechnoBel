using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserFiliereApi
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FiliereId { get; set; }
        public virtual UserApi User { get; set; }
        public virtual FiliereApi Filiere { get; set; }
    }
}
