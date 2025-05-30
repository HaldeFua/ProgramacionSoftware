namespace Passwords.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using System.Security.Cryptography;
    using System.Text;
    using Passwords.Models;
    public class PasswordGeneratorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new PasswordGenerator();
            return View(model);
        }

        [HttpPost]
        public IActionResult Generate(PasswordGenerator model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var characterPool = new StringBuilder();

            if (model.IncludeLowercase) characterPool.Append("abcdefghijklmnopqrstuvwxyz");
            if (model.IncludeUppercase) characterPool.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            if (model.IncludeNumbers) characterPool.Append("0123456789");
            if (model.IncludeSymbols) characterPool.Append("!@#$%^&*()-_=+[]{}|;:,.<>?");

            if (characterPool.Length == 0)
            {
                ModelState.AddModelError("", "Debes seleccionar al menos un tipo de carácter.");
                return View("Index", model);
            }

            model.GeneratedPassword = GenerateSecurePassword(model.Length, characterPool.ToString());

            return View("Index", model);
        }

        private string GenerateSecurePassword(int length, string characters)
        {
            var password = new StringBuilder();
            var bytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            for (int i = 0; i < length; i++)
            {
                int index = bytes[i] % characters.Length;
                password.Append(characters[index]);
            }

            return password.ToString();
        }
    }

}
