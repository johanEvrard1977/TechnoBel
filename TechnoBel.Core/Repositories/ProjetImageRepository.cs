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
    public class ProjetImageRepository : Repository<int, ProjetImage>, IProjetImageRepository
    {
        private readonly Context _context;
        public ProjetImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjetImage> GetByProjetId(int projetId)
        {
            var request = from projets in _context.ProjetImages
                .Where(w => w.ProjetId == projetId)
                          select projets;

            if(request.FirstOrDefault().ProjetId != 0)
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
