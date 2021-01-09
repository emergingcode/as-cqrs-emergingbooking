using System;

using EmergingBookingUI.ClientServices;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Westwind.AspNetCore.LiveReload;

namespace EmergingBookingUI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddLiveReload();

            services.AddRazorPages();

            string apiBaseAddress = Configuration.GetSection("ApiConfiguration:BaseAddress").Value;

            services.AddHttpClient<HotelService>(httpConfiguration =>
            {
                httpConfiguration.BaseAddress = new Uri(apiBaseAddress);
                httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
                httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
            });

            services.AddHttpClient<BookingService>(httpConfiguration =>
            {
                httpConfiguration.BaseAddress = new Uri(apiBaseAddress);
                httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
                httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseLiveReload();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}