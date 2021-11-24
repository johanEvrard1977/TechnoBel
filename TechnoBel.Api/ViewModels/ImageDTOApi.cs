using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;

namespace TechnoBel.Api.ViewModels
{
    public class ImageDTOApi
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public virtual IEnumerable<ProjetImageApi> ProjetImages { get; set; }
    }
}
