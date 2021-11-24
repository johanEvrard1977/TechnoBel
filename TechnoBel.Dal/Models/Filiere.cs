using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Filiere : BasicInformation
    {
        public int Annee { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserFiliere> UserFiliere { get; set; }
        public IEnumerable<FiliereTechonologie> FiliereTechonologies { get; set; }
        public IEnumerable<Filiere_Image> Filiere_Images { get; set; }
    }
}
