using Application.DomainModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Aiko.Requests.PointOfInterest;

namespace Teste_Aiko.Mapper
{
    public class PointOfInterestApiMapping : Profile
    {
        public PointOfInterestApiMapping()
        {
            CreateMap<CreatePointOfInterestRequest, PointOfInterestDomainModel>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CoordinateX, opt => opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[0])))
                .ForMember(d => d.CoordinateY, opt => opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[1])))
                .ForMember(d => d.ZoomLevel, opt => {
                    opt.PreCondition(src => src.Coordinates.Split(',', StringSplitOptions.None).Length == 3);
                    opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[2].TrimEnd('z', 'Z')));
                });

            CreateMap<UpdatePointOfInterestRequest, PointOfInterestDomainModel>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CoordinateX, opt => opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[0])))
                .ForMember(d => d.CoordinateY, opt => opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[1])))
                .ForMember(d => d.ZoomLevel, opt => {
                    opt.PreCondition(src => src.Coordinates.Split(',', StringSplitOptions.None).Length == 3);
                    opt.MapFrom(src => Convert.ToDouble(src.Coordinates.Split(',', StringSplitOptions.None)[2].TrimEnd('z', 'Z')));
                });
        }
    }
}
