using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Services
{
    public class MarketService : IMarketService
    {
        private readonly List<Market> _fakeMarketData;

        public MarketService()
        {
            _fakeMarketData = new List<Market>
        {
            new Market { Id = 1, Name = "Mercado 1", LocationId = 1 },
            new Market { Id = 2, Name = "Mercado 2", LocationId = 2 }
        };
        }

        // Obtener todos los mercados
        public IEnumerable<Market> GetMarkets()
        {
            return _fakeMarketData;
        }

        // Obtener un mercado por su ID
        public Market GetMarketById(int id)
        {
            return _fakeMarketData.SingleOrDefault(m => m.Id == id);
        }

        // Crear un nuevo mercado
        public Market CreateMarket(Market market)
        {
            market.Id = _fakeMarketData.Max(m => m.Id) + 1;
            _fakeMarketData.Add(market);
            return market;
        }

        // Actualizar un mercado existente
        public void UpdateMarket(Market market)
        {
            var existingMarket = _fakeMarketData.FirstOrDefault(m => m.Id == market.Id);
            if (existingMarket != null)
            {
                existingMarket.Name = market.Name;
                existingMarket.LocationId = market.LocationId;
            }
        }

        // Eliminar un mercado por su ID
        public void DeleteMarket(int id)
        {
            var existingMarket = _fakeMarketData.FirstOrDefault(m => m.Id == id);
            if (existingMarket != null)
            {
                _fakeMarketData.Remove(existingMarket);
            }
        }
    }
}
