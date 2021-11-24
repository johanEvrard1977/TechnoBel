using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class CategorieDeProjetApi : BasicInformationApi
    {
        public virtual IEnumerable<Projet_CategorieApi> Projet_categories { get; set; }
    }
}
