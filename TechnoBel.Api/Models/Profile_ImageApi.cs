using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class Profile_ImageApi
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ImageId { get; set; }
        public string ImageUri { get; set; }
        public virtual ProfileApi Profile { get; set; }
        public virtual ImageApi Image { get; set; }
    }
}
