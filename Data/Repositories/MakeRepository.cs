using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Data.Entities;

namespace Data.Repositories
{
    class MakeRepository<TEntity> : IMakeRepository<TEntity>
    {
        ProjectDbContext context;

        public MakeRepository(ProjectDbContext context)
        {
            this.context = context;
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

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
