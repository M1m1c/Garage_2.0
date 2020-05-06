using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class Vehicle
    {

        
        public int Id { get; set; }
        [Required]
        [Display(Name = "Typ")]
        public EnumType VehicleType { get; set; }

        [Required]
        [Display(Name = "Regnummer")]
        public string RegNum { get; set; }

        [Required]
        [Display(Name ="Färg")]
        public EnumColor Color { get; set; }
        
        [Required]
        [Display(Name = "Fabrikat")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Hjul")]
        [Range(0,10)]
        public int Wheels { get; set; }

        [Display(Name = "Ankomst")]
        public DateTime ArrivalTime { get; set; }
    }

    public enum EnumType
    {
        Bil,
        MC,
        Buss,
        Båt,
        Flygplan,
        Cykel
    }
    
    public enum EnumColor
    {
        Svart,
        Blå,
        Röd,
        Grön,
        Gul,
        Grå,
        Orange,
        Vit,
        Annan
    }
}
