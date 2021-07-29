using Catalogo.DB;
using Catalogo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Controllers
{
    public class AuthController : Controller
    {
        private CatalogoContext context;
        private IConfiguration configuration;
        public AuthController(CatalogoContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.Accounts
                .FirstOrDefault(o => o.user == username && o.password == CreateHash(password));

            if (user == null)
            {
                TempData["AuthMessage"] = "Usuario o Contraseña incorrecto";
                return RedirectToAction("Login");
            }

            // Autenticar
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.user),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrincipal);


            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        private string CreateHash(string input)
        {
            input += configuration.GetValue<string>("Key");
            var sha = SHA512.Create();

            var bytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

    }
}
