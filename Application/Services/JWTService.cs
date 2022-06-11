using Application.Commands.RefreshToken.CreateRefreshTokenCommand;
using Application.Commands.RefreshToken.UpdateRefreshTokenCommand;
using Application.Interfaces;
using Application.Queries.RefreshToken.GetRefreshToken;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public JWTService(IConfiguration configuration, UserManager<User> userManager, IMediator mediator, IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<string> CreateRefreshToken(User user)
        {
            var _refreshToken = await _mediator.Send(new GetRefreshTokenQuery
            {
                Id = user.Id
            });

            if (_refreshToken == null)
            {

                var command = new CreateRefreshTokenCommand
                {
                    Id = user.Id,
                    Token = Guid.NewGuid(),
                    ToLife = DateTime.Now.AddMinutes(_configuration.GetSection("JWT").GetValue<int>("REFRESH_LIFETIME"))
                };

                _refreshToken = await _mediator.Send(command);
            }
            else
            {
                var command = new UpdateRefreshTokenCommand
                {
                    Id = user.Id,
                    Token = Guid.NewGuid(),
                    ToLife = DateTime.Now.AddMinutes(_configuration.GetSection("JWT").GetValue<int>("REFRESH_LIFETIME"))
                };

                _refreshToken  = await _mediator.Send(command);
            }

            return _refreshToken.Token.ToString();
        }

        public string CreateToken(User user)
        {
            var identity = GetIdentity(user);

            var now = DateTime.UtcNow;

            var KEY = _configuration.GetSection("JWT").GetValue<string>("KEY");

            var SSK = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            var jwt = new JwtSecurityToken(
                    issuer: _configuration.GetSection("JWT").GetValue<string>("ISSUER"),
                    audience: _configuration.GetSection("JWT").GetValue<string>("AUDIENCE"),
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.AddMinutes(_configuration.GetSection("JWT").GetValue<int>("LIFETIME")),
                    signingCredentials: new SigningCredentials(SSK, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                };
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            foreach (var el in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, el));
            }
            claims.Add(new Claim("email", user.Email));
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
