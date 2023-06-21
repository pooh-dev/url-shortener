using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrlShortenerLibrary.Data.Models;

namespace UrlShortenerLibrary.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UrlData> UrlDatas { get; set; }
    public DbSet<UrlUsageData> UrlUsageDatas { get; set; }
}
