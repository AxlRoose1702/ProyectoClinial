using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PROYECTOCLINICAL.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Buscar la manera de hacer esta injeccion de dependencias.

            return services;
        }
    }
}
