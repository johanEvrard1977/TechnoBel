using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class BadgeApi : BasicInformationApi
    {
        public string Description { get; set; }
        public IEnumerable<UserBadgeApi> UserBadges { get; set; }
    }
}
