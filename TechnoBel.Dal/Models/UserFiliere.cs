using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class UserFiliere
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FiliereId { get; set; }
        public virtual User User { get; set; }
        public virtual Filiere Filiere { get; set; }
    }
}
