using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoCrud.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var telefones = await _telefoneService.GetAllTelefonesAsync();
            return Ok(telefones);
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> Get(string numero)
        {
            var telefone = await _telefoneService.GetTelefoneByIdAsync(numero);
            if (telefone == null)
            {
                return NotFound();
            }
            return Ok(telefone);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelefoneDto telefone)
        {
            var tel = await _telefoneService.GetExiste(telefone.NumeroTelefone);
            if (tel == false)
            {
                await _telefoneService.AddTelefoneAsync(telefone);
                return CreatedAtAction(nameof(Get), new { numero = telefone.NumeroTelefone }, telefone);
            }
            else
            {
                return BadRequest("Numero ja existe!");
            }          
        }

        [HttpPut("{numero}")]
        public async Task<IActionResult> Update(string numero, [FromBody] TelefoneDto telefone)
        {
            if (numero != telefone.NumeroTelefone)
            {
                return BadRequest();
            }
            await _telefoneService.UpdateTelefoneAsync(telefone);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> Delete(string numero)
        {
            await _telefoneService.DeleteTelefoneAsync(numero);
            return NoContent();
        }

    }
}
