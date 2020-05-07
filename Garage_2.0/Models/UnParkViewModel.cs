using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class UnParkViewModel
    {
        [Display(Name = "Regnummer")]
        public string RegNum { get; set; }
        [Display(Name = "Typ")]
        public EnumType VehicleType { get; set; }
        [Display(Name = "Ankomst")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Lämnar")]
        public DateTime DepartureTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:d\\ hh\\:mm}")]
        [Display(Name = "Parkeringstid")]
        public TimeSpan TotalParkedTime { get; set; }

        [Display(Name = "Pris")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

    }
}
