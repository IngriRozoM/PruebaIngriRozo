using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Services
{
    public class VehicleService : IVehicleService
    {
        private List<Vehicle> _fakeVehicleData;

        public VehicleService()
        {
            _fakeVehicleData = new List<Vehicle>
        {
            new Vehicle { Id = 1, Model = "Modelo 1", LocationId = 1 },
            new Vehicle { Id = 2, Model = "Modelo 2", LocationId = 1 }
        };
        }

        public IEnumerable<Vehicle> GetAvailableVehicles(Location pickupLocation, Location returnLocation)
        {
            return _fakeVehicleData.Where(v => v.LocationId == pickupLocation.Id || v.LocationId == returnLocation.Id).ToList();
        }

        public IEnumerable<Vehicle> GetVehiclesByMarket(Market market)
        {
            return _fakeVehicleData.Where(v => v.LocationId == market.LocationId).ToList();
        }
    }
}
