using Application.Interfaces;
using Application.Models.AuthModels.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthCredentialDto model)
        {
            return Ok(await _authService.Authorize(model));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(AuthRefreshTokenDto model)
        {
            return Ok(await _authService.Refresh(model));
        }

    }
}
