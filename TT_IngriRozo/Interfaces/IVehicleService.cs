using TT_IngriRozo.Models;

namespace TT_IngriRozo.Interfaces
{
    public interface IVehicleService
    {
        /// <summary>
        /// Obtiene los vehículos disponibles para recogida y devolución en las ubicaciones especificadas.
        /// </summary>
        /// <returns>Una colección de vehículos disponibles.</returns>
        IEnumerable<Vehicle> GetAvailableVehicles(Location pickupLocation, Location returnLocation);
        /// <summary>
        /// Obtiene los vehículos disponibles para un mercado específico.
        /// </summary>
        /// <returns>Una colección de vehículos disponibles para el mercado especificado.</returns>
        IEnumerable<Vehicle> GetVehiclesByMarket(Market market);
    }
}
