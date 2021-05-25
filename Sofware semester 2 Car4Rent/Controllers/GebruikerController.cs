using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sofware_semester_2_Car4Rent.Models.Gebruiker;
using Car4Rent.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Sofware_semester_2_Car4Rent.Controllers
{
    [Authorize]
    public class GebruikerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                GebruikerCollection Gebruikercollection = new GebruikerCollection();

                var Gebruiker = Gebruikercollection.GetGebruikerByEmail(loginViewModel.Email);

                if(Gebruiker.Wachtwoord == loginViewModel.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Gebruiker.Naam),
                        new Claim("ID", Convert.ToString(Gebruiker.GebruikerID))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = false };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View();
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateGebruikerViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            GebruikerCollection gebruikerCollection = new GebruikerCollection();

            if(gebruikerCollection.GetGebruikerByEmail(registerViewModel.Email).Email != null)
            {
                ModelState.AddModelError("", "Deze email is al in gebruik!");
                return View(registerViewModel);
            }

            Gebruiker gebruiker = new Gebruiker();
            gebruiker.Naam = registerViewModel.Naam;
            gebruiker.Email = registerViewModel.Email;
            gebruiker.Wachtwoord = registerViewModel.Wachtwoord;
            gebruiker.GebruikersNaam = registerViewModel.GebruikersNaam;
            gebruiker.BetaalGegevens = registerViewModel.BetaalGegevens;
            gebruiker.Telnummer = registerViewModel.Telnummer;
            gebruiker.Adres = registerViewModel.Adres;
            gebruiker.regio = registerViewModel.regio;

            gebruikerCollection.CreateGebruiker(gebruiker);

            return RedirectToAction("Login", "Gebruiker");    
        }
    }
}
