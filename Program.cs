using EMassage.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
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

builder.Services.AddControllersWithViews();

// ����������� � ��������� ���� ������ SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=DMassage.db"));

var app = builder.Build();

// �������� �������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ����������� middleware
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
