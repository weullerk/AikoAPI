using Application.DomainModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                .ForMember(d => d.CoordinateX, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[0], CultureInfo.InvariantCulture)))
                .ForMember(d => d.CoordinateY, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[1], CultureInfo.InvariantCulture)))
                .ForMember(d => d.ZoomLevel, opt => {
                    opt.PreCondition(src => src.Coordinates.Split(',', StringSplitOptions.None).Length == 3);
                    opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[2].TrimEnd('z', 'Z'), CultureInfo.InvariantCulture));
                });

            CreateMap<UpdatePointOfInterestRequest, PointOfInterestDomainModel>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CoordinateX, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[0], CultureInfo.InvariantCulture)))
                .ForMember(d => d.CoordinateY, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[1], CultureInfo.InvariantCulture)))
                .ForMember(d => d.ZoomLevel, opt => {
                    opt.PreCondition(src => src.Coordinates.Split(',', StringSplitOptions.None).Length == 3);
                    opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',', StringSplitOptions.None)[2].TrimEnd('z', 'Z'), CultureInfo.InvariantCulture));
                });
        }
    }
}
