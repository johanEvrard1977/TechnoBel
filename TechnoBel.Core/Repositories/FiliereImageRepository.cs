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
    public class FiliereImageRepository : Repository<int, Filiere_Image>, IFiliereImageRepository
    {
        private readonly Context _context;
        public FiliereImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Filiere_Image> GetByFiliereId(int filiereId)
        {
            var request = from filieres in _context.Filiere_Images
                .Where(w => w.FiliereId == filiereId)
                          select filieres;

            if (request.FirstOrDefault().FiliereId != 0)
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