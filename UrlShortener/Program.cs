using Microsoft.EntityFrameworkCore;
using UrlShortener.Configurations;
using UrlShortener.Data;
using UrlShortener.Data.Models;
using UrlShortener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount =  true)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<UrlUsageInfoHandler>();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddHostedService<UrlUsageInfoHostedService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePagesWithReExecute("/status/{0}");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
