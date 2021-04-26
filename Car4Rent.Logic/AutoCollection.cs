using System.Collections.Generic;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces;
using Car4rent.Factory;

namespace Car4Rent.Logic
{
    public class AutoCollection
    {
        private IAutoDAL AutoDataAcces = AutoFactory.GetAutoDAL();

        public List<Auto> GetAutos()
        {
            List<Auto> auto = new List<Auto>();

            foreach (AutoDTO autoDTO in AutoDataAcces.GetAll())
            {
                auto.Add(new Auto
                {
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


        public void Create(Auto auto)
        {
            AutoDataAcces.AutoToevoegen(AutoToDTO(auto));
        }

        private AutoDTO AutoToDTO(Auto auto)
        {
            return new AutoDTO
            {
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
            };
        }








    }
}
