using Application.Models.AuthModels.VMs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RefreshToken.CreateRefreshTokenCommand
{
    public class CreateRefreshTokenCommand : IRequest <RefreshTokenVm>
    {
        public string Id { get; set; }
        public Guid Token { get; set; }
        public DateTime ToLife { get; set; }
    }
}
