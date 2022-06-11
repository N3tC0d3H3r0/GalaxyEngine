using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models.AuthModels.DTOs;
using Application.Models.AuthModels.VMs;
using Application.Queries.RefreshToken.GetRefreshTokenByToken;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTService _jWTService;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AuthService(UserManager<User> userManager, IJWTService jWTService, IConfiguration configuration, IMediator mediator)
        {
            _userManager = userManager;
            _jWTService = jWTService;
            _configuration = configuration;
            _mediator = mediator;
        }

        public async Task<AuthSuccessVm> Authorize(AuthCredentialDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new CustomHttpException("Email or password is invalid", HttpStatusCode.NotFound);
            }

            var isLoggined = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isLoggined)
            {
                throw new CustomHttpException("Email or password is invalid", HttpStatusCode.NotFound);
            }

            var access_token = _jWTService.CreateToken(user);
            var refresh_token = await _jWTService.CreateRefreshToken(user);


            return new AuthSuccessVm()
            {
                access_token = access_token,
                refresh_token = refresh_token,
            };
        }

        public async Task<AuthSuccessVm> Refresh(AuthRefreshTokenDto model)
        {
            var token = await _mediator.Send(new GetRefreshTokenByTokenQuery
            {
                Token = Guid.Parse(model.RefreshToken)
            });

            var refresh_time = _configuration.GetSection("JWT").GetValue<int>("REFRESH_LIFETIME");

            if (token == null)
            {
                throw new CustomHttpException("Refresh token not found", HttpStatusCode.NotFound);
            }

            if (token.ToLife.AddMinutes(refresh_time) <= DateTime.Now)
            {
                throw new CustomHttpException("Refresh token expired", HttpStatusCode.BadRequest);
            }

            var handler = new JwtSecurityTokenHandler();
            var decrypt_token = handler.ReadJwtToken(model.Token);

            if (decrypt_token.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value != token.Id.ToString())
            {
                throw new CustomHttpException("Something went wrong!", HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(token.Id.ToString());

            return new AuthSuccessVm()
            {
                access_token = _jWTService.CreateToken(user),
                refresh_token = await _jWTService.CreateRefreshToken(user),
            };
        }
    }
}
