using Application.DomainModel;
using Application.ViewModel;
using DDD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IPointOfInterestApplicationService
    {

        PointOfInterestViewModel Get(Guid id);

        List<PointOfInterestViewModel> List(Func<PointOfInterestDomainModel, bool> Criteria);
        PointOfInterestViewModel Register(PointOfInterestDomainModel PointOfInterest);

        PointOfInterestViewModel Update(PointOfInterestDomainModel PointOfInterest);

        void Remove(Guid Id);
    }
}
