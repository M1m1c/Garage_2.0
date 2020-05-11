using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class StatsViewModel
    {
        public Dictionary<EnumType,int> AmountOfVehicleTypes { get; set; }

        [Display(Name = "Totalt antal fordon")]
        public int TotalVehicles { get; set; }
        [Display(Name = "Totalt antal hjul")]
        public int TotalWheels { get; set; }
        [Display(Name = "Totalta intäkter")]
        public float TotalGeneratedIncome { get; set; }
        [Display(Name = "Vanligaste färgen")]
        public EnumColor MostCommonColor { get; set; }
        [Display(Name = "Längsta parkering")]
        public DateTime OldestParkTime { get; set; }
    }
}
