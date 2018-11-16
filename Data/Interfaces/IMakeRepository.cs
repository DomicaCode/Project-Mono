using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Interfaces
{
    interface IMakeRepository<TEntity> : IDisposable
    {
        void Insert(VehicleMakeEntity entity);

        void Update(VehicleMakeEntity entity);

        void Delete(VehicleMakeEntity entity);
    }
}
