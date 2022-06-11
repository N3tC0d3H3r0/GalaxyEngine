using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Models.AccountModels.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> CreateAccount(RegistrationDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email); 

            if (user != null)
            {
                throw new CustomHttpException($"Email {model.Email} already used");
            }

            user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new CustomHttpException(result.Errors.FirstOrDefault().Description);
            }

            result = await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
            {
                throw new CustomHttpException(result.Errors.FirstOrDefault().Description);
            }

            return Unit.Value;
        }
    }
}
