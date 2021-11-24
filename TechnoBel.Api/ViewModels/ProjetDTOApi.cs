using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;

namespace TechnoBel.Api.ViewModels
{
    public class ProjetDTOApi : BasicInformationApi
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
