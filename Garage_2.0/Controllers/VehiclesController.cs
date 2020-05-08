using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Data;
using Garage_2._0.Models;

namespace Garage_2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_2_0Context _context;

        public VehiclesController(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleType,RegNum,Color,Brand,Model,Wheels,ArrivalTime")] Vehicle vehicle)
        {
            vehicle.ArrivalTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                vehicle.RegNum = vehicle.RegNum.ToUpper();
                vehicle.Brand = vehicle.Brand.ToUpper();
                vehicle.Model = vehicle.Model.ToUpper();

                if (_context.Vehicle.Any(v => v.RegNum == vehicle.RegNum) == false)
                {
                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    //TODO Change to parked and make park method
                    return RedirectToAction(nameof(Parked), ToOverviewModel(vehicle));
                }
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleType,RegNum,Color,Brand,Model,Wheels,ArrivalTime")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    _context.Entry(vehicle).Property(p => p.ArrivalTime).IsModified = false;
                    _context.Entry(vehicle).Property(p => p.VehicleType).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetOverviewModel));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            var temp = ToUnPark(vehicle);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LeaveGarage),temp);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> GetOverviewModel(Column column)
        {

            var orderedVehicles = DetermineColumnSort(column);

            var model = orderedVehicles.Select(v => ToOverviewModel(v));

            return View(await model.ToListAsync());
        }

        private IOrderedQueryable<Vehicle> DetermineColumnSort(Column column)
        {
            switch (column)
            {
                default:
                    return _context.Vehicle.OrderBy(v => v.Id);
                    break;
                case Column.EArrivalTime:
                   // GetT<DateTime>(_context.Vehicle.FirstOrDefault());
                    return _context.Vehicle.OrderBy(v => v.ArrivalTime);
                    break;
                case Column.ERegNum:
                    return _context.Vehicle.OrderBy(v => v.RegNum);
                    break;
                case Column.EVehicleType:
                    return _context.Vehicle.OrderBy(v => v.VehicleType);
                    break;
            }
        }

        /*private T GetT<T>(Vehicle v)
        {
           var ret= v.GetType().GetProperties().FirstOrDefault(p => p.GetType() == typeof(T)).GetType();
            return ret;
        }*/


        static public VehicleOverviewModel ToOverviewModel(Vehicle v)
        {
            return new VehicleOverviewModel
            {
                Id = v.Id,
                VehicleType = v.VehicleType,
                RegNum = v.RegNum,
                ArrivalTime = v.ArrivalTime
            };
        }

        public async Task<IActionResult> GetDetailViewModel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var model = ToDetailView(vehicle);

            return View(model);
        }

        static public VehicleDetailViewModel ToDetailView(Vehicle v)
        {
            if (v == null) { return null; }

            return new VehicleDetailViewModel
            {
                Id = v.Id,
                Wheels = v.Wheels,
                Brand = v.Brand,
                Color = v.Color,
                Model = v.Model
            };
        }

        public IActionResult Parked(VehicleOverviewModel vehicle)
        {
            return View(vehicle);
        }

        public IActionResult LeaveGarage(UnParkViewModel vehicle)
        {
            return View(vehicle);
        }

        public UnParkViewModel ToUnPark(Vehicle vehicle)
        {
            var ret = new UnParkViewModel
            {
                RegNum = vehicle.RegNum,
                VehicleType = vehicle.VehicleType,
                ArrivalTime = vehicle.ArrivalTime,
                DepartureTime = DateTime.Now
            };

           
            ret.TotalParkedTime = ret.DepartureTime - ret.ArrivalTime;
            

            ret.Price = ret.TotalParkedTime.Hours * 100;
            ret.Price += ret.TotalParkedTime.Days * 24 * 100;

            return ret;
        }

        public async Task<IActionResult> SearchFilter(string regNum,int? vType)
        {
            var vehicles = string.IsNullOrWhiteSpace(regNum) ?
                _context.Vehicle :
                _context.Vehicle.Where(v => v.RegNum.StartsWith(regNum.ToUpper()));

            vehicles = vType == null ? vehicles : vehicles.Where(v => v.VehicleType == (EnumType)vType);

            var overview = vehicles.Select(v => ToOverviewModel(v));

            return View(nameof(GetOverviewModel), await overview.ToListAsync());
        } 
    }
}
