using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.ViewModels
{
    public class StagiaireDTO
    {
        public string Titre { get; set; }
        public string UserName { get; set; }
        public string Apropos { get; set; }
        public int BadgeId { get; set; }
        public int AuteurId { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public string MimeType { get; set; }
        public Byte[] FileCv { get; set; }
        public string MimeTypeCv { get; set; }
    }
}
