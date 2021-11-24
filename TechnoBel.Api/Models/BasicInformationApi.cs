using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class BasicInformationApi
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(75)]
        [MinLength(2)]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
