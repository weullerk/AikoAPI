using AutoMapper;
using DDD.Interfaces;
using DDD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly AppDbContext _Context;
        private readonly IMapper _Mapper;

        public PointOfInterestRepository(AppDbContext Context, IMapper Mapper)
        {
            _Context = Context ?? throw new ArgumentNullException(nameof(Context));
            _Mapper = Mapper;
        }

        public PointOfInterest Find(Guid Id)
        {
            var entity = _Context.PointOfInterests.AsNoTracking().AsQueryable().Where(x => x.Id == Id).FirstOrDefault();
            return _Mapper.Map<PointOfInterestEntity, PointOfInterest>(entity);
        }

        public List<PointOfInterest> List(Func<PointOfInterest, bool> Criteria)
        {
            List<PointOfInterestEntity> pointOfInterestEntities;

            if (Criteria == null)
            {
                pointOfInterestEntities = _Context.PointOfInterests.AsNoTracking().AsQueryable().Take(100).ToList();
            }
            else
            {
                var mappedCriteria = _Mapper.Map<Func<PointOfInterest, bool>, Func<PointOfInterestEntity, bool>>(Criteria);
                pointOfInterestEntities = _Context.PointOfInterests.AsNoTracking().AsQueryable().Where(mappedCriteria).ToList();
            }

            return _Mapper.Map<List<PointOfInterestEntity>, List<PointOfInterest>>(pointOfInterestEntities);
        }

        public PointOfInterest Add(PointOfInterest Obj)
        {
            var entity = _Mapper.Map<PointOfInterest, PointOfInterestEntity>(Obj);

            _Context.PointOfInterests.Add(entity);
            _Context.Entry(entity).State = EntityState.Added;

            _Context.SaveChanges();

            return _Mapper.Map<PointOfInterestEntity, PointOfInterest>(entity);
        }

        public PointOfInterest Update(PointOfInterest Obj)
        {
            var entity = _Mapper.Map<PointOfInterest, PointOfInterestEntity>(Obj);
            _Context.PointOfInterests.Update(entity);
            _Context.Entry(entity).State = EntityState.Modified;

            _Context.SaveChanges();

            return _Mapper.Map<PointOfInterestEntity, PointOfInterest>(entity);
        }

        public void Remove(PointOfInterest Obj)
        {
            var entity = _Mapper.Map<PointOfInterest, PointOfInterestEntity>(Obj);
            _Context.PointOfInterests.Remove(entity);
            _Context.Entry(entity).State = EntityState.Deleted;

            _Context.SaveChanges();
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
    }
}
