﻿using Microsoft.Extensions.DependencyInjection;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Persistence.Context;
using PROYECTOCLINICAL.Persistence.Repositories;

namespace PROYECTOCLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            //services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
