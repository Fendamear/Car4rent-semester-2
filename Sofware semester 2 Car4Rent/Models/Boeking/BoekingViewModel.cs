using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sofware_semester_2_Car4Rent.Models
{
    public class BoekingViewModel 
    {
        public string begindatum { get; set; }

        public string einddatum { get; set; }

        public string BoekingDatum { get; set; }

        public decimal prijs { get; set; }

        public int status { get; set; }


    }
}
