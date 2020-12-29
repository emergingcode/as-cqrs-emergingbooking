using EmergingBooking.Infrastructure.Cqrs;
using EmergingBooking.Management.Application;
using EmergingBooking.Queries.Application;
using EmergingBooking.Reservation.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new Info
                             {
                                 Title = "EmergingBooking Api",
                                 Version = "v1",
                                 Description = "List of Apis to interact with EmergingBooking"
                             });
            });

            services
                .RegisterInfrastructureCqrsDependencies(Configuration)
                .RegisterManagementApplicationDependencies(Configuration)
                .RegisterQueriesApplicationDependencies(Configuration)
                .RegisterReservationApplicationDependencies(Configuration);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                     {
                         builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                     }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "EmergingBooking Api V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}