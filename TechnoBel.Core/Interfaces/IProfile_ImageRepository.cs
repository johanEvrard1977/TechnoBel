using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IProfile_ImageRepository : IRepository<int, Profile_Image>
    {
        Task<Profile_Image> GetByProfileId(int profileId);
    }
}
