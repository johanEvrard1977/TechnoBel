using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.ViewModels
{
    public class ViewRegisterApi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(30)]
        [MinLength(8)]
        [DisplayName(displayName: "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [MaxLength(255)]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int FiliereId { get; set; }
        public int LangueId { get; set; }
    }
}
