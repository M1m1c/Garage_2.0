using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class VehicleDetailViewModel
    {
        [Display(Name ="Antal Hjul")]
        public int Wheels { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Färg")]
        public EnumColor Color { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }
    }
}
