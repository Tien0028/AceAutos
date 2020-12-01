using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface ICarTypeService
    {
        CarType CreateCarType(CarType carType);
        IEnumerable<CarType> GetAllCarTypes();
        CarType GetCarTypeWithId(int id);
        CarType RemoveCarType(int id);
        CarType UpdateCarType(CarType productTypeToUpdate);
        IEnumerable<CarType> GetFilteredCarType(Filter filter);
    }
}
