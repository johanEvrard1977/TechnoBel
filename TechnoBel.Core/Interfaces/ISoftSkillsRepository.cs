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
    public interface ISoftSkillsRepository : IRepository<int, SoftSkills>
    {
        Task<IEnumerable<SoftSkills>> Get(string Name);
        Task<PagedList<SoftSkills>> GetSoftSkills(Parameters Parameters);
        Task<bool> AlreadyExists(int id);
    }
}
