using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Statut : BasicInformation
    {
        public virtual IEnumerable<Profile> Profiles { get; set; }
    }
}
