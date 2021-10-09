using System;
using System.Collections.Generic;
using System.Linq;
using BikeSharing.Domain.Entities;
using BikeSharing.Domain.Repositories;
using BikeSharing.Infrastructure.Context;
using BikeSharing.Infrastructure.Helpers;
using System.Linq.Dynamic.Core;

namespace BikeSharing.Infrastructure.Repositories
{
    public class BicycleRepository : IBicycleRepository//todo repository base and async methods, new ile turememesi lazim, her islemden sonra db.savechanges yapilmamali context icerisinde scoped olmasi lazim
    {
        private readonly BikeSharingDBContext _sQLiteEFContext;
        public BicycleRepository(BikeSharingDBContext sQLiteEFContext)
        {
            this._sQLiteEFContext = sQLiteEFContext;
        }

        public List<Bicycle> GetAll()
        {
            return this._sQLiteEFContext.Bicycles.ToList();
            
        }

        public List<Bicycle> GetAll(params string[] columns)
        {
            return this._sQLiteEFContext.Bicycles.SelectMembers(columns).ToList();
        }

        public List<Bicycle> GetAll(string filter)
        {
            return this._sQLiteEFContext.Bicycles.Where(filter).ToList();
        }

        public List<Bicycle> GetAll(string filter, params string[] columns)
        {
            return this._sQLiteEFContext.Bicycles.Where(filter).SelectMembers(columns).ToList();
        }


        public Bicycle GetById(Guid Id)
        {
            return this._sQLiteEFContext.Bicycles.FirstOrDefault(bicycle => bicycle.Id == Id);
        }

        public bool Create(Bicycle bicycle)
        {
            this._sQLiteEFContext.Add(bicycle);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Update(Bicycle bicycle)
        {
            this._sQLiteEFContext.Update(bicycle);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            Bicycle bicycle = new Bicycle();
            bicycle.Id = Id;

            this._sQLiteEFContext.Remove(bicycle);
            this._sQLiteEFContext.SaveChanges();

            return true;
        }
    }
}