using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontGlobalSettings.GetFrontGlobalSettingsList
{
    public class GetFrontGlobalSettingListQueryHandler : IRequestHandler<GetFrontGlobalSettingsListQuery, FrontGlobalSettingsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dBcontext;

        public GetFrontGlobalSettingListQueryHandler(IMapper mapper, IDBContext dBcontext)
        {
            _mapper = mapper;
            _dBcontext = dBcontext;
        }

        public async Task<FrontGlobalSettingsListVm> Handle(GetFrontGlobalSettingsListQuery request, CancellationToken cancellationToken)
        {
            var globalSettings = await _dBcontext.FrontGlobalSettings.ProjectTo<FrontGlobalSettingLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new FrontGlobalSettingsListVm
            {
                GlobalSettings = globalSettings
            };
        }
    }
}
