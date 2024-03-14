using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Services
{
    public class LocationService : ILocationService
    {
        public IEnumerable<Location> GetLocations()
        {
            return new List<Location>
            {
                new Location { Id = 1, Name = "Localización 1" },
                new Location { Id = 2, Name = "Localización 2" }
            };
        }
    }
}
