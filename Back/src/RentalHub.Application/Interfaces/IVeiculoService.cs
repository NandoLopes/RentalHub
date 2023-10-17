using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Application.Interfaces
{
    public interface IVeiculoService : IRentalHubService
    {
        Task<VeiculoResponseDto> AddVeiculo(VeiculoPostDto veiculoAddDto);
        Task<VeiculoResponseDto> UpdateVeiculo(VeiculoPostDto veiculo);
        Task<PageList<VeiculoResponseDto>> GetAllVeiculos(PageParams pageParams);
        Task<PageList<VeiculoResponseDto>> GetVeiculo(PageParams pageParams, VeiculoGetDto veiculoDto);
    }
}
