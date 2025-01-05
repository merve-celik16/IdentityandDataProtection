using IdentityandDataProtection.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityandDataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        // UserManager, kullanıcı işlemlerini yönetmek için kullanılır.
        private readonly UserManager<IdentityUser> _userManager;
        // SignInManager, kullanıcı oturum açma işlemlerini yönetmek için kullanılır.
        private readonly SignInManager<IdentityUser> _signInManager;
        // RoleManager, kullanıcı rolleri ile ilgili işlemleri yönetmek için kullanılır.
        private readonly RoleManager<IdentityRole> _roleManager;


        // Constructor, bağımlılıkları alır ve sınıfın alanlarına atar.
        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // Kullanıcı kaydı için HTTP POST isteği
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Model doğrulama kontrolü
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                // Kullanıcıyı oluştur
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) // eğer işlem başarılıysa
                {
                    //Kullanıcıyı oturum açtır
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new { message = "Kayıt Başarılı." });
                }
                // Hata durumunda hata mesajlarını döndür
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }
            // Model geçersizse hata mesajlarını döndür
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) // model doğrulama kontrolü
            {
                // kullanıcıyı oturum açtır
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);


                //eğer oturum açma başarılıysa

                if (result.Succeeded)
                {
                    return Ok(new { message = "Giriş başarılı." });
                }
                else
                {
                    return Unauthorized(new { message = "Kullanıcı adı veya şifre hatalı." });
                }
            }
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        // tüm kullanıcıları listelemek için HTTP Get isteği
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            // Kullanıcıları al ve seçilen alanları döndür
            var users = await _userManager.Users.Select(k => new
            {
                k.Id,
                k.UserName,
                k.Email,
               
            })
                .ToListAsync(); // Listeye dönüştür

            return Ok(users); // kullanıcı listesini döndür
        }
    }
}
