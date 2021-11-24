using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class Projet_TechnologieApi
    {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public int TechnologieId { get; set; }
        public virtual ProjetApi Projet { get; set; }
        public virtual TechnologieApi Technologie { get; set; }
    }
}
