using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public EnumType VehicleType { get; set; }

        public string RegNum { get; set; }

        public EnumColor Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Wheels { get; set; }

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
