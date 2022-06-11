using Application.Common.Exceptions;
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

namespace Application.Queries.RefreshToken.GetRefreshToken
{
    public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQuery, RefreshTokenVm>
    {
        private readonly IDBContext _dBContext;

        public GetRefreshTokenQueryHandler(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<RefreshTokenVm> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await _dBContext.RefreshTokens.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

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
