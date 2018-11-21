using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IModelRepository : IDisposable
    {
        void Insert(VehicleModelEntity entity);

        void Update(VehicleModelEntity entity);

        void Delete(VehicleModelEntity entity);

        IEnumerable<VehicleModelEntity> SelectListModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda);

        void Details(VehicleModelEntity entity);
    }
}
