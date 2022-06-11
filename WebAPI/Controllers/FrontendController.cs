using Application.Commands.FrontCategory.ChangeActiveStateCommand;
using Application.Commands.FrontCategory.CreateCommand;
using Application.Commands.FrontCategory.UpdateCommand;
using Application.Commands.FrontGlobalSettings.UpdateCommand;
using Application.Interfaces;
using Application.Models;
using Application.Models.FrontModels.DTOs;
using Application.Queries.FrontGlobalSettings.GetFrontGlobalSettingsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontendController : BaseController
    {
        private readonly IFrontendService _frontendService;
        public FrontendController(IFrontendService frontendService)
        {
            _frontendService = frontendService;
        }

        [HttpPost("create-page")]
        public async Task<IActionResult> CreatePage(CreateFrontPageDto model)
        {
            return Ok(await _frontendService.CreatePage(model));
        }

        [HttpPost("create-base-component")]
        public async Task<IActionResult> CreateBaseComponent(CreateFrontBaseComponentDto model)
        {
            return Ok(await _frontendService.CreateBaseComponent(model));
        }

        [HttpPost("add-prop-to-component")]
        public async Task<IActionResult> AddPropToBaseComponent(CreateFrontComponentPropDto model)
        {
            return Ok(await _frontendService.AddPropToComponent(model));
        }

        [HttpPost("create-component")]
        public async Task<IActionResult> CreateComponent(CreateFrontComponentDto model)
        {
            return Ok(await _frontendService.CreateComponent(model));
        }

        [HttpPost("update-prop-value")]
        public IActionResult UpdatePropValue(UpdateFrontPropValueDto model)
        {
            _frontendService.UpdateValueToProp(model);
            return Ok();
        }

        [HttpPost("get-pages")]
        public async Task<IActionResult> GetPages()
        {
            return Ok((await _frontendService.GetFrontPages()).Pages);
        }

        [HttpPost("get-base-components")]
        public async Task<IActionResult> GetBaseComponents()
        {
            return Ok(await _frontendService.GetBaseComponents());
        }

        [HttpPost("get-components-type-with-props")]
        public async Task<IActionResult> GetComponentsTypeWithProps(GetFrontComponentListDto model)
        {
            return Ok(await _frontendService.GetComponentsTypeWithProps(model));
        }

        [HttpPost("get-components")]
        public async Task<IActionResult> GetComponents(GetFrontComponentListDto model)
        {
            return Ok(await _frontendService.GetComponentsTypeWithProps(model));
        }

        [HttpPost("get-base-component-props")]
        public async Task<IActionResult> GetBaseComponentProps(GetFrontComponentPropsDto model)
        {
            return Ok(await _frontendService.GetFrontComponentPropList(model));
        }

        [HttpPost("get-component-prop-values")]
        public async Task<IActionResult> GetComponentPropValues(GetFrontPropValuesDto model)
        {
            return Ok(await _frontendService.GetComponentPropValues(model));
        }

        [HttpPost("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _frontendService.GetFrontCategories());
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateFrontCategoryCommand command)
        {
            return Ok(await _frontendService.CreateCategory(command));
        }

        [HttpPost("update-category")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateFrontCategoryCommand command)
        {
            await _frontendService.UpdateCategory(command);
            return Ok();
        }

        [HttpPost("update-global-setting")]
        public async Task<IActionResult> UpdateGlobalSetting(UpdateGlobalSettingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("get-global-settings")]
        public async Task<IActionResult> GetGlobalSettings()
        {
            return Ok(await Mediator.Send(new GetFrontGlobalSettingsListQuery()));
        }

        [HttpPost("change-active-state-category")]
        public async Task<IActionResult> ChangeActiveStateCategoryAsync(ChangeActiveStateFrontCategoryCommand command)
        {
            await _frontendService.ChangeActiveSateCategory(command);
            return Ok();
        }
    }
}
