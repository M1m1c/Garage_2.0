using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public static class SeedData
    {
        public static void Initalise(IServiceProvider serviceProvider)
        {
            using (var Context = new Garage_2_0Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Garage_2_0Context>>()))
            {
                if (Context.Vehicle.Any())
                {
                    return;
                }

                Context.Vehicle.AddRange(
                    new Vehicle
                    {
                        VehicleType = EnumType.Bil,
                        RegNum = "ABC123",
                        Color = EnumColor.Blå,
                        Brand = "BMW",
                        Model = "1",
                        Wheels = 4,
                        ArrivalTime = DateTime.Now
                    },
                     new Vehicle
                     {
                         VehicleType = EnumType.Bil,
                         RegNum = "DBC123",
                         Color = EnumColor.Röd,
                         Brand = "Audi",
                         Model = "1",
                         Wheels = 4,
                         ArrivalTime = DateTime.Now
                     }
                    );
                Context.SaveChanges();
            }
        }
    }
}
