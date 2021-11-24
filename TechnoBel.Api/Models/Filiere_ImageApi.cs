using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class Filiere_ImageApi
    {
        public int Id { get; set; }
        public int FiliereId { get; set; }
        public int ImageId { get; set; }
        public string ImageUri { get; set; }
        public virtual FiliereApi Filiere { get; set; }
        public virtual ImageApi Image { get; set; }
    }
}
