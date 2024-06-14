using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using pks5_core;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication("Cookies");
builder.Services.AddDbContext<Pks5Context>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=pks5;Username=postgres;Password=9526", x => x.UseNodaTime()));


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");

	app.UseHsts();
}


app.UseStaticFiles();
app.UseRouting();
app.UseSession();


app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "messages",
	pattern: "{controller=Authorized}/{action=messages}/{id?}");


app.Run();