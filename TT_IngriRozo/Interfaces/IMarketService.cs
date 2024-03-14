using TT_IngriRozo.Models;

namespace TT_IngriRozo.Interfaces
{
    public interface IMarketService
    {
        // Obtener todos los mercados
        IEnumerable<Market> GetMarkets();

        // Obtener un mercado por su ID
        // Retorna el mercado si se encuentra, o null si no se encuentra
        Market GetMarketById(int id);

        // Crear un nuevo mercado
        // Retorna el mercado creado
        Market CreateMarket(Market market);

        // Actualizar un mercado existente
        // Retorna void
        void UpdateMarket(Market market);

        // Eliminar un mercado por su ID
        // Retorna void
        void DeleteMarket(int id);
    }
}
