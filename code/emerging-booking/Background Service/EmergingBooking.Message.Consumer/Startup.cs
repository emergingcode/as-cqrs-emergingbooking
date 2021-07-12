using EmergingBooking.Infrastructure.Cqrs;
using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Message.Consumer.BackgroundServices;
using EmergingBooking.Message.Consumer.Repository;
using EmergingBooking.Message.Consumer.Settings;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddOptions<HotelConsumerSettings>()
                    .Bind(Configuration.GetSection(nameof(HotelConsumerSettings)));

            services.AddOptions<ReservationConsumerSettings>()
                    .Bind(Configuration.GetSection(nameof(ReservationConsumerSettings)));

            services
                .RegisterInfrastructureCqrsDependencies(Configuration)
                .RegisterSqlServerInfrastructureDependencies(Configuration);

            services.AddSingleton<HotelPersistenceSynchronizer, HotelPersistenceSynchronizer>();
            services.AddSingleton<ReservationPersistenceSynchronizer, ReservationPersistenceSynchronizer>();

            services.AddSingleton<IHostedService, HotelConsumer>();
            services.AddSingleton<IHostedService, ReservationConsumer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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