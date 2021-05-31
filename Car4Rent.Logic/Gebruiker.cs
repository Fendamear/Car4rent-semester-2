using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4rent.Factory;
using Car4Rent.Interfaces;

namespace Car4Rent.Logic
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

        public string GebruikersNaam { get; set; }

        public string BetaalGegevens { get; set; }

        public int Telnummer { get; set; }

        public string Adres { get; set; }
        public string regio { get; set; }

        private IAutoDAL AutoDataAcces = AutoFactory.GetAutoDAL();

        public List<Auto> GetAutosByGebruiker()
        {
            List<Auto> auto = new List<Auto>();

            foreach (AutoDTO autoDTO in AutoDataAcces.GetAllByGebruiker(GebruikerID))
            {
                auto.Add(new Auto
                {
                    AutoID = autoDTO.autoID,
                    type = autoDTO.type,
                    Merk = autoDTO.Merk,
                    Kenteken = autoDTO.Kenteken,
                    bouwjaar = autoDTO.bouwjaar,
                    KM_stand = autoDTO.KM_stand,
                    Brandstof = autoDTO.Brandstof,
                    Zitplaatsen = autoDTO.Zitplaatsen,
                    Versnellingsbak = autoDTO.Versnellingsbak,
                    Url = autoDTO.Url,
                    prijs = autoDTO.prijs
                });
            }
            return auto;        

        }

    }
}
