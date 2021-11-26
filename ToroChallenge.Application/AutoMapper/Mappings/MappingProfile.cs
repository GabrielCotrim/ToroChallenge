using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Requests;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.AutoMapper.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatrimonioAtivos, PositionReponse>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(or => or.QuantidadeAtivos))
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(or => or.Ativo.CurrentPrice))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(or => or.Ativo.Symbol));

            CreateMap<Patrimonio, UserPositionResponse>()
                .ForMember(dest => dest.CheckingAccountAmount, opt => opt.MapFrom(or => or.Saldo))
                .ForMember(dest => dest.Consolidated, opt => opt.MapFrom(or => or.Sumarizado))
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(or => or.PatrimonioAtivos));

            CreateMap<PatrimonioAtivos, OrderRequest>().ReverseMap()
                .ForMember(dest => dest.QuantidadeAtivos, opt => opt.MapFrom(or => or.Amount))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(or => new Ativo { Symbol = or.Symbol }));

            CreateMap<Ativo, TrendResponse>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(or => or.Symbol))
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(or => or.CurrentPrice));
        }
    }
}
