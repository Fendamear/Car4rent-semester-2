using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sofware_semester_2_Car4Rent.Models;
using Car4Rent.Logic;

namespace Sofware_semester_2_Car4Rent.Controllers
{
    public class BoekingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int AutoID, string begindatum, string einddatum, decimal Totaalprijs)
        {
            BoekingCollection boekingCollection = new BoekingCollection();

            Boeking boeking = new Boeking();

            boeking.AutoID = AutoID;
            boeking.Begindatum = begindatum;
            boeking.Einddatum = einddatum;
            boeking.TotaalPrijs = Totaalprijs;

            boekingCollection.Create(boeking);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetGebruikerBoeking()
        {
            Gebruiker gebruiker = new Gebruiker
            {
                GebruikerID = Convert.ToInt32(User.Claims.First(claim => claim.Type == "ID").Value)
            };

            List<BoekingViewModel> boekingViewModel = new List<BoekingViewModel>();

            foreach (Auto auto in gebruiker.GetAutosByGebruiker())
            {
                boekingViewModel.Add(new BoekingViewModel
                {
                    
                });
            }
            return View(boekingViewModel);
        }

    }
}
