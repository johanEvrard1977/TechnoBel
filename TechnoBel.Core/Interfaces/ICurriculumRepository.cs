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
    public interface ICurriculumRepository : IRepository<int, CurriculumVitae>
    {
        Task<bool> AlreadyExists(int id);
        Task<PagedList<CurriculumVitae>> GetImages(Parameters Parameters);
    }
}
