//using AcademiaGerenciamentoLibary;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;

//namespace AcademiaGerenciamentoWeb
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Registro dos serviços do projeto
//            builder.Services.AddDependencyInjection(); // ?? ESSA LINHA É ESSENCIAL
//            // Add services to the container.
//            builder.Services.AddRazorPages();

//            builder.Services.AddControllers();

//            builder.Services.AddDbContext<DbContextApplication>(options =>
//            options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoAcademia")));



//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapRazorPages();




//            app.MapControllers(); // ? ESSENCIAL para habilitar API controllers


//            app.Run();
//        }

//    }
//}

////http://localhost:5242/
///

using AcademiaGerenciamentoLibary;
using AcademiaGerenciamentoLibary.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AcademiaGerenciamentoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

           
            // Adiciona páginas Razor (caso use na UI)
            builder.Services.AddRazorPages();

            // Registro dos serviços do projeto
            builder.Services.AddDependencyInjection();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Adiciona controllers (necessário para API)
            builder.Services.AddControllers();

            

           

            var app = builder.Build();

            // Middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthorization();

            // Mapeia páginas Razor (caso use interface)
            app.MapRazorPages();

            // Mapeia controllers da API
            app.MapControllers(); // ? ESSENCIAL para habilitar API controllers

            app.Run();
        }
    }
}



