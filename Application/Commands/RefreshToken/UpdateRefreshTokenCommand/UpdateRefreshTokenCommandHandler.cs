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

namespace Application.Commands.RefreshToken.UpdateRefreshTokenCommand
{
    public class UpdateRefreshTokenCommandHandler : IRequestHandler<UpdateRefreshTokenCommand, RefreshTokenVm>
    {
        private readonly IDBContext _dBContext;

        public UpdateRefreshTokenCommandHandler(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<RefreshTokenVm> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = _dBContext.RefreshTokens.FirstOrDefault(x=> x.Id == request.Id);

            if (refreshToken == null)
            {
                throw new NotFoundException("Refresh token", request.Id);
            }

            refreshToken.Token = request.Token;
            refreshToken.ToLife = refreshToken.ToLife;

            _dBContext.Entry(refreshToken).State = EntityState.Modified;

            await _dBContext.SaveChangesAsync(cancellationToken);

            return new RefreshTokenVm()
            {
                Id = refreshToken.Id,
                Token = refreshToken.Token,
                ToLife = refreshToken.ToLife
            };
        }
    }
}
