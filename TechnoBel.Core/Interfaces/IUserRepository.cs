using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Core.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {

        Task<IEnumerable<User>> Get(string lastname, string role, string email, List<string> Names);
        Task<User> GetOne(int id, bool lazyLoading);
        Task<bool> UserMailExists(string mail);
        Task<User> GetByMail(string email);
        Task<bool> AlreadyExists(string id);
        Task<PagedList<User>> GetUsers(Parameters Parameters);
    }
}
