using Microsoft.AspNetCore.Mvc;
using RentalHub.Application.Interfaces;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogVeiculoController : ControllerBase
    {
        private readonly ILogVeiculoService _logVeiculoService;

        public LogVeiculoController(ILogVeiculoService logVeiculoService)
        {
            _logVeiculoService = logVeiculoService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams)
        {
            try
            {
                var logVeiculos = await _logVeiculoService.GetAllLogs(pageParams);
                if (logVeiculos == null) return NoContent();

                return Ok(logVeiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar logVeiculos. Erro: {ex.Message}");
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetLogVeiculo([FromQuery] PageParams pageParams, LogVeiculoDto logVeiculo)
        {
            try
            {
                var result = await _logVeiculoService.GetLog(pageParams, logVeiculo);
                if (result == null) return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar logVeiculo. Erro: {ex.Message}");
            }
        }
    }
}
