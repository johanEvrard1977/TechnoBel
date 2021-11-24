using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class CurriculumVitaeApi
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public string MimeType { get; set; }
        public IEnumerable<UserApi> User { get; set; }
    }
}
