using EmergingBooking.Infrastructure.Cqrs;
using EmergingBooking.Queries.Application;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmergingBookingApi
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new Microsoft.OpenApi.Models.OpenApiInfo
                             {
                                 Title = "EmergingBooking Api",
                                 Version = "v1",
                                 Description = "List of Apis to interact with EmergingBooking"
                             });
            });

            services
                .RegisterInfrastructureCqrsDependencies(Configuration)
                .RegisterQueriesApplicationDependencies(Configuration);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                     {
                         builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                     }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "EmergingBooking Api V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}