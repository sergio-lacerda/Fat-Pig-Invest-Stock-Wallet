using Fat_Pig_Invest_Stock_Wallet.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuring and Adding Pomelo to services
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnStr");
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 24));

builder.Services.AddDbContext<FatPigInvestContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)
);



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
