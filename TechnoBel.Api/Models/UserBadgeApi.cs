using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserBadgeApi
    {
        public int Id { get; set; }
        public int BadgeId { get; set; }
        public int UserId { get; set; }
        public UserApi User { get; set; }
        public BadgeApi Badge { get; set; }
    }
}
