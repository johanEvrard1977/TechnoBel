using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class RoleApi : BasicInformationApi
    {
        public virtual IEnumerable<UserRoleApi> UserRoles { get; set; }
    }
}
