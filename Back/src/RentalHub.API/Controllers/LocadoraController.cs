using Microsoft.AspNetCore.Mvc;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LocadoraController : ControllerBase
    {
        private readonly ILocadoraService _locadoraService;

        public LocadoraController(ILocadoraService locadoraService)
        {
            _locadoraService = locadoraService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams)
        {
            try
            {
                var locadoras = await _locadoraService.GetAllLocadoras(pageParams);
                if (locadoras == null) return NoContent();

                return Ok(locadoras);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar locadoras. Erro: {ex.Message}");
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetLocadora([FromQuery] PageParams pageParams, LocadoraGetDto filter)
        {
            try
            {
                var locadora = await _locadoraService.GetLocadora(pageParams, filter);
                if (locadora == null) return NoContent();

                return Ok(locadora);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar locadora. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LocadoraPostDto locadoraDto)
        {
            try
            {
                if (locadoraDto == null) return BadRequest("Locadora não informado.");

                LocadoraResponseDto result = new();

                if (locadoraDto.Id > 0)
                {
                    var resultGet = await _locadoraService.GetById<Locadora>(locadoraDto.Id);

                    if (resultGet == null) return BadRequest("Locadora não existe para atualizar.");

                    result = await _locadoraService.UpdateLocadora(locadoraDto);
                }
                else
                {
                    result = await _locadoraService.AddLocadora(locadoraDto);
                }

                if (result == null) return BadRequest("Erro ao salvar.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar locadora. Erro: {ex.Message}");
            }
        }
    }
}
