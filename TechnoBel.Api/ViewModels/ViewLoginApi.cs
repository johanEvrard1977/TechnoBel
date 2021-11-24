using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.ViewModels
{
    public class ViewLoginApi
    {
        [Required(ErrorMessage = "Required is required")]
        [DisplayName(displayName: "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
