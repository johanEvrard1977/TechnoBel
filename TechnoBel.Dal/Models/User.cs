using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? Updatedate { get; set; }
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        public virtual IEnumerable<Profile> Profiles { get; set; }
        public virtual IEnumerable<UserTechnologie> UserTechnologies { get; set; }
        public virtual IEnumerable<UserFiliere> UserFiliere { get; set; }
        public virtual IEnumerable<UserProjet> UserProjet { get; set; }
        public virtual IEnumerable<UserBadge> UserBadges { get; set; }
        public virtual IEnumerable<UserSoftSkills> UserSoftSkills { get; set; }
        public virtual CurriculumVitae Curriculum { get; set; }
        public virtual IEnumerable<Experience> Experiences { get; set; }
    }
}
