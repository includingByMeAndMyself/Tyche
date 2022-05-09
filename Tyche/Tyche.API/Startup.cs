using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using Tyche.BusinessLogic.Services;
using Tyche.DataAccess.MsSql.Context;
using Tyche.DataAccess.MsSql.Repository;
using Tyche.Domain.Interfaces;


namespace Tyche.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IDeckService, DeckService>();
            services.AddScoped<IDeckRepository, DeckRepository>();

            services.AddDbContext<DeckContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("DeckContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tyche.API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Tyche.API.xml");
                c.IncludeXmlComments(filePath);
            });    
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tyche.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
