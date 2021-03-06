﻿using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Data.Entities;
using System.Linq.Expressions;
using System.Linq;

namespace Data.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        ProjectDbContext context;

        public MakeRepository Current { get; set; }

        private readonly IQueryable<VehicleMakeEntity> _source;

        public MakeRepository(ProjectDbContext context)
        {
            this.context = context;
            _source = this.context.VehicleMake;
        }

        public void Delete(VehicleMakeEntity entity)
        {
            context.VehicleMake.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(VehicleMakeEntity entity)
        {
            context.VehicleMake.Add(entity);
            context.SaveChanges();
        }

        public void Update(VehicleMakeEntity entity)
        {
            context.VehicleMake.Update(entity);
            context.SaveChanges();
        }

        public void Details(VehicleMakeEntity entity)
        {
            context.VehicleMake.Find(entity);
            context.SaveChanges();
        }

        public IEnumerable<VehicleMakeEntity> SelectListMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda)
        {
            return _source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
