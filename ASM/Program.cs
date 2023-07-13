using asm.Services;
using ASM.Helpers;
using ASM.Models;
using ASM.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); });

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("myDB")));

builder.Services.AddTransient<IMahoaHelpers, Mahoahelpers>();

builder.Services.AddTransient<IMonAnSvc, MonAnSvc>();

builder.Services.AddTransient<INguoiDungSvc, NguoidungSvc>();

builder.Services.AddTransient<IUploadHelpers,  UploadHelpers>();

builder.Services.AddTransient<IDonhangSvc, DonhangSvc>();

builder.Services.AddTransient<IDonhangChitietSvc, DonhangChitietSvc>();

builder.Services.AddTransient<INguoiDungSvc, NguoidungSvc>();

builder.Services.AddTransient<IKhachhangSvc, KhachhangSvc>();

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

app.UseSession();

app.UseRouting();
app.UseAuthentication();;


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
