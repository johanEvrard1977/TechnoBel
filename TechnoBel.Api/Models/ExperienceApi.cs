using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ExperienceApi
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Titre { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public UserApi User { get; set; }
    }
}
