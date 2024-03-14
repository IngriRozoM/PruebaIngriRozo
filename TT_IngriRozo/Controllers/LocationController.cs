using Microsoft.AspNetCore.Mvc;
using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones disponibles.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            try
            {
                var locations = _locationService.GetLocations();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al obtener las ubicaciones: {ex.Message}");
            }
        }
    }
}
