using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sofware_semester_2_Car4Rent.Models
{
    public class BoekingViewModel 
    {
        [Display(Name = "BoekingNr")]
        public int ID { get; set; }

        public int AutoID { get; set; }
        public int HuurderID { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public string begindatum { get; set; }

        public string einddatum { get; set; }

        public string BoekingDatum { get; set; }

        [DisplayFormat(DataFormatString = "€ {0:n} ")]
        public decimal prijs { get; set; }




    }
}
