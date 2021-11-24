using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ProjetApi : BasicInformationApi
    {
        public string Description { get; set; }
        public string Resume { get; set; }
        public int? CategorieId { 
            get { return Projet_categories.FirstOrDefault()?.CategorieId; } 
        }
        public int? StagiaireId { get { return UserProjet.FirstOrDefault()?.UserId; } }
        public int? ImageId { get { return ProjetImages.FirstOrDefault()?.ImageId; } }
        public virtual IEnumerable<Projet_CategorieApi> Projet_categories { get; set; }
        public virtual IEnumerable<UserProjetApi> UserProjet { get; set; }
        public virtual IEnumerable<ProjetImageApi> ProjetImages { get; set; }
        public virtual IEnumerable<Projet_TechnologieApi> Projet_Technologies { get; set; }
    }
}
