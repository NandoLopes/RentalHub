using AutoMapper;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;

namespace RentalHub.API.Helpers
{
    public class RentalHubProfile : Profile
    {
        public RentalHubProfile()
        {
            CreateMap<Locadora, LocadoraPostDto>().ReverseMap();
            CreateMap<Locadora, LocadoraResponseDto>().ReverseMap();
            CreateMap<Locadora, LocadoraGetDto>().ReverseMap();
            CreateMap<Locadora, LocadoraVeiculoAttributeDto>().ReverseMap();

            CreateMap<LogVeiculo, LogVeiculoDto>().ReverseMap();

            CreateMap<Modelo, ModeloGetDto>().ReverseMap();
            CreateMap<Modelo, ModeloMontadoraAttributeDto>().ReverseMap();
            CreateMap<Modelo, ModeloPostDto>().ReverseMap();
            CreateMap<Modelo, ModeloResponseDto>().ReverseMap();
            CreateMap<Modelo, ModeloVeiculoAttributeDto>().ReverseMap();

            CreateMap<Montadora, MontadoraAttributeDto>().ReverseMap();
            CreateMap<Montadora, MontadoraGetDto>().ReverseMap();
            CreateMap<Montadora, MontadoraPostDto>().ReverseMap();
            CreateMap<Montadora, MontadoraResponseDto>().ReverseMap();

            CreateMap<Veiculo, VeiculoGetDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoLocadoraAttributeDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoModeloAttributeDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoPostDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoResponseDto>().ReverseMap();
        }
    }
}
