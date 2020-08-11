using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.ApplicationCore.Interface.Services;
using WebMolisacApi.ApplicationCore.Services;
using WebMolisacApi.Infrastructure.Repositories;

namespace WebMolisacApi
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

            services.AddSingleton(Configuration);

            //Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPromocionRepository, PromocionRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();

            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPromocionService, PromocionService>();
            services.AddScoped<ISliderService, SliderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("The service is available.");
            });
        }
    }
}
