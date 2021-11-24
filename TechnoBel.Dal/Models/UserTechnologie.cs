using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class UserTechnologie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TechnologieId { get; set; }
        public virtual User User { get; set; }
        public virtual Technologie Technologie { get; set; }
    }
}
