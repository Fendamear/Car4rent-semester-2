using Microsoft.AspNetCore.Mvc;
using Sofware_semester_2_Car4Rent.Models;
using Car4Rent.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sofware_semester_2_Car4Rent.Controllers
{
    public class AutoController : Controller
    {
        public IActionResult GetAllcars()
        {
            AutoCollection autoCollection = new AutoCollection();
            List<AutoViewModel> autoviewmodel = new List<AutoViewModel>();

            foreach (Auto auto in autoCollection.GetAutos())
            {
                autoviewmodel.Add(new AutoViewModel
                {
                    type = auto.type,
                    Merk = auto.Merk,
                    Kenteken = auto.Kenteken,
                    bouwjaar = auto.bouwjaar,
                    KM_stand = auto.KM_stand,
                    Brandstof = auto.Brandstof,
                    Zitplaatsen = auto.Zitplaatsen,
                    Versnellingsbak = auto.Versnellingsbak,
                    url = auto.Url,
                    prijs = auto.prijs
                });
            }
            return View(autoviewmodel);
        }

        public IActionResult GetCar(int id)
        {
            AutoCollection autoCollection = new AutoCollection();
            AutoViewModel autoViewModel = new AutoViewModel();
            Auto auto = new Auto();
            auto = autoCollection.GetAuto(id);

            autoViewModel.AutoID = auto.AutoID;
            autoViewModel.type = auto.type;
            autoViewModel.Merk = auto.Merk;
            autoViewModel.Kenteken = auto.Kenteken;
            autoViewModel.bouwjaar = auto.bouwjaar;
            autoViewModel.KM_stand = auto.KM_stand;
            autoViewModel.Brandstof = auto.Brandstof;
            autoViewModel.Zitplaatsen = auto.Zitplaatsen;
            autoViewModel.Versnellingsbak = auto.Versnellingsbak;
            autoViewModel.url = auto.Url;
            autoViewModel.prijs = auto.prijs;

            return View(autoViewModel);

        }



        public IActionResult ListProducts()
        {
            AutoCollection AutoCollection = new AutoCollection();
            List<AutoViewModel> autoViewModels = new List<AutoViewModel>();

            foreach (Auto auto in AutoCollection.GetAutos())
            {
                autoViewModels.Add(new AutoViewModel
                {
                    type = auto.type,
                    Merk = auto.Merk,
                    Kenteken = auto.Kenteken,
                    bouwjaar = auto.bouwjaar,
                    KM_stand = auto.KM_stand,
                    Brandstof = auto.Brandstof,
                    Zitplaatsen = auto.Zitplaatsen,
                    Versnellingsbak = auto.Versnellingsbak,
                    url = auto.Url,
                    prijs = auto.prijs

                });
            }
            return View(autoViewModels);

        }

        public IActionResult AutoToevoegen(AutoViewModel autoViewModel)
        {
            AutoCollection autoCollection = new AutoCollection();

            if (!ModelState.IsValid) return View();

            Auto auto = new Auto();
            auto.type = autoViewModel.type;
            auto.Merk = autoViewModel.Merk;
            auto.Kenteken = autoViewModel.Kenteken;
            auto.bouwjaar = autoViewModel.bouwjaar;
            auto.KM_stand = autoViewModel.KM_stand;
            auto.Brandstof = autoViewModel.Brandstof;
            auto.Zitplaatsen = autoViewModel.Zitplaatsen;
            auto.Versnellingsbak = autoViewModel.Versnellingsbak;
            auto.Url = autoViewModel.url;
            auto.prijs = autoViewModel.prijs;

            autoCollection.Create(auto);

            return RedirectToAction("GetAllcars", "Auto");
        }
    }
}
