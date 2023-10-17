using AutoMapper;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Application
{
    public class MontadoraService : RentalHubService, IMontadoraService
    {
        private readonly IMontadoraRepository _montadoraRepository;
        private readonly IMapper _mapper;

        public MontadoraService(
            IMontadoraRepository montadoraRepository,
            IMapper mapper) : base(montadoraRepository)
        {
            _montadoraRepository = montadoraRepository;
            _mapper = mapper;
        }

        public async Task<MontadoraResponseDto> AddMontadora(MontadoraPostDto montadoraDto)
        {
            try
            {
                var montadoraMap = _mapper.Map<Montadora>(montadoraDto);

                _montadoraRepository.Add(montadoraMap);

                if (await _montadoraRepository.SaveChangesAsync())
                {
                    var result = await _montadoraRepository.GetById<Montadora>(montadoraMap.Id);

                    return _mapper.Map<MontadoraResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MontadoraResponseDto> UpdateMontadora(MontadoraPostDto montadoraDto)
        {
            try
            {
                var montadora = await _montadoraRepository.GetById<Montadora>(montadoraDto.Id);
                if (montadora == null) return null;

                _mapper.Map(montadora, montadoraDto);

                _montadoraRepository.Update(montadoraDto);

                if (await _montadoraRepository.SaveChangesAsync())
                {
                    var result = await _montadoraRepository.GetById<Montadora>(montadoraDto.Id);

                    return _mapper.Map<MontadoraResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<MontadoraResponseDto>> GetAllMontadoras(PageParams pageParams)
        {
            try
            {
                var result = await _montadoraRepository.GetAllMontadorasAsync(pageParams);

                return _mapper.Map<PageList<MontadoraResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<MontadoraResponseDto>> GetMontadora(PageParams pageParams, MontadoraGetDto filter)
        {
            try
            {
                var result = await _montadoraRepository.GetMontadoraByFilterAsync(pageParams, filter);

                return _mapper.Map<PageList<MontadoraResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
