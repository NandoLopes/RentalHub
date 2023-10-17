using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Application.Interfaces
{
    public interface ILocadoraService : IRentalHubService
    {
        Task<LocadoraResponseDto> AddLocadora(LocadoraPostDto locadoraDto);
        Task<LocadoraResponseDto> UpdateLocadora(LocadoraPostDto locadoraDto);
        Task<PageList<LocadoraResponseDto>> GetAllLocadoras(PageParams pageParams);
        Task<PageList<LocadoraResponseDto>> GetLocadora(PageParams pageParams, LocadoraGetDto filter);
    }
}
