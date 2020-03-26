using System;
using System.Collections.Generic;
using System.Text;
using Application.DomainModel;
using Application.Exceptions;
using Application.Mapper;
using Application.ViewModel;
using AutoMapper;
using DDD.Models;
using DDD.Services;

namespace Application.Services
{
    public class PointOfInterestApplicationService : IPointOfInterestApplicationService
    {
        private readonly IPointOfInterestService _PointOfInterestService;
        private readonly IMapper _Mapper;

        public PointOfInterestApplicationService(IPointOfInterestService PointOfInterestService, IMapper Mapper)
        {
            _PointOfInterestService = PointOfInterestService;
            _Mapper = Mapper;
        }

        public PointOfInterestViewModel Get(Guid id)
        {
            var pointOfInterest = _PointOfInterestService.Get(id);

            if (pointOfInterest == null)
                throw new NotFoundException("Não foi encontrado nenhum ponto de interesse com o identificador fornecido.");

            return _Mapper.Map<PointOfInterest, PointOfInterestViewModel>(pointOfInterest);
        }

        public List<PointOfInterestViewModel> List(Func<PointOfInterestDomainModel, bool> Criteria)
        {
            var pointOfInterests = _PointOfInterestService.List(null);
            return _Mapper.Map<List<PointOfInterest>, List<PointOfInterestViewModel>>(pointOfInterests);
        }

        public PointOfInterestViewModel Register(PointOfInterestDomainModel PointOfInterest)
        {
            var pointOfInterest = _Mapper.Map<PointOfInterestDomainModel, PointOfInterest>(PointOfInterest);
            var newPointOfInterest = _PointOfInterestService.Create(pointOfInterest);
            return _Mapper.Map<PointOfInterest, PointOfInterestViewModel>(newPointOfInterest);
        }

        public PointOfInterestViewModel Update(PointOfInterestDomainModel PointOfInterest)
        {
            var existPointOfInterest = _PointOfInterestService.Get(PointOfInterest.Id);
            if (existPointOfInterest == null)
                throw new NotFoundException("Não foi encontrado nenhum ponto de interesse com o identificador fornecido para ser atualizado.");

            var pointOfInterest = _Mapper.Map<PointOfInterestDomainModel, PointOfInterest>(PointOfInterest);
            var newPointOfInterest = _PointOfInterestService.Update(pointOfInterest);
            return _Mapper.Map<PointOfInterest, PointOfInterestViewModel>(newPointOfInterest);
        }

        public void Remove(Guid Id)
        {
            var pointOfInterest = _PointOfInterestService.Get(Id);

            if (pointOfInterest == null)
                throw new NotFoundException("Não foi encontrado nenhum ponto de interesse para ser removido.");

            _PointOfInterestService.Delete(pointOfInterest);
        }
    }
}
