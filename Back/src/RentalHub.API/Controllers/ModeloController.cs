using Microsoft.AspNetCore.Mvc;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams)
        {
            try
            {
                var modelos = await _modeloService.GetAllModelos(pageParams);
                if (modelos == null) return NoContent();

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar modelos. Erro: {ex.Message}");
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetModelo([FromQuery] PageParams pageParams, ModeloGetDto filter)
        {
            try
            {
                var modelo = await _modeloService.GetModelo(pageParams, filter);
                if (modelo == null) return NoContent();

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar modelo. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ModeloPostDto modeloDto)
        {
            try
            {
                if (modeloDto == null) return BadRequest("Modelo não informado.");

                ModeloResponseDto result = new();

                if (modeloDto.Id > 0)
                {
                    var resultGet = await _modeloService.GetById<Modelo>(modeloDto.Id);

                    if (resultGet == null) return BadRequest("Modelo não existe para atualizar.");

                    result = await _modeloService.UpdateModelo(modeloDto);
                }
                else
                {
                    result = await _modeloService.AddModelo(modeloDto);
                }

                if (result == null) return BadRequest("Erro ao salvar.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar modelo. Erro: {ex.Message}");
            }
        }
    }
}
