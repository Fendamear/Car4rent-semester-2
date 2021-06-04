using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.DTO;
using Car4Rent.Interfaces.Interfaces;
using Car4rent.Factory;

namespace Car4Rent.Logic
{   
    public class Boeking
    {
        private IBoekingDAL BoekingDataAcces = BoekingFactory.GetBoekingDAL();
        public int ID { get; set; }

        public int AutoID {get; set;}

        public string Merk { get; set; }

        public string Type { get; set; }
        public int Huurder { get; set; }

        public string Begindatum { get; set; }
        public string Einddatum { get; set; }
        public string BoekingDatum { get; set; }

        public decimal TotaalPrijs { get; set; }

//        select distinct autoID, iif(AutoID not in (select distinct AutoID from boeking
//where '2021-06-06' <= Einddatum and Begindatum <= '2021-06-8'), 'true', 'false') as available from boeking
//where autoID = 1


        public void Update(Boeking boeking)
        {
            BoekingDataAcces.Update(new BoekingDTO
            {
                ID = ID,
                AutoID = boeking.AutoID,
                Huurder = boeking.Huurder,
                Merk = boeking.Merk,
                Type = boeking.Type,
                Begindatum = boeking.Begindatum,
                Einddatum = boeking.Einddatum,
                BoekingDatum = boeking.BoekingDatum,
                TotaalPrijs = boeking.TotaalPrijs
            });
        }

        public bool CheckIfUpdateIsPossible(int id, string begindatum, string einddatum)
        {
            return BoekingDataAcces.CheckUpdateDAL(id, begindatum, einddatum);
        }

    }
}
