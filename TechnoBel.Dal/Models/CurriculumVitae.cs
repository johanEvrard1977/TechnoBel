using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class CurriculumVitae
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public string MimeType { get; set; }
        public IEnumerable<User> User { get; set; }
    }
}
