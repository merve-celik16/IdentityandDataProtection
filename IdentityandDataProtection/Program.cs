using IdentityandDataProtection.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ASP.NET Core Identity'yi yap�land�r�r.
// IdentityUser , kullan�c� bilgilerini tutan s�n�f; IdentityRole, rol bilgilerini tutan s�n�ft�r.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    // Entity Framework ile kullan�c� ve rol bilgilerini y�neten veritaban� ba�lam�n� ekler.
    .AddEntityFrameworkStores<PratikIdentityDbContext>()
    // Varsay�lan token sa�lay�c�lar�n� ekler (�ifre s�f�rlama, e-posta do�rulama vb. i�in).
    .AddDefaultTokenProviders();

// Identity se�eneklerini yap�land�r�r.
// Bu ayarlar, kullan�c� kimlik do�rulama ve yetkilendirme i�lemlerinde kullan�lacak kurallar� belirler.
builder.Services.Configure<IdentityOptions>(options =>
{
    // �ifrelerin en az bir rakam i�ermesini zorunlu k�lar.
    options.Password.RequireDigit = true;
    // �ifrelerin en az bir k���k harf i�ermesini zorunlu k�lar.
    options.Password.RequireLowercase = true;
    // �ifrelerin minimum uzunlu�unu 6 karakter olarak ayarlar.
    options.Password.RequiredLength = 6;
    // Kullan�c�lar�n kilitlenme s�resini 5 dakika olarak ayarlar.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // Maksimum ba�ar�s�z giri� denemesi say�s�n� 5 olarak ayarlar.
    options.Lockout.MaxFailedAccessAttempts = 5;
    // Yeni kullan�c�lar i�in kilitlenme �zelli�ini etkinle�tirir.
    options.Lockout.AllowedForNewUsers = true;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
