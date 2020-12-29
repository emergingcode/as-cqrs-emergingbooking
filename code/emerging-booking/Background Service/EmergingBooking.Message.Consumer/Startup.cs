using EmergingBooking.Infrastructure.Cqrs;
using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Message.Consumer.BackgroundService;
using EmergingBooking.Message.Consumer.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EmergingBooking.Message.Consumer
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
            services
                .RegisterInfrastructureCqrsDependencies(Configuration)
                .RegisterSqlServerInfrastructureDependencies(Configuration);

            services.AddSingleton<HotelPersistenceSynchronizer, HotelPersistenceSynchronizer>();
            services.AddSingleton<ReservationPersistenceSynchronizer, ReservationPersistenceSynchronizer>();

            services.AddSingleton<IHostedService, HotelConsumer>();
            services.AddSingleton<IHostedService, ReservationConsumer>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(@"
<html>
    <title>Emerging Booking</title>
<body>
    <h3>
        <center>Emerging Booking Kafka Message Streaming Consumer is now RUNNING...!</center>
    </h3>
</body>
</html>");
            });
        }
    }
}