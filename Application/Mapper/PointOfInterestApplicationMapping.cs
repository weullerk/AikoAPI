using Application.DomainModel;
using Application.ViewModel;
using AutoMapper;
using DDD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapper
{
    public class PointOfInterestApplicationMapping : Profile
    {
        public PointOfInterestApplicationMapping()
        {
            CreateMap<PointOfInterestDomainModel, PointOfInterest>().ReverseMap();

            CreateMap<PointOfInterest, PointOfInterestViewModel>()
                .ForMember(d => d.Coordinates, opt => opt.MapFrom(src => String.Format("{0},{1},{2}z", src.CoordinateX.ToString().Replace(',', '.'), src.CoordinateY.ToString().Replace(',', '.'), src.ZoomLevel.ToString().Replace(',', '.'))));
        }
    }
}
