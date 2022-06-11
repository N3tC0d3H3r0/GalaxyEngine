using Application.Commands.FrontBaseComponent.CreateCommand;
using Application.Commands.FrontCategory.ChangeActiveStateCommand;
using Application.Commands.FrontCategory.CreateCommand;
using Application.Commands.FrontCategory.UpdateCommand;
using Application.Commands.FrontComponent.CreateCommand;
using Application.Commands.FrontComponentProp.CreateCommand;
using Application.Commands.FrontPage.CreateCommand;
using Application.Commands.FrontPropValue.CreateCommand;
using Application.Commands.FrontPropValue.UpdateCommand;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.FrontModels.DTOs;
using Application.Models.FrontModels.VMs;
using Application.Queries.FrontBaseComponent.GetFrontBaseComponents;
using Application.Queries.FrontCategory.GetFrontCategories;
using Application.Queries.FrontComponent.GetFrontComponents;
using Application.Queries.FrontComponentProp;
using Application.Queries.FrontPage.GetFrontPages;
using Application.Queries.FrontPropValue.GetFrontPropValueByComponent;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FrontendService : IFrontendService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FrontendService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Guid> AddPropToComponent(CreateFrontComponentPropDto model)
        {
            var command = _mapper.Map<CreateFrontComponentPropCommand>(model);

            return await _mediator.Send(command);
        }

        public async Task<Guid> AddValueToProp(CreateFrontPropValueDto model)
        {
            var command = _mapper.Map<CreateFrontPropValueCommand>(model);

            return await _mediator.Send(command);
        }

        public async Task<Unit> ChangeActiveSateCategory(ChangeActiveStateFrontCategoryCommand command)
        {
            await _mediator.Send(command);

            return Unit.Value;
        }

        public async Task<Guid> CreateBaseComponent(CreateFrontBaseComponentDto model)
        {
            var command = _mapper.Map<CreateFrontBaseComponentCommand>(model);

            return await _mediator.Send(command);
        }

        public async Task<Guid> CreateCategory(CreateFrontCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<Guid> CreateComponent(CreateFrontComponentDto model)
        {
            var command = _mapper.Map<CreateFrontComponentCommand>(model);

            var entityId = await _mediator.Send(command);

            var props = await GetFrontComponentPropList(new GetFrontComponentPropsDto
            {
                BaseComponentId = model.BaseComponentId,
            });

            foreach (var prop in props.Props)
            {
                await AddValueToProp(new CreateFrontPropValueDto()
                {
                    ComponentId = entityId.ToString(),
                    PropId = prop.Id.ToString(),
                    Value = string.Empty
                });
            }

            return entityId;
        }

        public async Task<Guid> CreatePage(CreateFrontPageDto model)
        {
            var command = _mapper.Map<CreateFrontPageCommand>(model);

            return await _mediator.Send(command);
        }

        public async Task<FrontBaseComponentListVm> GetBaseComponents()
        {
            return await _mediator.Send(new GetFrontBaseComponentListQuery());
        }

        public async Task<GetFrontPropValueListVm> GetComponentPropValues(GetFrontPropValuesDto model)
        {
            var command = _mapper.Map<GetFrontPropValuesByComponentQuery>(model);

            return await _mediator.Send(command);
        }

        public async Task<GetFrontComponentListVm> GetComponents(Models.FrontModels.DTOs.GetFrontComponentListDto model)
        {
            var command = _mapper.Map<GetFrontComponentListQuery>(model);

            return await _mediator.Send(command);
        }

        public async Task<List<FrontComponentTypeWithProps>> GetComponentsTypeWithProps(Models.FrontModels.DTOs.GetFrontComponentListDto model)
        {
            var result = new List<FrontComponentTypeWithProps>();

            var components = await GetComponents(model);

            components.Components.OrderBy(x=>x.DisplayIndex);

            foreach (var item in components.Components)
            {
                var props = (await GetComponentPropValues(new GetFrontPropValuesDto()
                {
                    ComponentId = item.Id,
                })).PropValues;

                if (props.Where(x => string.IsNullOrEmpty(x.Value) == false && x.IsHidden == false).Count() == props.Where(x=>x.IsHidden == false).Count())
                {
                    result.Add(new FrontComponentTypeWithProps()
                    {
                        ComponentType = item.Name,
                        Props = props
                    });
                }
            }

            return result;
        }

        public async Task<FrontCategoryListVm> GetFrontCategories()
        {
            return await _mediator.Send(new GetFrontCategoryListQuery());
        }

        public async Task<GetFrontComponentPropListVm> GetFrontComponentPropList(GetFrontComponentPropsDto model)
        {
            var query = _mapper.Map<GetFrontComponentPropListQuery>(model);

            return await _mediator.Send(query);
        }

        public async Task<GetFrontPageListVm> GetFrontPages()
        {
            return await _mediator.Send(new GetFrontPageListQuery());
        }

        public async Task<Unit> UpdateCategory(UpdateFrontCategoryCommand command)
        {
            await _mediator.Send(command);
            return Unit.Value;
        }

        public async Task<Unit> UpdateValueToProp(UpdateFrontPropValueDto model)
        {
            var command = _mapper.Map<UpdateFrontPropValueCommand>(model);

            await _mediator.Send(command);

            return Unit.Value;
        }
    }
}
