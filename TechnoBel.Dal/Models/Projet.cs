using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Projet : BasicInformation
    {
        public string Description { get; set; }
        public string Resume { get; set; }
        public virtual IEnumerable<Projet_Categorie> Projet_categories { get; set; }
        public IEnumerable<UserProjet> UserProjet { get; set; }
        public virtual IEnumerable<ProjetImage> ProjetImages { get; set; }
        public virtual IEnumerable<Projet_Technologie> Projet_Technologies { get; set; }
    }
}
