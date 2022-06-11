using Application.Commands.FrontCategory.ChangeActiveStateCommand;
using Application.Commands.FrontCategory.CreateCommand;
using Application.Commands.FrontCategory.UpdateCommand;
using Application.Models;
using Application.Models.FrontModels.DTOs;
using Application.Models.FrontModels.VMs;
using Application.Queries.FrontBaseComponent.GetFrontBaseComponents;
using Application.Queries.FrontCategory.GetFrontCategories;
using Application.Queries.FrontComponent.GetFrontComponents;
using Application.Queries.FrontComponentProp;
using Application.Queries.FrontPage.GetFrontPages;
using Application.Queries.FrontPropValue.GetFrontPropValueByComponent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFrontendService
    {
        // queries
        public Task<GetFrontComponentPropListVm> GetFrontComponentPropList(GetFrontComponentPropsDto model);
        public Task<GetFrontPageListVm> GetFrontPages();
        public Task<FrontBaseComponentListVm> GetBaseComponents();
        public Task<GetFrontComponentListVm> GetComponents(Models.FrontModels.DTOs.GetFrontComponentListDto model);
        public Task<List<FrontComponentTypeWithProps>> GetComponentsTypeWithProps(Models.FrontModels.DTOs.GetFrontComponentListDto model);
        public Task<GetFrontPropValueListVm> GetComponentPropValues(GetFrontPropValuesDto model);
        public Task<FrontCategoryListVm> GetFrontCategories();

        //commands
        public Task<Guid> CreatePage(CreateFrontPageDto model);

        public Task<Guid> CreateBaseComponent(CreateFrontBaseComponentDto model);

        public Task<Guid> AddPropToComponent(CreateFrontComponentPropDto model);

        public Task<Guid> CreateComponent(CreateFrontComponentDto model);

        public Task<Guid> AddValueToProp(CreateFrontPropValueDto model);
        public Task<Unit> UpdateValueToProp(UpdateFrontPropValueDto model);

        public Task<Guid> CreateCategory(CreateFrontCategoryCommand command);
        public Task<Unit> UpdateCategory(UpdateFrontCategoryCommand command);
        public Task<Unit> ChangeActiveSateCategory(ChangeActiveStateFrontCategoryCommand command);
    }
}
