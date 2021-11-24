using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class UserSoftSkills
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SoftSkillsId { get; set; }
        public virtual User User { get; set; }
        public virtual SoftSkills SoftSkill { get; set; }
    }
}
