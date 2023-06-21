using Microsoft.EntityFrameworkCore;
using UrlShortenerLibrary.Services;
using UrlShortenerLibrary.Configurations;
using UrlShortenerLibrary.Data;
using UrlShortenerLibrary.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connection, action => action.MigrationsAssembly("UrlShortener")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount =  true)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddHostedService<UrlUsageInfoHostedService>();
builder.Services.AddScoped<UrlUsageInfoHandler>();


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
