using AutoMapper;
using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Application
{
    public class VeiculoService : RentalHubService, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ILocadoraRepository _locadoraRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly ILogVeiculoRepository _logRepository;
        private readonly IMapper _mapper;

        public VeiculoService(
            IVeiculoRepository veiculoRepository,
            ILocadoraRepository locadoraRepository,
            IModeloRepository modeloRepository,
            ILogVeiculoRepository logRepository,
            IMapper mapper
            ) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _locadoraRepository = locadoraRepository;
            _modeloRepository = modeloRepository;
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<VeiculoResponseDto> AddVeiculo(VeiculoPostDto veiculoAddDto)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoAddDto);

                //TODO create methods HasLocadora & HasModelo
                veiculo.Locadora = await _locadoraRepository.GetById<Locadora>(veiculo.LocadoraId);
                if (veiculo.Locadora == null) return null;

                if (veiculoAddDto.ModeloId != null &&
                    await _modeloRepository.GetById<Modelo>(Convert.ToInt32(veiculoAddDto.ModeloId)) == null) return null;

                veiculo.LocadoraId = veiculoAddDto.LocadoraId;
                veiculo.ModeloId = veiculoAddDto.ModeloId ?? 0;

                _veiculoRepository.Add(veiculo);

                if (await _veiculoRepository.SaveChangesAsync())
                {
                    var result = await _veiculoRepository.GetById<Veiculo>(veiculo.Id);

                    await CreateLogVeiculo(result);

                    return _mapper.Map<VeiculoResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<VeiculoResponseDto>> GetAllVeiculos(PageParams pageParams)
        {
            try
            {
                var result = await _veiculoRepository.GetAllVeiculosAsync(pageParams);

                return _mapper.Map<PageList<VeiculoResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<VeiculoResponseDto>> GetVeiculo(PageParams pageParams, VeiculoGetDto veiculoDto)
        {
            try
            {
                var result = await _veiculoRepository.GetVeiculoByFilterAsync(pageParams, veiculoDto);

                return _mapper.Map<PageList<VeiculoResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VeiculoResponseDto> UpdateVeiculo(VeiculoPostDto veiculoDto)
        {
            try
            {
                var oldVeiculo = await _veiculoRepository.GetById<Veiculo>(veiculoDto.Id);

                if (oldVeiculo == null) return null;

                if (veiculoDto.LocadoraId != oldVeiculo.LocadoraId)
                {
                    var newVeiculoMap = _mapper.Map<Veiculo>(veiculoDto);
                    await AddTransferLogVeiculo(newVeiculoMap);
                }

                 var veiculo = _mapper.Map<Veiculo>(veiculoDto);

                _veiculoRepository.Update(veiculo);

                if (await _veiculoRepository.SaveChangesAsync())
                {
                    var result = await _veiculoRepository.GetById<Veiculo>(veiculo.Id);

                    return _mapper.Map<VeiculoResponseDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task CreateLogVeiculo(Veiculo newVeiculo)
        {
            _logRepository.Add(
                    new LogVeiculo { Veiculo = newVeiculo, Locadora = newVeiculo.Locadora, DataInicio = DateTime.UtcNow }
                );

            await _logRepository.SaveChangesAsync();
        }

        private async Task AddTransferLogVeiculo(Veiculo newVeiculo)
        {
            var log = (await _logRepository.GetLogAsync(new PageParams(), new LogVeiculoDto { VeiculoId = newVeiculo.Id })).FirstOrDefault();
            
            if (log == null) return;

            log.DataFim = DateTime.UtcNow;

            _logRepository.Update(log);

            await CreateLogVeiculo(newVeiculo);
        }
    }
}
