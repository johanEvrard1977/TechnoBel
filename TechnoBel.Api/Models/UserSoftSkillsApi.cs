using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserSoftSkillsApi
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SoftSkillsId { get; set; }
        public virtual UserApi User { get; set; }
        public virtual SoftSkillsApi SoftSkill { get; set; }
    }
}
