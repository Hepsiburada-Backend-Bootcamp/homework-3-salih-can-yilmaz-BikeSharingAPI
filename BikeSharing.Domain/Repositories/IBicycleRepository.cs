using System;
using System.Collections.Generic;
using BikeSharing.Domain.Entities;

namespace BikeSharing.Domain.Repositories
{
    public interface IBicycleRepository
    {
        List<Bicycle> GetAll();
        List<Bicycle> GetAll(params string[] columns);
        List<Bicycle> GetAll(string filter);
        List<Bicycle> GetAll(string filter, params string[] columns);
        Bicycle GetById(Guid Id);
        bool Create(Bicycle bicycle);
        bool Update(Bicycle bicycle);
        bool Delete(Guid Id);
    }
}