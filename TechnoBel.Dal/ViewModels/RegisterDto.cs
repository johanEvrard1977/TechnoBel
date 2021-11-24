using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Dal.ViewModels
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vous devez spécifier un mot de passe compris entre 3 et 30 caractères")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Lastname { get; set; }
        public int RoleId { get; set; }
        public int FiliereId { get; set; }
        public int LangueId { get; set; }
    }
}
