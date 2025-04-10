using AcademiaGerenciamentoLibary.Repository;
using AcademiaGerenciamentoLibary.Repository.Interfaces;
using AcademiaGerenciamentoLibary.Services;
using AcademiaGerenciamentoLibary.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //AddScoped, AddTransient

            //services
            services.AddScoped<IAlunoServices, AlunoServices>();
            services.AddScoped<IPagamentoServices, PagamentoServices>();
            //IUnitOfWork, UnitOfWork
            //services.AddScoped<IUnitOfWork, UnityOfWork>();

            //repository
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            return services;
        }
    }
}
