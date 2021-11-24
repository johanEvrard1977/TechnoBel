using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class SoftSkills : BasicInformation
    {
        public virtual IEnumerable<UserSoftSkills> UserSoftSkills { get; set; }
    }
}
