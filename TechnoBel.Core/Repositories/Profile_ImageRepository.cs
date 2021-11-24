using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Interfaces;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Repositories
{
    public class Profile_ImageRepository : Repository<int, Profile_Image>, IProfile_ImageRepository
    {
        private readonly Context _context;
        public Profile_ImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Profile_Image> GetByProfileId(int profilId)
        {
            var request = from profiles in _context.profile_Images
                .Where(w => w.ProfileId == profilId)
                          select profiles;

            if (request.FirstOrDefault().ProfileId != 0)
            {

                return await request
                        .FirstAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
