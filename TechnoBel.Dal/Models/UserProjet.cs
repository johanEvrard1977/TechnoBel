using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class UserProjet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StagiaireId { get; set; }
        public int ProjetId { get; set; }
        public virtual User User { get; set; }
        public virtual Projet Projet { get; set; }
    }
}
