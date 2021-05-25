using System;
using System.Collections.Generic;
using System.Text;

namespace Car4Rent.Interfaces.DTO
{
    public class GebruikerDTO
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
    }
}
