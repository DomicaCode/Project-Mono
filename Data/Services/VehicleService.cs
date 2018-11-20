using Data.Entities;
using Data.Interfaces;
using EntityFrameworkPaginateCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;
using Data.Context;

namespace Data.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IMakeRepository _makeRepository;

        private readonly IModelRepository _modelRepository;



        public VehicleService(IMakeRepository makeRepository, IModelRepository modelRepository, ProjectDbContext context)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
        }

        public IEnumerable<VehicleMakeEntity> GetMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda)
        {
            var data = _makeRepository.SelectListMake(index, count, orderLambda);
            return data;
        }

        public IEnumerable<VehicleModelEntity> GetModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda)
        {
            var data = _modelRepository.SelectListModel(index, count, orderLambda);
            return data;
        }

        public void InsertMake(VehicleMakeEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            */
            _makeRepository.Insert(entity);
        }

        public void InsertModel(VehicleModelEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            */

            _modelRepository.Insert(entity);
        }

        public void DeleteMake(VehicleMakeEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            */
            _makeRepository.Delete(entity);
        }

        public void DeleteModel(VehicleModelEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            */

            _modelRepository.Delete(entity);
        }

        public void UpdateMake(VehicleMakeEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            */

            _makeRepository.Update(entity);
        }

        public void UpdateModel(VehicleModelEntity entity)
        {
            /*
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            */

            _modelRepository.Update(entity);
        }
    }
}
