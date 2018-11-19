﻿using Data.Entities;
using EntityFrameworkPaginateCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleMakeEntity> GetMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda);

        IEnumerable<VehicleModelEntity> GetModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda);
    }
}