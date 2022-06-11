using Application.Interfaces;
using Application.Models.AuthModels.VMs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.RefreshToken.CreateRefreshTokenCommand
{
    public class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommand, RefreshTokenVm>
    {
        public readonly IDBContext _dBContext;

        public CreateRefreshTokenCommandHandler(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<RefreshTokenVm> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = new Domain.RefreshToken
            {
                Id = request.Id,
                Token = request.Token,
                ToLife = request.ToLife
            };

            _dBContext.RefreshTokens.Add(refreshToken);

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
