using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceAutos.Infrastructure.SQL.Repositories
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly DBContext _ctx;

        public CarTypeRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.CarTypes.Count();
        }

        public CarType Create(CarType carType)
        {
            var _carType = _ctx.Add(carType).Entity;
            _ctx.SaveChanges();
            return _carType;
        }

        public CarType DeleteCarType(int id)
        {
            var _carType = ReadyById(id);
            _ctx.Attach(_carType).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return _carType;
        }

        public IEnumerable<CarType> ReadAllCarTypes(Filter filter)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.CarTypes;
            }
            return _ctx.CarTypes
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public CarType ReadyById(int id)
        {
            return _ctx.CarTypes.FirstOrDefault(pt => pt.Id == id);
        }

        public CarType UpdateCarTypeInDB(CarType carType)
        {
            _ctx.Attach(carType).State = EntityState.Modified;
            _ctx.SaveChanges();
            return carType;
        }
    }
}
