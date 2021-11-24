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
    public class UserRepository : Repository<int, User>, IUserRepository
    {
        private readonly Context _context;
        private readonly DbSet<User> _entities;
        public UserRepository(Context context) : base(context)
        {
            _context = context;
            _entities = _context.Set<User>();
        }


        public async Task<User> GetOne(int id, bool lazyLoading)
        {
            if (lazyLoading)
            {
                return await _entities
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include( e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }
            return await _entities.FirstAsync();
        }
        public async Task<User> GetByMail(string email)
        {
            try
            {
                return await _entities
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.Email.Equals(email))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
            
        }
        public async Task<IEnumerable<User>> Get(string lastname = null, string role = null, string email = null, List<string> Names = null)
        {
            var request = from users in _context.User select users;
            if (lastname != null)
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.LastName.Equals(lastname))
                    .OrderBy(w => w.LastName);
            }
            else if (role != null)
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.UserRoles.FirstOrDefault().Role.Name.Equals(role))
                    .OrderBy(w => w.LastName);
            }
            else if (email != null)
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.Email.Equals(email))
                    .OrderBy(w => w.LastName);
            }
            else if(lastname != null && role != null)
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.LastName.Equals(lastname))
                    .Where(w => w.UserRoles.FirstOrDefault().Role.Name.Equals(role))
                    .OrderBy(w => w.LastName);
            }
            else if (lastname != null && email != null)
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .Where(w => w.LastName.Equals(lastname))
                    .Where(w => w.Email.Equals(email))
                    .OrderBy(w => w.LastName);
            }
            else if (Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                return _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.User);
            }
            else if ( lastname != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                IEnumerable<User> result = _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Where(w => w.User.LastName.Equals(lastname))
                    .Select(ft => ft.User);
                if (result == null)
                {
                    result = _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Where(w => w.User.FirstName.Equals(lastname))
                    .Select(ft => ft.User);
                }
                return result;
            }
            else if (email != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<User>  result = _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Where(w => w.User.Email.Equals(email))
                    .Select(ft => ft.User);
                return result;
            }
            else if (lastname != null && Names != null && Names[0] != null && email != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<User> result = _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Where(w => w.User.Email.Equals(email))
                    .Where(w => w.User.LastName.Contains(lastname))
                    .Select(ft => ft.User);
                if (result == null)
                {
                    result = _context.UserTechnologies.Include(ft => ft.User).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Where(w => w.User.Email.Equals(email))
                    .Where(w => w.User.FirstName.Contains(lastname))
                    .Select(ft => ft.User);
                }
                return result;
            }
            else
            {
                request = request
                    .Include(e => e.UserRoles)
                    .ThenInclude(e => e.Role)
                    .Include(e => e.UserProjet)
                    .ThenInclude(e => e.Projet)
                    .Include(e => e.UserTechnologies)
                    .ThenInclude(e => e.Technologie)
                    .Include(e => e.UserBadges)
                    .ThenInclude(e => e.Badge)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.Experiences)
                    .Include(e => e.Profiles)
                    .OrderBy(w => w.LastName);
            }

            return await request.ToListAsync();
        }


        public async Task<bool> UserMailExists(string mail)
        {
            if (await _context.User.AnyAsync(e => e.Email == mail))
                return true;
            return false;
        }


        public async Task<bool> AlreadyExists(string id)
        {
            if (await _context.User.AnyAsync(e => e.Id.Equals(id)))
                return true;
            return false;
        }

        public async Task<PagedList<User>> GetUsers(Parameters Parameters)
        {
            List<User> users = await _context.User.ToListAsync();
            return PagedList<User>
                .ToPagedList(users, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}