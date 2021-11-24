using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Badge : BasicInformation
    {
        public string Description { get; set; }
        public IEnumerable<UserBadge> UserBadges { get; set; }
    }
}
