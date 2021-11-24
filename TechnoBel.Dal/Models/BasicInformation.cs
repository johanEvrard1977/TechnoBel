using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class BasicInformation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
