using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class CategorieDeProjet : BasicInformation
    {
        public virtual IEnumerable<Projet_Categorie> Projet_categories { get; set; }
    }
}
