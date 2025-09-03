using EMassage.Data;
using EMassage.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем службы аутентификации
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";          // Страничка входа
        opt.LogoutPath = "/Account/Logout";        // Страничка выхода
        opt.AccessDeniedPath = "/Account/AccessDenied"; // Страничка отказа в доступе
    });


// Регистрируем контекст базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация Identity
builder.Services.AddIdentity<User, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Включаем процессы аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// Стандартные middleware
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
