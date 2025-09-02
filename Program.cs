using EMassage.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключение к локальной базе данных SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=DMassage.db"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Включаем процессы аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// Стандартные middleware
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
