using AutoMapper;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Application
{
    public class ModeloService : RentalHubService, IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public ModeloService(
            IModeloRepository modeloRepository,
            IMapper mapper) : base(modeloRepository)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<ModeloResponseDto> AddModelo(ModeloPostDto modeloDto)
        {
            try
            {
                var modeloMap = _mapper.Map<Modelo>(modeloDto);

                _modeloRepository.Add(modeloMap);

                if (await _modeloRepository.SaveChangesAsync())
                {
                    var result = await _modeloRepository.GetById<Modelo>(modeloMap.Id);

                    return _mapper.Map<ModeloResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModeloResponseDto> UpdateModelo(ModeloPostDto modeloDto)
        {
            try
            {
                var modelo = await _modeloRepository.GetById<Modelo>(Convert.ToInt32(modeloDto.Id));
                if (modelo == null) return null;

                _mapper.Map(modelo, modeloDto);

                _modeloRepository.Update(modeloDto);

                if (await _modeloRepository.SaveChangesAsync())
                {
                    var result = await _modeloRepository.GetById<Modelo>(modeloDto.Id);

                    return _mapper.Map<ModeloResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<ModeloResponseDto>> GetAllModelos(PageParams pageParams)
        {
            try
            {
                var result = await _modeloRepository.GetAllModelosAsync(pageParams);

                return _mapper.Map<PageList<ModeloResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<ModeloResponseDto>> GetModelo(PageParams pageParams, ModeloGetDto filter)
        {
            try
            {
                var result = await _modeloRepository.GetModeloByFilterAsync(pageParams, filter);

                return _mapper.Map<PageList<ModeloResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
