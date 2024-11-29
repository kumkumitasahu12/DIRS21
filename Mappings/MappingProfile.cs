using AutoMapper;
using DIRS21Interview.Models;
using System;

namespace DIRS21Interview.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationInternalModel, ReservationPartnerModel>()
                .ForMember(d => d.ReservationId, o => o.MapFrom(src => src.ReservationId))
                .ForMember(d => d.CheckIn, o => o.MapFrom(src => src.CheckInDate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.CheckOut, o => o.MapFrom(src => src.CheckOutDate.ToString("yyyy-MM-dd")));

            CreateMap<ReservationPartnerModel, ReservationInternalModel>()
                .ForMember(d => d.ReservationId, o => o.MapFrom(src => src.ReservationId))
                .ForMember(d => d.CheckInDate, o => o.MapFrom(src => DateTime.Parse(src.CheckIn)))
                .ForMember(d => d.CheckOutDate, o => o.MapFrom(src => DateTime.Parse(src.CheckOut)));
        }
    }
}
