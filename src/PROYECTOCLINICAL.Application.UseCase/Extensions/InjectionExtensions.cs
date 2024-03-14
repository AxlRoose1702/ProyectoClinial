using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PROYECTOCLINICAL.Application.UseCase.Commons.Behaviours;
using System.Reflection;

namespace PROYECTOCLINICAL.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Buscar la manera de hacer esta injeccion de dependencias.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
