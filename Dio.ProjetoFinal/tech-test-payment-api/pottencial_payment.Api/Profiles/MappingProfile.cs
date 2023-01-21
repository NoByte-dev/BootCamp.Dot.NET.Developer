using AutoMapper;
using pottencial_payment.Domain.Contracts.Item;
using pottencial_payment.Domain.Contracts.Venda;
using pottencial_payment.Domain.Contracts.Vendedor;
using pottencial_payment.Domain.Entities;

namespace pottencial_payment.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VendedorRequest, Vendedor>().ReverseMap();
            CreateMap<VendedorResponse, Vendedor>().ReverseMap();

            CreateMap<VendaRequest, Venda>().ReverseMap();
            CreateMap<VendaResponse, Venda>().ReverseMap();
            CreateMap<VendaResponseItens, Venda>().ReverseMap();

            CreateMap<ItemRequest, Item>().ReverseMap();
            CreateMap<ItemResponse, Item>().ReverseMap();
        }
    }
}
