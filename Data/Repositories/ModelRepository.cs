using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    class ModelRepository<TEntity> : IModelRepository<TEntity>
    {
        ProjectDbContext context;

        public ModelRepository(ProjectDbContext context)
        {
            this.context = context;
        }

        public void Delete(VehicleModelEntity entity)
        {
            context.VehicleModel.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(VehicleModelEntity entity)
        {
            context.VehicleModel.Add(entity);
            context.SaveChanges();
        }

        public void Update(VehicleModelEntity entity)
        {
            context.VehicleModel.Update(entity);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
