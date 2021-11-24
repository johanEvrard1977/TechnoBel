using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;

namespace TechnoBel.Api.ViewModels
{
    public class FiliereDTOApi : BasicInformationApi
    {
        public string MimeType { get; set; }
        public byte[] File { get; set; }
    }
}
