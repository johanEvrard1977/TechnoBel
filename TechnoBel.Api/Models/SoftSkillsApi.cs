using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class SoftSkillsApi : BasicInformationApi
    {
        public virtual IEnumerable<UserSoftSkillsApi> UserSoftSkills { get; set; }
    }
}
