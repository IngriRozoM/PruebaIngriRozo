using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TT_IngriRozo.Interfaces;
using TT_IngriRozo.Models;

namespace TT_IngriRozo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        /// <summary>
        /// Obtiene todas los mercado disponibles.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Market>> GetMarkets()
        {
            try
            {
                var markets = _marketService.GetMarkets();
                return Ok(markets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al obtener los mercados: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el mercado por Id.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Market> GetMarketById(int id)
        {
            var market = _marketService.GetMarketById(id);
            if (market == null)
            {
                return NotFound("No se encontró el mercado");
            }
            return Ok(market);
        }

        /// <summary>
        /// Crea el mercado
        /// </summary>
        [HttpPost]
        public ActionResult<Market> CreateMarket([FromBody] MarketRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var market = new Market
                {
                    Name = request.Name,
                    LocationId = request.LocationId
                };
                var createdMarket = _marketService.CreateMarket(market);
                return CreatedAtAction(nameof(GetMarketById), new { id = createdMarket.Id }, createdMarket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al crear el mercado: {ex.Message}");
            }
        }


        /// <summary>
        /// Actualiza el mercado
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateMarket(int id, [FromBody] MarketRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var market = new Market
                {
                    Id = id,
                    Name = request.Name,
                    LocationId = request.LocationId
                };
                _marketService.UpdateMarket(market);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al actualizar el mercado: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza el mercado
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteMarket(int id)
        {
            try
            {
                _marketService.DeleteMarket(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al eliminar el mercado: {ex.Message}");
            }
        }
    }

    public class MarketRequest
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
    }
}
