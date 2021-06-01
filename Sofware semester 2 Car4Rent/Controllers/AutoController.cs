using Microsoft.AspNetCore.Mvc;
using Sofware_semester_2_Car4Rent.Models;
using Car4Rent.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sofware_semester_2_Car4Rent.Controllers
{
    public class AutoController : Controller
    {


        public IActionResult Index(string begindatum, string einddatum)
        {
            AutoBoekingViewModel Abvm = new AutoBoekingViewModel();
            Abvm.begindatum = begindatum;
            Abvm.einddatum = einddatum;
            return View(Abvm);
        }


        [HttpPost]
        public IActionResult GetAllcars(string begindatum, string einddatum)
        {
            AutoCollection autoCollection = new AutoCollection();
            List<AutoBoekingViewModel> autoBoekingViewModel = new List<AutoBoekingViewModel>();

            foreach (Auto auto in autoCollection.GetAutos(begindatum, einddatum))
            {
                autoBoekingViewModel.Add(new AutoBoekingViewModel
                {
                    AutoID = auto.AutoID,
                    type = auto.type,
                    Merk = auto.Merk,
                    Kenteken = auto.Kenteken,
                    bouwjaar = auto.bouwjaar,
                    KM_stand = auto.KM_stand,
                    Brandstof = auto.Brandstof,
                    Zitplaatsen = auto.Zitplaatsen,
                    Versnellingsbak = auto.Versnellingsbak,
                    url = auto.Url,
                    prijs = auto.prijs,
                    begindatum = begindatum,
                    einddatum = einddatum,
                    
                });
                
            }
            return View(autoBoekingViewModel);
        }


        public IActionResult GetCar(int id, string begindatum, string einddatum)
        {
            AutoCollection autoCollection = new AutoCollection();
            AutoBoekingViewModel autoBoekingViewModel = new AutoBoekingViewModel();
            Auto auto = new Auto();
            DateTime StartDate = Convert.ToDateTime(begindatum);
            DateTime EndDate = Convert.ToDateTime(einddatum);
            int TotaalDagen = (EndDate - StartDate).Days;
            auto = autoCollection.GetAuto(id);

            autoBoekingViewModel.AutoID = auto.AutoID;
            autoBoekingViewModel.type = auto.type;
            autoBoekingViewModel.Merk = auto.Merk;
            autoBoekingViewModel.Kenteken = auto.Kenteken;
            autoBoekingViewModel.bouwjaar = auto.bouwjaar;
            autoBoekingViewModel.KM_stand = auto.KM_stand;
            autoBoekingViewModel.Brandstof = auto.Brandstof;
            autoBoekingViewModel.Zitplaatsen = auto.Zitplaatsen;
            autoBoekingViewModel.Versnellingsbak = auto.Versnellingsbak;
            autoBoekingViewModel.url = auto.Url;
            autoBoekingViewModel.prijs = auto.prijs;
            autoBoekingViewModel.begindatum = begindatum;
            autoBoekingViewModel.einddatum = einddatum;
            autoBoekingViewModel.TotaalDagen = TotaalDagen;
            autoBoekingViewModel.Totaalprijs = auto.prijs * TotaalDagen;

            return View(autoBoekingViewModel);

        }

        public IActionResult GetGebruikerAutos()
        {
            Gebruiker gebruiker = new Gebruiker
            {
                GebruikerID = Convert.ToInt32(User.Claims.First(claim => claim.Type == "ID").Value)
            };

            List<AutoViewModel> autoViewModel = new List<AutoViewModel>();

            foreach (Auto auto in gebruiker.GetAutosByGebruiker())
            {
                autoViewModel.Add(new AutoViewModel
                {
                    AutoID = auto.AutoID,
                    type = auto.type,
                    Merk = auto.Merk,
                    Kenteken = auto.Kenteken,
                    bouwjaar = auto.bouwjaar,
                    KM_stand = auto.KM_stand,
                    Brandstof = auto.Brandstof,
                    Zitplaatsen = auto.Zitplaatsen,
                    Versnellingsbak = auto.Versnellingsbak,
                    url = auto.Url,
                    prijs = auto.prijs,
                });
            }
            return View(autoViewModel);
        }
        
        //public IActionResult ListProducts()
        //{
        //    AutoCollection AutoCollection = new AutoCollection();
        //    List<AutoViewModel> autoViewModels = new List<AutoViewModel>();

        //    foreach (Auto auto in AutoCollection.GetAutos())
        //    {
        //        autoViewModels.Add(new AutoViewModel
        //        {
        //            type = auto.type,
        //            Merk = auto.Merk,
        //            Kenteken = auto.Kenteken,
        //            bouwjaar = auto.bouwjaar,
        //            KM_stand = auto.KM_stand,
        //            Brandstof = auto.Brandstof,
        //            Zitplaatsen = auto.Zitplaatsen,
        //            Versnellingsbak = auto.Versnellingsbak,
        //            url = auto.Url,
        //            prijs = auto.prijs

        //        });
        //    }
        //    return View(autoViewModels);

        //}

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

        public IActionResult DeleteAuto(int id)
        {
            AutoCollection autoCollection = new AutoCollection();

            autoCollection.Delete(id);

            return RedirectToAction("GetGebruikerAutos", "Auto");

            //autoViewModel.AutoID = auto.AutoID;
            //autoViewModel.type = auto.type;
            //autoViewModel.Merk = auto.Merk;
            //autoViewModel.Kenteken = auto.Kenteken;
            //autoViewModel.bouwjaar = auto.bouwjaar;
            //autoViewModel.KM_stand = auto.KM_stand;
            //autoViewModel.Brandstof = auto.Brandstof;
            //autoViewModel.Zitplaatsen = auto.Zitplaatsen;
            //autoViewModel.Versnellingsbak = auto.Versnellingsbak;
            //autoViewModel.url = auto.Url;
            //autoViewModel.prijs = auto.prijs;

            //return View(autoViewModel);
        }


        [HttpPost]
        public IActionResult DeleteAuto(AutoViewModel autoViewModel)
        {
            AutoCollection autoCollection = new AutoCollection();
            if (!ModelState.IsValid) return View();

            Auto auto = new Auto();
            auto.AutoID = autoViewModel.AutoID;

            //autoCollection.Delete(auto);

            return RedirectToAction("GetGebruikerAutos", "Auto");
        }

        //[HttpPost]
        //public IActionResult UpdateAuto()
        //{

        //}
    }
}
