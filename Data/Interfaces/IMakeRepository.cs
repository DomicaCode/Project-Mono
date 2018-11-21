using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IMakeRepository : IDisposable
    {
        void Insert(VehicleMakeEntity entity);

        void Update(VehicleMakeEntity entity);

        void Delete(VehicleMakeEntity entity);

        IEnumerable<VehicleMakeEntity> SelectListMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda);

        void Details(VehicleMakeEntity entity);
    }
}
