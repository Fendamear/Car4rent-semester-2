using System;
using Car4Rent.Interfaces;
using Car4rent.Factory;

namespace Car4Rent.Logic
{
    public class Auto
    {
        public int AutoID { get; set; }
        public string type { get; set; }

        public string Merk { get; set; }

        public string Kenteken { get; set; }

        public int bouwjaar { get; set; }

        public int KM_stand { get; set; }

        public string Brandstof { get; set; }

        public string Versnellingsbak { get; set; }

        public int Zitplaatsen { get; set; }

        public string Url { get; set; }

        public decimal prijs { get; set; }

        public void Update(Auto auto)
        {
            AutoFactory.GetAutoDAL().Update(new AutoDTO
            {
                autoID = auto.AutoID,
                type = auto.type,
                Merk = auto.Merk,
                Kenteken = auto.Kenteken,
                bouwjaar = auto.bouwjaar,
                KM_stand = auto.KM_stand,
                Brandstof = auto.Brandstof,
                Zitplaatsen = auto.Zitplaatsen,
                Versnellingsbak = auto.Versnellingsbak,
                Url = auto.Url,
                prijs = auto.prijs
            })
        }



    }
}
