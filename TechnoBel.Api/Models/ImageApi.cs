using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ImageApi
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "File is required")]
        public byte[] File { get; set; }
        [Required(ErrorMessage = "MimeType is required")]
        public string MimeType { get; set; }
        public virtual IEnumerable<ProjetImageApi> ProjetImages { get; set; }
        public IEnumerable<Filiere_ImageApi> Filiere_Images { get; set; }
        public virtual IEnumerable<Profile_ImageApi> ProfileImages { get; set; }
    }
}
