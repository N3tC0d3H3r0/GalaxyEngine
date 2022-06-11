using Application.Demo.Commands.CreateCommand;
using Application.Demo.Queries.GetDemos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : BaseController
    {
        private readonly IMapper _mapper;

        public DemoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDemoAsync(CreateDemoDto model) 
        {
            var command = _mapper.Map<CreateDemoCommand>(model);

            command.UserId = Guid.NewGuid();

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDemosAsync()
        {
            var query = new GetDemoListQuery()
            {
                UserID = Guid.NewGuid()
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
