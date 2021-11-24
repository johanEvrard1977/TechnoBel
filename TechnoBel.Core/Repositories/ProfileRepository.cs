using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Interfaces;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Core.Repositories
{
    public class ProfileRepository : Repository<int, Profile>, IProfileRepository
    {
        private readonly Context _context;
        public ProfileRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Profile.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Profile>> Get(string Name, string FirstName, string email, List<string> Names = null)
        {
            var request = from contacts in _context.Profile select contacts;
            if (Name != null)
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .Where(w => w.UserName.Contains(Name))
                    .OrderBy(w => w.UserName);
                if(request == null){
                    request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .Where(w => w.UserName.Contains(Name))
                    .OrderBy(w => w.UserName);
                }
            }
            else if (FirstName != null)
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .Where(w => w.Firstname.Contains(FirstName))
                    .OrderBy(w => w.Firstname);
            }
            else if (email != null)
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .Where(w => w.Email.Contains(email))
                    .OrderBy(w => w.Firstname);
            }
            else if (Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                return _context.ProfileTechnologies.Include(ft => ft.Profile).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Profile);
            }
            else if ( FirstName != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                request = _context.ProfileTechnologies.Include(ft => ft.Profile).Include(ft => ft.Technologie)
                    .Where(ft => ft.Profile.Firstname.Contains(FirstName))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Profile);
                if (request == null)
                {
                    request = _context.ProfileTechnologies.Include(ft => ft.Profile).Include(ft => ft.Technologie)
                    .Where(ft => ft.Profile.Firstname.Contains(FirstName))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Profile);
                }
            }
            else if (email != null && FirstName != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                request = _context.ProfileTechnologies.Include(ft => ft.Profile).Include(ft => ft.Technologie)
                    .Where(ft => ft.Profile.Email.Contains(email))
                    .Where(ft => ft.Profile.Firstname.Contains(FirstName))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Profile);
                if (request == null)
                {
                    request = _context.ProfileTechnologies.Include(ft => ft.Profile).Include(ft => ft.Technologie)
                    .Where(ft => ft.Profile.Email.Contains(email))
                    .Where(ft => ft.Profile.Firstname.Contains(FirstName))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Profile);
                }
            }
            else
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .OrderBy(w => w.Firstname);
            }
            return await request.ToListAsync();
        }

        public async Task<Profile> GetByUserId(int userId)
        {
            var request = from profiles in _context.Profile select profiles;
            request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.User)
                    .Where(w => w.UserId == userId)
                    .Include(w => w.Statut)
                    .Include(w => w.ProfileImages)
                    .OrderBy(w => w.Firstname);
           
            return await request.FirstAsync();
        }

        public async Task<PagedList<Profile>> GetProfiles(Parameters Parameters)
        {
            List<Profile> profiles = await _context.Profile.ToListAsync();
            return PagedList<Profile>
                .ToPagedList(profiles, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
