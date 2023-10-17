using Microsoft.AspNetCore.Mvc;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams)
        {
            try
            {
                var veiculos = await _veiculoService.GetAllVeiculos(pageParams);
                if (veiculos == null) return NoContent();

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar veiculos. Erro: {ex.Message}");
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetVeiculo([FromQuery] PageParams pageParams, VeiculoGetDto veiculo)
        {
            try
            {
                var result = await _veiculoService.GetVeiculo(pageParams, veiculo);
                if (result == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar veiculo. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(VeiculoPostDto veiculo)
        {
            try
            {
                if (veiculo == null) return BadRequest("Veiculo não informado.");

                VeiculoResponseDto result = new();

                if (veiculo.Id > 0)
                {
                    var resultGet = await _veiculoService.GetById<Veiculo>(veiculo.Id);

                    if (resultGet == null) return BadRequest("Veiculo não existe para atualizar.");

                    result = await _veiculoService.UpdateVeiculo(veiculo);
                }
                else
                {
                    result = await _veiculoService.AddVeiculo(veiculo);
                }

                if (result == null) return BadRequest("Erro ao salvar.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar veiculo. Erro: {ex.Message}");
            }
        }
    }
}
