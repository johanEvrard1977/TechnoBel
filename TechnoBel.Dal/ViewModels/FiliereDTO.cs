using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Dal.ViewModels
{
    public class FiliereDTO : BasicInformation
    {
        public int UserId { get; set; }
        public string MimeType { get; set; }
        public byte[] File { get; set; }
    }
}
