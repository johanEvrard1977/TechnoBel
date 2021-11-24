using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class FiliereApi : BasicInformationApi
    {
        [Required]
        public int Annee { get; set; }
        public string Description  { get; set; }
        public IEnumerable<UserFiliereApi> UserFiliere { get; set; }
        public IEnumerable<FiliereTechonologieApi> FiliereTechonologies { get; set; }
        public IEnumerable<Filiere_ImageApi> Filiere_Images { get; set; }
    }
}
