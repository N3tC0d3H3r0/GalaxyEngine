using Application.Models.AuthModels.DTOs;
using Application.Models.AuthModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthSuccessVm> Authorize(AuthCredentialDto model);

        Task<AuthSuccessVm> Refresh(AuthRefreshTokenDto model);
    }
}
