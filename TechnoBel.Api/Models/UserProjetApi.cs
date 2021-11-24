using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class UserProjetApi
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StagiaireId { get; set; }
        public int ProjetId { get; set; }
        public virtual UserApi User { get; set; }
        public virtual ProjetApi Projet { get; set; }
    }
}
