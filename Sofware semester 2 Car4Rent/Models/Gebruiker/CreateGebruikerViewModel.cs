using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sofware_semester_2_Car4Rent.Models.Gebruiker
{
    public class CreateGebruikerViewModel
    { 
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
        [Required]

        public string GebruikersNaam { get; set; }
        [Required]

        public string BetaalGegevens { get; set; }
        [Required]

        public int Telnummer { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string regio { get; set; }

    }
}
