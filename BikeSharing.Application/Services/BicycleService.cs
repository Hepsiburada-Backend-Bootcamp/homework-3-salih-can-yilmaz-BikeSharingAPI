using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BikeSharing.Application.DTOs.Bicycles;
using BikeSharing.Application.Services.IServices;
using BikeSharing.Application.Tools;
using BikeSharing.Domain.Entities;
using BikeSharing.Domain.Repositories;
using BikeSharing.Application.Helpers;

namespace BikeSharing.Application.Services
{
    public class BicycleService : IBicycleService
    {
        private readonly IBicycleRepository _BicycleRepository;
        private readonly IMapper _Mapper;

        public BicycleService(IBicycleRepository bicycleService, IMapper mapper)
        {
            this._BicycleRepository = bicycleService;
            this._Mapper = mapper;
        }

        public BicycleReadDTO GetBicycle(Guid Id)
        {
            Bicycle bicycleModel = _BicycleRepository.GetById(Id);

            BicycleReadDTO bicycleReadDTO = _Mapper.Map<BicycleReadDTO>(bicycleModel);

            return bicycleReadDTO;
        }

        public List<BicycleReadDTO> GetBicycles(string filter, string orderByParams, string fields)
        {
            List<Bicycle> bicycleModel;

            if (!String.IsNullOrWhiteSpace(fields))
            {
                if (!fields.Split(',').Contains("Id"))
                {

                    fields = "Id," + fields;
                }

                if (!String.IsNullOrWhiteSpace(filter))
                {
                    bicycleModel = _BicycleRepository.GetAll(filter, fields.Split(','));
                }
                bicycleModel = _BicycleRepository.GetAll(fields.Split(','));
            }
            else if (!String.IsNullOrWhiteSpace(filter))
            {
                bicycleModel = _BicycleRepository.GetAll(filter);
            }
            else
            {
                bicycleModel = _BicycleRepository.GetAll();
            }

            List<BicycleReadDTO> bicycleReadDTOs = _Mapper.Map<List<BicycleReadDTO>>(bicycleModel);

            if (!String.IsNullOrWhiteSpace(orderByParams))
            {
                return bicycleReadDTOs.OrderBy(orderByParams).ToList();
            }

            return bicycleReadDTOs;
        }

        public bool CreateBicycle(BicycleCreateDTO bicycleCreateDTO)
        {
            Bicycle bicycle = _Mapper.Map<Bicycle>(bicycleCreateDTO);

            return _BicycleRepository.Create(bicycle);
        }

        public bool UpdateBicycle(BicycleUpdateDTO bicycleUpdateDTO, bool setNullsToDefaults = false)
        {
            Bicycle bicycle;

            if (setNullsToDefaults)
            {
                bicycle = _Mapper.Map<Bicycle>(bicycleUpdateDTO);
            }
            else
            {
                bicycle = _BicycleRepository.GetById(bicycleUpdateDTO.Id);

                if (bicycle == null)
                {
                    return false;
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BicycleUpdateDTO, Bicycle>();
                    cfg.ForAllPropertyMaps(
                        pm => pm.TypeMap.SourceType == typeof(BicycleUpdateDTO),
                            (pm, c) => c.MapFrom(new IgnoreNullResolver(), pm.SourceMember.Name));
                });

                IMapper iMapper = config.CreateMapper();

                bicycle = iMapper.Map(bicycleUpdateDTO, bicycle);
            }

            return _BicycleRepository.Update(bicycle);
        }

        public bool DeleteBicycle(Guid Id)
        {
            return _BicycleRepository.Delete(Id);
        }
    }
}