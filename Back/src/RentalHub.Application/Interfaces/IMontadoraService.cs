using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Application.Interfaces
{
    public interface IMontadoraService : IRentalHubService
    {
        Task<MontadoraResponseDto> AddMontadora(MontadoraPostDto montadora);
        Task<MontadoraResponseDto> UpdateMontadora(MontadoraPostDto montadora);
        Task<PageList<MontadoraResponseDto>> GetAllMontadoras(PageParams pageParams);
        Task<PageList<MontadoraResponseDto>> GetMontadora(PageParams pageParams, MontadoraGetDto filter);
    }
}
