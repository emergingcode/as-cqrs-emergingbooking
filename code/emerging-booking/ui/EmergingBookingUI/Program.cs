using EmergingBookingUI.ClientServices;

using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string apiWriteBaseAddress = builder.Configuration.GetSection("ApiConfiguration:WriteBaseAddress").Value;
string apiReadBaseAddress = builder.Configuration.GetSection("ApiConfiguration:ReadBaseAddress").Value;

builder.Services.AddHttpClient<HotelWriteService>(httpConfiguration =>
{
    httpConfiguration.BaseAddress = new Uri(apiWriteBaseAddress);
    httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
    httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
});

builder.Services.AddHttpClient<HotelReadService>(httpConfiguration =>
{
    httpConfiguration.BaseAddress = new Uri(apiReadBaseAddress);
    httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
    httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
});

builder.Services.AddHttpClient<BookingWriteService>(httpConfiguration =>
{
    httpConfiguration.BaseAddress = new Uri(apiWriteBaseAddress);
    httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
    httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
});

builder.Services.AddHttpClient<BookingReadService>(httpConfiguration =>
{
    httpConfiguration.BaseAddress = new Uri(apiReadBaseAddress);
    httpConfiguration.DefaultRequestHeaders.Add("Accept", "application/json");
    httpConfiguration.DefaultRequestHeaders.Add("User-Agent", "EmergingBooking");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();

app.Run();
