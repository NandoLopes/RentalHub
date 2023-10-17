using AutoMapper;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Application
{
    public class LocadoraService : RentalHubService, ILocadoraService
    {
        private readonly ILocadoraRepository _locadoraRepository;
        private readonly IMapper _mapper;

        public LocadoraService(ILocadoraRepository locadoraRepository,
                               IMapper mapper) : base(locadoraRepository)
        {
            _locadoraRepository = locadoraRepository;
            _mapper = mapper;
        }

        public async Task<LocadoraResponseDto> AddLocadora(LocadoraPostDto locadoraDto)
        {
            try
            {
                var locadora = _mapper.Map<Locadora>(locadoraDto);

                _locadoraRepository.Add(locadora);

                if (await _locadoraRepository.SaveChangesAsync())
                {
                    var locadoraRetorno = await _locadoraRepository.GetById<Locadora>(locadora.Id);

                    return _mapper.Map<LocadoraResponseDto>(locadoraRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LocadoraResponseDto> UpdateLocadora(LocadoraPostDto locadoraDto)
        {
            try
            {
                if (locadoraDto.Id == 0) return null;

                var locadora = await _locadoraRepository.GetById<Locadora>(locadoraDto.Id);
                if (locadora == null) return null;

                _mapper.Map(locadoraDto, locadora);

                _locadoraRepository.Update(locadora);

                if (await _locadoraRepository.SaveChangesAsync())
                {
                    var locadoraRetorno = await _locadoraRepository.GetById<Locadora>(locadora.Id);

                    return _mapper.Map<LocadoraResponseDto>(locadoraRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<LocadoraResponseDto>> GetAllLocadoras(PageParams pageParams)
        {
            try
            {
                var result = await _locadoraRepository.GetAllLocadorasAsync(pageParams);

                return _mapper.Map<PageList<LocadoraResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<LocadoraResponseDto>> GetLocadora(PageParams pageParams, LocadoraGetDto filter)
        {
            try
            {
                var result = await _locadoraRepository.GetLocadoraByFilterAsync(pageParams, filter);

                return _mapper.Map<PageList<LocadoraResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
