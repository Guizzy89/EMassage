using EMassage.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ����������� � ��������� ���� ������ SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=DMassage.db"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// �������� �������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ����������� middleware
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
