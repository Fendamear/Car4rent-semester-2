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
                AutoID = boeking.AutoID,
                //Huurder = boeking.Huurder,
                Begindatum = boeking.Begindatum,
                Einddatum = boeking.Einddatum,
                TotaalPrijs = boeking.TotaalPrijs
            };
        }
    }
}
