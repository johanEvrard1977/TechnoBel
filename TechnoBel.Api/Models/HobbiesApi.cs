using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class HobbiesApi : BasicInformationApi
    {
        public virtual IEnumerable<Hobby_ProfileApi> Hobby_Profiles { get; set; }
    }
}
