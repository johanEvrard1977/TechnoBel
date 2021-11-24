using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Projet_Categorie
    {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public int CategorieId { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual CategorieDeProjet Categorie { get; set; }
    }
}
