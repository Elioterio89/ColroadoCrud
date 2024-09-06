using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoCrud.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoTelefoneController : ControllerBase
    {
        private readonly ITipoTelefoneService _tipoTelefoneService;
        public TipoTelefoneController(ITipoTelefoneService tipoTelefoneService)
        {
            _tipoTelefoneService = tipoTelefoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposTelefone = await _tipoTelefoneService.GetAllTiposTelefoneAsync();
            return Ok(tiposTelefone);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipoTelefone = await _tipoTelefoneService.GetTipoTelefoneByIdAsync(id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }
            return Ok(tipoTelefone);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoTelefoneDto tipoTelefone)
        {
            await _tipoTelefoneService.AddTipoTelefoneAsync(tipoTelefone);
            return CreatedAtAction(nameof(Get), new { id = tipoTelefone.CodigoTipoTelefone }, tipoTelefone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoTelefoneDto tipoTelefone)
        {
            if (id != tipoTelefone.CodigoTipoTelefone)
            {
                return BadRequest();
            }
            await _tipoTelefoneService.UpdateTipoTelefoneAsync(tipoTelefone);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tipoTelefoneService.DeleteTipoTelefoneAsync(id);
            return NoContent();
        }
    }
}
