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
    public class ImageRepository : Repository<int, Image>, IImageRepository
    {
        private readonly Context _context;
        public ImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Hobby.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<PagedList<Image>> GetImages(Parameters Parameters)
        {
            List<Image> hobbies = await _context.Images.ToListAsync();
            return PagedList<Image>
                .ToPagedList(hobbies, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}