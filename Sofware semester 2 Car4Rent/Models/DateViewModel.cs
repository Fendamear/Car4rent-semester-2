using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sofware_semester_2_Car4Rent.Models
{
    public class DateViewModel
    {
        [Required]
        public string begindatum { get; set; }
        [Required]
        public string einddatum { get; set; }
    }
}
