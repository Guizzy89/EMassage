using EMassage.Data;
using EMassage.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ ��������������
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";          // ��������� �����
        opt.LogoutPath = "/Account/Logout";        // ��������� ������
        opt.AccessDeniedPath = "/Account/AccessDenied"; // ��������� ������ � �������
    });


// ������������ �������� ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� Identity
builder.Services.AddIdentity<User, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// �������� �������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ����������� middleware
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
