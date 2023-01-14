using ElectronicLibrary.Infrastructure.Middlewares;
using ElectronicLibrary.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ElectronicLibrary.Infrastructure.Extensions;
using FluentValidation.AspNetCore;
using ElectronicLibrary.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Application.Profiles;
using AutoMapper;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicBookingSystem.Persistance.Seeder;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Application.Hubs;

namespace ElectronicLibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElectronicLibrary.Api", Version = "v1" });
            });

            services.ConfigureSecurity(Configuration);
            services.AddCustomCors(Configuration);
            services.AddHttpContextAccessor();
            services.AddSingleton<ExceptionHandlingMiddleware>();
            

            services.AddDbContext<ElectronicBookingSystemDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Library"), 
                    x=>x.MigrationsAssembly("ElectronicBookingSystem.Persistance"));
            });
            //because it injects context
            services.AddScoped<RoleSeeder>();
            services.AddScoped<UserSeeder>();
            services.AddScoped<ServiceSeeder>();
            services.AddScoped<CategorySeeder>();

            services.AddInfrastructureServices();
            services.AddConfigurationModels(Configuration);
            services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();

            services.AddMediatR(typeof(RegisterUserCommand).Assembly); //assembly where handlers are

            services.AddAutoMapper(typeof(UserAutomapperProfile).Assembly);
            /*services.AddSingleton(provider => new MapperConfiguration(cfg => //mapper for dependencyInjection
            {
                cfg.AddProfile(new RoomAutomapperProfile(provider.GetRequiredService<FileConfiguration>()));
                cfg.AddMaps(typeof(UserAutomapperProfile).Assembly);
            }));*/
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUserValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleSeeder seeder, UserSeeder userSeeder,
            CategorySeeder categorySeeder, ServiceSeeder serviceSeeder)
        {
            seeder.Seed();
            //Task.Run(async () => await seeder.Seed());
            Task.Run(async () => await userSeeder.Seed());
            Task.Run(async () => await categorySeeder.Seed());
            Task.Run(async () => await serviceSeeder.Seed());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ElectronicLibrary.Api v1"));
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            

            app.UseRouting();
            app.UseCors("AllowedHosts");


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notification");
            });
        }
    }
}
