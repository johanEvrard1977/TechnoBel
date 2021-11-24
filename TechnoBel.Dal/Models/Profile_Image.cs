using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Profile_Image
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ImageId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Image Image { get; set; }
    }
}
