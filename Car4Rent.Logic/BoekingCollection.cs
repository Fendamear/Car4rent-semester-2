using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces.DTO;
using Car4rent.Factory;

namespace Car4Rent.Logic
{
    public class BoekingCollection
    {
        private IBoekingDAL BoekingDataAcces = BoekingFactory.GetBoekingDAL();

        public void Create(Boeking boeking)
        {
            BoekingDataAcces.BoekingToevoegen(BoekingToDTO(boeking));
        }

        private BoekingDTO BoekingToDTO(Boeking boeking)
        {
            return new BoekingDTO
            {
                ID = boeking.ID,
                AutoID = boeking.AutoID,
                //Huurder = boeking.Huurder,
                Begindatum = boeking.Begindatum,
                Einddatum = boeking.Einddatum,
                TotaalPrijs = boeking.TotaalPrijs
            };
        }

        public Boeking GetBoeking(int id)
        {
            BoekingDTO boekingDTO = BoekingDataAcces.GetByID(id);

            return new Boeking
            {
                ID = boekingDTO.ID,
                Huurder = boekingDTO.Huurder,
                AutoID = boekingDTO.AutoID,
                Type = boekingDTO.Type,
                Merk = boekingDTO.Merk,
                Begindatum = boekingDTO.Begindatum,
                Einddatum = boekingDTO.Einddatum,
                BoekingDatum = boekingDTO.BoekingDatum,
                TotaalPrijs = boekingDTO.TotaalPrijs
            };

        }

        public void Delete(Boeking boeking)
        {
            BoekingDataAcces.Delete(BoekingToDTO(boeking));
        }

        public void Update(Boeking boeking)
        {

        }
        
    }
}
