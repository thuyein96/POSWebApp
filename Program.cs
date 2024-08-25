using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POSWebApp.DTO;
using POSWebApp.Repositories.Domain;
using POSWebApp.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.AddDbContext<POSWebAppDbContext>(o => o.UseSqlServer(config.GetConnectionString("POSWebAppConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICashierRepository, CashierRepository>();
builder.Services.AddRazorPages();//for Identity pages
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<POSWebAppDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
