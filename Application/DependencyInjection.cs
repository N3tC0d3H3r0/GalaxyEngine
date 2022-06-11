using Application.Common.Behaviors;
using Application.Interfaces;
using Application.Models.AccountModels.DTOs;
using Application.Models.AccountModels.Validators;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));


            services.AddTransient<IValidator<RegistrationDto>, RegistrationDtoValidator>();

            services.AddScoped<IFrontendService, FrontendService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
