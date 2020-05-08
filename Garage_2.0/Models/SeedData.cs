using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Garage_2._0.Models
{
    public static class SeedData
    {
        public static void Initalise(IServiceProvider serviceProvider)
        {
            using var Context = new Garage_2_0Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Garage_2_0Context>>());
            if (Context.Vehicle.Any())
            {
                return;
            }

            var lines = File.ReadAllLines(@"SampleData\TestFordon.txt");
            for (int i = 1; i < lines.Length; i++)
            {
                var SampleColumns = lines[i].Split(",");
                Context.Vehicle.AddRange(
                new Vehicle
                {
                    // 0 VehicleType
                    // 1 RegNum
                    // 2 Wheels
                    // 3 Color
                    // 4 Brand
                    // 5 Model
                    // 6 ArrivalTime

                    VehicleType = (EnumType)Enum.Parse(typeof(EnumType), SampleColumns[0]),
                    RegNum = SampleColumns[1],
                    Wheels = int.Parse(SampleColumns[2]),
                    Color = (EnumColor) Enum.Parse(typeof(EnumColor), SampleColumns[3]),
                    Brand = SampleColumns[4],
                    Model = SampleColumns[5],
                    ArrivalTime = DateTime.Parse(SampleColumns[6])
                });
            }
            Context.SaveChanges();
        }
    }
}
