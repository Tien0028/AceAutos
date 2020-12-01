using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.DomainService
{
    public interface ICarTypeRepository
    {
        CarType Create(CarType carType);
        IEnumerable<CarType> ReadAllCarTypes(Filter filter = null);
        CarType ReadyById(int id);
        CarType DeleteCarType(int id);
        int Count();
        CarType UpdateCarTypeInDB(CarType carType);
    }
}