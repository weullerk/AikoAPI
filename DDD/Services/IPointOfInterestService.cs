using DDD.Interfaces;
using DDD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Services
{
    public interface IPointOfInterestService
    {
        List<PointOfInterest> List(Func<PointOfInterest, bool> Criteria);

        PointOfInterest Get(Guid Id);

        PointOfInterest Create(PointOfInterest PointOfInterest);

        PointOfInterest Update(PointOfInterest PointOfInterest);

        void Delete(PointOfInterest PointOfInterest);

    }
}
