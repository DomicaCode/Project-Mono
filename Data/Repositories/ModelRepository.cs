using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    class ModelRepository : IModelRepository
    {
        ProjectDbContext context;

        private readonly IQueryable<VehicleModelEntity> source;

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

        public IEnumerable<VehicleModelEntity> SelectListModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda)
        {
            return source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
