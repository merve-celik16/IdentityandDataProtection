using IdentityandDataProtection.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ASP.NET Core Identity'yi yapýlandýrýr.
// IdentityUser , kullanýcý bilgilerini tutan sýnýf; IdentityRole, rol bilgilerini tutan sýnýftýr.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    // Entity Framework ile kullanýcý ve rol bilgilerini yöneten veritabaný baðlamýný ekler.
    .AddEntityFrameworkStores<PratikIdentityDbContext>()
    // Varsayýlan token saðlayýcýlarýný ekler (þifre sýfýrlama, e-posta doðrulama vb. için).
    .AddDefaultTokenProviders();

// Identity seçeneklerini yapýlandýrýr.
// Bu ayarlar, kullanýcý kimlik doðrulama ve yetkilendirme iþlemlerinde kullanýlacak kurallarý belirler.
builder.Services.Configure<IdentityOptions>(options =>
{
    // Þifrelerin en az bir rakam içermesini zorunlu kýlar.
    options.Password.RequireDigit = true;
    // Þifrelerin en az bir küçük harf içermesini zorunlu kýlar.
    options.Password.RequireLowercase = true;
    // Þifrelerin minimum uzunluðunu 6 karakter olarak ayarlar.
    options.Password.RequiredLength = 6;
    // Kullanýcýlarýn kilitlenme süresini 5 dakika olarak ayarlar.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // Maksimum baþarýsýz giriþ denemesi sayýsýný 5 olarak ayarlar.
    options.Lockout.MaxFailedAccessAttempts = 5;
    // Yeni kullanýcýlar için kilitlenme özelliðini etkinleþtirir.
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
