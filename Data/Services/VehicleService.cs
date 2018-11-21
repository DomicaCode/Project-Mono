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

        private readonly ProjectDbContext _dbContext;



        public VehicleService(IMakeRepository makeRepository, IModelRepository modelRepository, ProjectDbContext context)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _dbContext = context;
        }

        public IEnumerable<VehicleDto> GetMake(int index, int count)
        {
            var data = _makeRepository.SelectListMake(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper(); 

            var vehicleDto = mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public IEnumerable<VehicleDto> GetModel(int index, int count)
        {
            var data = _modelRepository.SelectListModel(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public void InsertMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            _makeRepository.Insert(entity);
        }

        public void InsertModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            _modelRepository.Insert(entity);
        }

        public void DeleteMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            _makeRepository.Delete(entity);
        }

        public void DeleteModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            _modelRepository.Delete(entity);
        }

        public void UpdateMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            

            _makeRepository.Update(entity);
        }

        public void UpdateModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            _modelRepository.Update(entity);
        }

        public void DetailsMake(VehicleDto vehicleDto)
        {
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);


            _makeRepository.Details(entity);
        }

        public void DetailsModel(VehicleDto vehicleDto)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);


            _modelRepository.Details(entity);
        }

        public VehicleDto GetMakeById(int id)
        {
            var entity = _dbContext.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleMakeEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public VehicleDto GetModelByMakeId(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public VehicleDto GetModelById(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }
    }
}
