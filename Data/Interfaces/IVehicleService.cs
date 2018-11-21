using Data.Entities;
using EntityFrameworkPaginateCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDto> GetMake(int index, int count);

        IEnumerable<VehicleDto> GetModel(int index, int count);

        void InsertMake(VehicleDto entity);
        void InsertModel(VehicleDto entity);

        void DeleteMake(VehicleDto entity);
        void DeleteModel(VehicleDto entity);

        void UpdateMake(VehicleDto entity);
        void UpdateModel(VehicleDto entity);

        VehicleDto GetMakeById(int id);
        VehicleDto GetModelByMakeId(int id);
        VehicleDto GetModelById(int id);
    }
}
