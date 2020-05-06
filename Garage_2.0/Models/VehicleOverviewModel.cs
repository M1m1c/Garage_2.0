﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class VehicleOverviewModel
    {
        [Display(Name ="Fordonstyp")]
        public EnumType VehicleType { get; set; }

        [Display(Name = "Registrerings Nummer")]
        public string RegNum { get; set; }

        [Display(Name = "Fordonstyp")]
        public DateTime ArrivalTime { get; set; }
    }
}
