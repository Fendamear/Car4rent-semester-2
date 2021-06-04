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

            if (!ModelState.IsValid) return View();
          
            Boeking boeking = new Boeking();
            boeking.AutoID = AutoID;
            boeking.Begindatum = begindatum;
            boeking.Einddatum = einddatum;
            boeking.TotaalPrijs = Totaalprijs;

            boekingCollection.Create(boeking);

            return RedirectToAction("GetGebruikerBoeking", "Boeking");
        }

        public IActionResult GetGebruikerBoeking()
        {
            Gebruiker gebruiker = new Gebruiker
            {
                GebruikerID = Convert.ToInt32(User.Claims.First(claim => claim.Type == "ID").Value)
            };

            List<BoekingViewModel> boekingViewModel = new List<BoekingViewModel>();

            foreach (Boeking boeking in gebruiker.GetBoekingByGebruiker())
            {
                boekingViewModel.Add(new BoekingViewModel
                {
                    ID = boeking.ID,
                    AutoID = boeking.AutoID,
                    HuurderID = boeking.Huurder,
                    Type = boeking.Type,
                    Merk = boeking.Merk,
                    begindatum = boeking.Begindatum,
                    einddatum = boeking.Einddatum,
                    BoekingDatum = boeking.BoekingDatum,
                    prijs = boeking.TotaalPrijs
                });
            }
            return View(boekingViewModel);
        }

        public IActionResult DeleteBoeking(int id)
        {
            BoekingCollection boekingCollection = new BoekingCollection();
            BoekingViewModel boekingViewModel = new BoekingViewModel();
            Boeking boeking = new Boeking();
            boeking = boekingCollection.GetBoeking(id);

            boekingViewModel.ID = boeking.ID;
            boekingViewModel.AutoID = boeking.AutoID;
            boekingViewModel.HuurderID = boeking.Huurder;
            boekingViewModel.Type = boeking.Type;
            boekingViewModel.Merk = boeking.Merk;
            boekingViewModel.begindatum = boeking.Begindatum;
            boekingViewModel.einddatum = boeking.Einddatum;
            boekingViewModel.BoekingDatum = boeking.BoekingDatum;
            boekingViewModel.prijs = boeking.TotaalPrijs;

            return View(boekingViewModel);
        }

        [HttpPost]
        public IActionResult DeleteBoeking(BoekingViewModel boekingViewModel)
        {
            BoekingCollection boekingCollection = new BoekingCollection();

            if (!ModelState.IsValid) return View();

            Boeking boeking = new Boeking();
            boeking.ID = boekingViewModel.ID;

            boekingCollection.Delete(boeking);

            return RedirectToAction("GetGebruikerBoeking", "Boeking");
        }

        public IActionResult UpdateBoeking(int id)
        {
            BoekingCollection boekingCollection = new BoekingCollection();
            BoekingViewModel boekingViewModel = new BoekingViewModel();
            Boeking boeking = new Boeking();
            boeking = boekingCollection.GetBoeking(id);

            boekingViewModel.ID = boeking.ID;
            boekingViewModel.AutoID = boeking.AutoID;
            boekingViewModel.HuurderID = boeking.Huurder;
            boekingViewModel.Type = boeking.Type;
            boekingViewModel.Merk = boeking.Merk;
            boekingViewModel.begindatum = boeking.Begindatum;
            boekingViewModel.einddatum = boeking.Einddatum;
            boekingViewModel.BoekingDatum = boeking.BoekingDatum;
            boekingViewModel.prijs = boeking.TotaalPrijs;

            return View(boekingViewModel);
        }

        [HttpPost]
        public IActionResult UpdateBoeking(BoekingViewModel bvm)
        {
            if (!ModelState.IsValid) return View();
            Boeking boeking = new Boeking();

            if(boeking.CheckIfUpdateIsPossible(bvm.AutoID, bvm.begindatum, bvm.einddatum))
            {
                AutoCollection autoCollection = new AutoCollection();
                Auto auto = new Auto();
                auto = autoCollection.GetAuto(bvm.AutoID);

                DateTime StartDate = Convert.ToDateTime(bvm.begindatum);
                DateTime EndDate = Convert.ToDateTime(bvm.einddatum);
                int TotaalDagen = (EndDate - StartDate).Days;

                boeking.ID = bvm.ID;
                boeking.AutoID = bvm.AutoID;
                boeking.Huurder = bvm.HuurderID;
                boeking.Merk = bvm.Merk;
                boeking.Type = bvm.Type;
                boeking.Begindatum = bvm.begindatum;
                boeking.Einddatum = bvm.einddatum;
                boeking.BoekingDatum = bvm.BoekingDatum;
                boeking.TotaalPrijs = auto.prijs * TotaalDagen;

                boeking.Update(boeking);
                return RedirectToAction("GetGebruikerBoeking", "Boeking");
            }
            ModelState.AddModelError(string.Empty, "Op deze datum is deze auto niet beschikbaar!");
            




            return View();
        }

    }
}
