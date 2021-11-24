using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Hobby_Profile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int HobbyId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Hobbies Hobbies { get; set; }
    }
}
