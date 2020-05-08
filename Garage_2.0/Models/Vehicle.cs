using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "Fordonstyp är obligatoriskt")]
        [Display(Name = "Typ")]

        public EnumType? VehicleType { get; set; }

        [Remote("IsAlreadySigned","Vehicles",HttpMethod ="POST",ErrorMessage ="Registrerings nummer redan använt")]
        [Required(ErrorMessage = "Registreringsnummer är obligatoriskt")]
        [Display(Name = "Regnummer")]
        [MaxLength(6, ErrorMessage = "Max 6 tecken")]
        public string RegNum { get; set; }

        [Required(ErrorMessage = "Färg på fordonet är obligatoriskt")]
        [Display(Name ="Färg")]
        public EnumColor? Color { get; set; }
        
        [Required(ErrorMessage = "Fabrikat är obligatoriskt")]
        [Display(Name = "Fabrikat")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Modell är obligatoriskt")]
        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Antal hjul är obligatoriskt")]
        [Display(Name = "Hjul")]
        [RegularExpression(@"^([0-9]|10)$", ErrorMessage = "Ange 0-10 hjul")]
        //[Range(0,10)]
        public int? Wheels { get; set; }

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
