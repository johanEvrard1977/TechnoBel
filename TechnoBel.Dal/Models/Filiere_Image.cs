using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Filiere_Image
    {
        public int Id { get; set; }
        public int FiliereId { get; set; }
        public int ImageId { get; set; }
        public virtual Filiere Filiere { get; set; }
        public virtual Image Image { get; set; }
    }
}
