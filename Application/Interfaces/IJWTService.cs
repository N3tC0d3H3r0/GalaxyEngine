using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJWTService
    {
        string CreateToken(User user);
        Task<string> CreateRefreshToken(User user);

        ClaimsIdentity GetIdentity(User user);
    }
}
