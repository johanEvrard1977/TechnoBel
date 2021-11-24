using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class StatutApi : BasicInformationApi
    {
        public virtual IEnumerable<ProfileApi> Profiles { get; set; }
    }
}
