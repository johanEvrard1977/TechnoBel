using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class UserBadge
    {
        public int Id { get; set; }
        public int BadgeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Badge Badge { get; set; }
    }
}
