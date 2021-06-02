using System;
using System.Collections.Generic;
using System.Text;

namespace Car4Rent.Interfaces.DTO
{
    public class BoekingDTO
    {
        public int ID { get; set; }

        public int AutoID { get; set; }

        public int Huurder { get; set; }

        public string Begindatum { get; set; }

        public string Type { get; set; }

        public string Merk { get; set; }
        public string Einddatum { get; set; }
        public string BoekingDatum { get; set; }

        public decimal TotaalPrijs { get; set; }
    }
}
