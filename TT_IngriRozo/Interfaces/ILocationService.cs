using TT_IngriRozo.Models;

namespace TT_IngriRozo.Interfaces
{
    public interface ILocationService
    {
        /// <summary>
        /// Obtiene todas las ubicaciones disponibles.
        /// </summary>
        /// /// <returns>Una colección de ubicaciones.</returns>
        IEnumerable<Location> GetLocations();
    }
}
