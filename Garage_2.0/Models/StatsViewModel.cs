using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class StatsViewModel
    {
        public Dictionary<EnumType,int> AmountOfVehicleTypes { get; set; }

        public int TotalVehicles { get; set; }

        public int TotalWheels { get; set; }

        public float TotalGeneratedIncome { get; set; }

        public EnumColor MostCommonColor { get; set; }

        public DateTime OldestParkTime { get; set; }
    }
}
