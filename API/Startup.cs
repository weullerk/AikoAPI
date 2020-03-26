using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mapper;
using Application.Services;
using AutoMapper;
using DDD.Interfaces;
using DDD.Services;
using FluentValidation;
using Infra.Mapper;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Teste_Aiko.Mapper;
using Teste_Aiko.Requests.PointOfInterest;
using Teste_Aiko.Validations;

namespace API
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
            var connectionString = Configuration["dbConnectionString:localdb"];
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var mappingConfig = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    typeof(PointOfInterestInfraMapping),
                    typeof(PointOfInterestApplicationMapping),
                    typeof(PointOfInterestApiMapping)
                })
            );

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();
            services.AddScoped<IPointOfInterestService, PointOfInterestService>();
            services.AddScoped<IPointOfInterestApplicationService, PointOfInterestApplicationService>();

            services.AddTransient<IValidator<CreatePointOfInterestRequest>, CreatePointOfInterestValidator>();
            services.AddTransient<IValidator<UpdatePointOfInterestRequest>, UpdatePointOfInterestValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Aiko API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Aiko API V1");
            });
        }
    }
}
