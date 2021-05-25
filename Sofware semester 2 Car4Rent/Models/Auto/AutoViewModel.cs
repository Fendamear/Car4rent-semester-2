using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sofware_semester_2_Car4Rent.Models
{
    public class AutoViewModel 
    {

        public int AutoID { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string Merk { get; set; }
        [Required]
        public string Kenteken { get; set; }
        [Required]
        public int bouwjaar { get; set; }

        [Required]
        public int KM_stand { get; set; }
        [Required]
        public string Brandstof { get; set; }
        [Required]
        public int Zitplaatsen { get; set; }
        [Required]
        public string Versnellingsbak { get; set; }
        [Required]
        public string url { get; set; }
        [Required]

        public decimal prijs { get; set; }
    }
}
