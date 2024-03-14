using Microsoft.AspNetCore.Mvc;
using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Obtiene todas los vehiculos disponibles.
        /// </summary>
        [HttpPost("search")]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles([FromBody] SearchRequest request)
        {
            try
            {
                var pickupLocation = new Location { Id = request.PickupLocationId };
                var returnLocation = new Location { Id = request.ReturnLocationId };
                var vehicles = _vehicleService.GetAvailableVehicles(pickupLocation, returnLocation);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al obtener los vehiculos: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene todas los vehiculos disponibles por mercado.
        /// </summary>
        [HttpGet("market/{marketId}")]
        public ActionResult<IEnumerable<Vehicle>> GetVehiclesByMarket(int marketId)
        {
            try
            {
                var market = new Market
                {
                    Id = marketId
                };
                var vehicles = _vehicleService.GetVehiclesByMarket(market);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al obtener los vehiculos por mercado: {ex.Message}");
            }
        }
    }

    public class SearchRequest
    {
        public int PickupLocationId { get; set; }
        public int ReturnLocationId { get; set; }
    }
}