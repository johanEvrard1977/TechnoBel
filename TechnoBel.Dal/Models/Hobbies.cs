using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Hobbies : BasicInformation
    {
        public virtual IEnumerable<Hobby_Profile> Hobby_Profiles { get; set; }
    }
}
