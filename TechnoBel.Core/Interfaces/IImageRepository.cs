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
    public interface IImageRepository : IRepository<int, Image>
    {
        Task<bool> AlreadyExists(int id);
        Task<PagedList<Image>> GetImages(Parameters Parameters);
    }
}
