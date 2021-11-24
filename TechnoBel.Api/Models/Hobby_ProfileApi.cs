using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class Hobby_ProfileApi
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int HobbyId { get; set; }
        public virtual ProfileApi Profile { get; set; }
        public virtual HobbiesApi Hobbies { get; set; }
    }
}
