using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public string MimeType { get; set; }
        public virtual IEnumerable<ProjetImage> ProjetImages { get; set; }
        public IEnumerable<Filiere_Image> Filiere_Images { get; set; }
        public virtual IEnumerable<Profile_Image> ProfileImages { get; set; }
    }
}
