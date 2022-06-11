using Application.Models.AuthModels.VMs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RefreshToken.GetRefreshTokenByToken
{
    public class GetRefreshTokenByTokenQuery : IRequest<RefreshTokenVm>
    {
        public Guid Token { get; set; }
    }
}
