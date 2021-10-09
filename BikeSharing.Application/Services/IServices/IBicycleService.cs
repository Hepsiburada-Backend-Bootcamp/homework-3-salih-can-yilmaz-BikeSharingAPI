using System;
using System.Collections.Generic;
using BikeSharing.Application.DTOs.Bicycles;

namespace BikeSharing.Application.Services.IServices
{
    public interface IBicycleService
    {
        public BicycleReadDTO GetBicycle(Guid Id);
        public List<BicycleReadDTO> GetBicycles(string filter, string orderByParams, string fields);
        public bool CreateBicycle(BicycleCreateDTO bicycleCreateDTO);
        bool UpdateBicycle(BicycleUpdateDTO bicycleUpdateDTO, bool setNullsToDefaults = false);
        public bool DeleteBicycle(Guid Id);
    }
}