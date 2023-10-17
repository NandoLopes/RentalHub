using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Application.Interfaces
{
    public interface IModeloService : IRentalHubService
    {
        Task<ModeloResponseDto> AddModelo(ModeloPostDto modelo);
        Task<ModeloResponseDto> UpdateModelo(ModeloPostDto modelo);
        Task<PageList<ModeloResponseDto>> GetAllModelos(PageParams pageParams);
        Task<PageList<ModeloResponseDto>> GetModelo(PageParams pageParams, ModeloGetDto filter);
    }
}
