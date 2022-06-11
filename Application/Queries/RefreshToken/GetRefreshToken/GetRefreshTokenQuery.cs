using Application.Models.AuthModels.VMs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RefreshToken.GetRefreshToken
{
    public class GetRefreshTokenQuery : IRequest<RefreshTokenVm>
    {
        public string Id { get; set; }
    }
}
