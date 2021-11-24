using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class ProjetImage
    {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public int ImageId { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual Image Image { get; set; }
    }
}
