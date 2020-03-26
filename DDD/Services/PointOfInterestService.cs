using System;
using System.Collections.Generic;
using System.Text;
using DDD.Interfaces;
using DDD.Models;

namespace DDD.Services
{
    public class PointOfInterestService : IPointOfInterestService
    {
        IPointOfInterestRepository _Repository;

        public PointOfInterestService(IPointOfInterestRepository Repository)
        {
            _Repository = Repository;
        }

        public PointOfInterest Get(Guid Id)
        {
            return _Repository.Find(Id);
        }

        public List<PointOfInterest> List(Func<PointOfInterest, bool> Criteria)
        {
           return _Repository.List(null);
        }

        public PointOfInterest Create(PointOfInterest PointOfInterest)
        {
            return _Repository.Add(PointOfInterest);
        }

        public PointOfInterest Update(PointOfInterest PointOfInterest)
        {
            return _Repository.Update(PointOfInterest);
        }

        public void Delete(PointOfInterest PointOfInterest)
        {
            _Repository.Remove(PointOfInterest);
        }
    }
}
