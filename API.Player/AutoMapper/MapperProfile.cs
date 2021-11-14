using API.Player.v1.Models;
using AutoMapper;
using DataAccess.Player.v1.DataEntities;
using System;

namespace API.Player.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region V1 Mappings
            // Player Mappings
            CreateMap<PlayerTableEntity, PlayerModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => Guid.Parse(src.RowKey)));

            CreateMap<PlayerAddModel, PlayerTableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore());

            CreateMap<PlayerUpdateModel, PlayerTableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore());
            #endregion
        }
    }
}
