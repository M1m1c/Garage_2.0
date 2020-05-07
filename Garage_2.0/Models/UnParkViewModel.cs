using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class UnParkViewModel
    {
        public string RegNum { get; set; }

        public EnumType VehicleType { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public TimeSpan TotalParkedTime { get; set; }

        public Decimal Price { get; set; }

    }
}
