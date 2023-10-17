using Microsoft.AspNetCore.Mvc;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MontadoraController : ControllerBase
    {
        private readonly IMontadoraService _montadoraService;

        public MontadoraController(IMontadoraService montadoraService)
        {
            _montadoraService = montadoraService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams)
        {
            try
            {
                var montadoras = await _montadoraService.GetAllMontadoras(pageParams);
                if (montadoras == null) return NoContent();

                return Ok(montadoras);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar montadoras. Erro: {ex.Message}");
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetMontadora([FromQuery] PageParams pageParams, MontadoraGetDto montadora)
        {
            try
            {
                var result = await _montadoraService.GetMontadora(pageParams, montadora);
                if (result == null) return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar montadora. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MontadoraPostDto montadora)
        {
            try
            {
                if (montadora == null) return BadRequest("Montadora não informado.");

                MontadoraResponseDto result = new();

                if (montadora.Id > 0)
                {
                    var resultGet = await _montadoraService.GetById<Montadora>(montadora.Id);

                    if (resultGet == null) return BadRequest("Montadora não existe para atualizar.");

                    result = await _montadoraService.UpdateMontadora(montadora);
                }
                else
                {
                    result = await _montadoraService.AddMontadora(montadora);
                }

                if (result == null) return BadRequest("Erro ao salvar.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar montadora. Erro: {ex.Message}");
            }
        }
    }
}
