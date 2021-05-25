using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sofware_semester_2_Car4Rent.Models;

namespace Sofware_semester_2_Car4Rent.Models
{
    public class AutoBoekingViewModel
    {
        public int AutoID { get; set; }

        public string type { get; set; }

        public string Merk { get; set; }

        public string Kenteken { get; set; }

        public int bouwjaar { get; set; }

        public int KM_stand { get; set; }

        public string Brandstof { get; set; }

        public int Zitplaatsen { get; set; }

        public string Versnellingsbak { get; set; }

        public string url { get; set; }

        public decimal prijs { get; set; }

        public string begindatum { get; set; }

        public string einddatum { get; set; }

        public decimal Totaalprijs { get; set; }

        public int TotaalDagen { get; set; }
    }
}
