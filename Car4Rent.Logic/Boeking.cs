using System;
using System.Collections.Generic;
using System.Text;

namespace Car4Rent.Logic
{
    public class Boeking
    {
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
    }
}
