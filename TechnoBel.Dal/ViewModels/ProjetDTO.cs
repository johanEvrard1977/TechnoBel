using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Dal.ViewModels
{
    public class ProjetDTO : BasicInformation
    {
        public string Description { get; set; }
        public string Resume { get; set; }
        public List<int> CategorieId { get; set; }
        public List<int> StagiaireId { get; set; }
        public int UserId { get; set; }
        public string MimeType { get; set; }
        public byte[] File { get; set; }
    }
}
