using AutoMapper;
using DDD.Models;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infra.Mapper
{
    public class PointOfInterestInfraMapping : Profile
    {
        public PointOfInterestInfraMapping()
        {
            CreateMap<PointOfInterestEntity, PointOfInterest>()
                .ForMember(d => d.CoordinateX, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',')[0], CultureInfo.InvariantCulture)))
                .ForMember(d => d.CoordinateY, opt => opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',')[1], CultureInfo.InvariantCulture)))
                .ForMember(d => d.ZoomLevel, opt => {
                    opt.PreCondition(src => src.Coordinates.Split(',').Length == 3);
                    opt.MapFrom(src => Double.Parse(src.Coordinates.Split(',')[2].TrimEnd('z', 'Z'), CultureInfo.InvariantCulture));
                });

            CreateMap<PointOfInterest, PointOfInterestEntity>()
                .ForMember(d => d.Coordinates, opt => opt.MapFrom(src => String.Format("{0},{1},{2}z", src.CoordinateX.ToString().Replace(',', '.'), src.CoordinateY.ToString().Replace(',', '.'), src.ZoomLevel.ToString().Replace(',', '.'))));
        }
    }
}
 