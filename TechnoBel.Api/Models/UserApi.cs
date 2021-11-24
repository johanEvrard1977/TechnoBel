using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserApi
    {
        public int Id { get; set; }
        [MaxLength(75)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [MaxLength(75)]
        [MinLength(2)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [MaxLength(255)]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 8, ErrorMessage = "vous devez spécifier un mot de passe compris entre 8 et 30 caractères" +
            "avec un chiffre compris entre 0 et 9, contenir au moins une minuscule et une majuscule," +
            "contenir un caractere special tel que @,#,$ ou %")]
        //doit contenit au moins un chiffre entre 0 et 9 (?=.*\d)
        //doit contenir au moins une minuscule et une majuscule (?=.*[a-z])  (?=.*[A-Z]) 
        //doit contenir un caractere special tel que @,#,$ ou %
        // doit matcher avec ce qu'il vient d'être définit: .
        // au moins 8 caractères et au plus 30 caractères {8,30}
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,30})(?=.*\\d)(?=.*[a - z])(?=.*[A - Z])(?=.*[@#$%].{8, 40})")]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string UserName { get; set; }
        public string Role { get; set; }
        public int? CurriculumVitaeId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? Updatedate { get; set; }
        public virtual IEnumerable<UserRoleApi> UserRoles { get; set; }
        public virtual IEnumerable<ProfileApi> Profiles { get; set; }
        public virtual IEnumerable<UserTechnologieApi> UserTechnologies { get; set; }
        public virtual IEnumerable<UserFiliereApi> UserFiliere { get; set; }
        public virtual IEnumerable<UserProjetApi> UserProjet { get; set; }
        public virtual IEnumerable<UserBadgeApi> UserBadges { get; set; }
        public virtual IEnumerable<UserSoftSkillsApi> UserSoftSkills { get; set; }
        public virtual CurriculumVitaeApi Curriculum { get; set; }
        public virtual IEnumerable<ExperienceApi> Experiences { get; set; }
    }
}
