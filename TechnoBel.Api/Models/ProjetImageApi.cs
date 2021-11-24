using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ProjetImageApi
    {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public int ImageId { get; set; }
        public virtual ProjetApi Projet { get; set; }
        public virtual ImageApi Image { get; set; }
        public string ImageUri { get; set; }
    }
}
