 # 📘 Kullanıcı Yönetimi ve Veri Koruma (Identity and Data Protection)
Bu proje, Entity Framework Code First yaklaşımını kullanarak kullanıcı yönetimi ve veri koruma özelliklerini uygulayan bir API geliştirmeyi amaçlamaktadır. Kullanıcılar, e-posta ve şifre bilgileriyle kayıt olabilir ve şifreleri güvenli bir şekilde korunur.

 ## 🛠️ Proje Gereksinimleri

 1 - User Tablosu:

  * Email (string, benzersiz, gerekli)
  * Password (string, gerekli, şifrelenmiş)
    
 2 - Entity Framework Code First:

  * Kullanıcı verilerinin tutulacağı veritabanını oluşturmak için kullanılır.

 3 - Model Doğrulama:

  * [Required] gibi veri anotasyonları ile alan doğrulamalarını uygulayın.

 4 - Şifreleme:

  * Kullanıcı şifreleri, Data Protection mekanizması ile şifrelenir ve güvenli bir şekilde saklanır.

 5 - Identity Kullanımı:

  * Kimlik doğrulama işlemleri için Identity API veya özel bir kimlik doğrulama mekanizması kullanılır.

 ## 🚀 Nasıl Çalışır?

 ### 📂 Katmanlar

  * ViewModels: Kullanıcı modeli ve doğrulama kuralları.

  * Data: Veritabanı bağlantısı ve yapılandırması.

  * Controllers: API uç noktalarının tanımlandığı yer.

## 🚀 Kurulum ve Çalıştırma
 
1. Gerekli NuGet Paketlerini Yükleme
Proje dizininde aşağıdaki komutları çalıştırarak gerekli paketleri yükleyin:

````
Install-Package Microsoft.AspNetCore.Identitiy.EntityFrameworkCore 8.0.11
Install-Package Microsoft.EntityFrameworkCore.Tools 8.0.11
Install-Package Npgsql.EntityFrameworkCore.SqlServer 8.0.11 
````

2. Veritabanı Oluşturma
EF Core ile Code First yaklaşımında veritabanını oluşturmak için şu adımları takip edin:

 - Migration Oluşturma
``
dotnet ef migrations add InitialCreate
``
 - Veritabanını Güncelleme
``
dotnet ef database update
``    



