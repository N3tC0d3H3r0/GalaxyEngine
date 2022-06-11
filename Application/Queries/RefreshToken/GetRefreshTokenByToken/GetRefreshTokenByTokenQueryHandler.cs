using Application.Interfaces;
using Application.Models.AuthModels.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.RefreshToken.GetRefreshTokenByToken
{
    public class GetRefreshTokenByTokenQueryHandler : IRequestHandler<GetRefreshTokenByTokenQuery, RefreshTokenVm>
    {
        private readonly IDBContext _dBContext;

        public GetRefreshTokenByTokenQueryHandler(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<RefreshTokenVm> Handle(GetRefreshTokenByTokenQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await _dBContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token == request.Token, cancellationToken);

            if (refreshToken == null)
            {
                return null;
            }

            return new RefreshTokenVm()
            {
                Id = refreshToken.Id,
                Token = refreshToken.Token,
                ToLife = refreshToken.ToLife
            };
        }
    }
}
