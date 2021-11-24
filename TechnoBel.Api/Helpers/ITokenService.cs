using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Dal.ViewModels;

namespace GestionContact.Helpers
{
    public interface ITokenService
    {
        string GenerateToken(LoginSuccessDto user);
        LoginSuccessDto ValidateToken(string token);
    }
}
