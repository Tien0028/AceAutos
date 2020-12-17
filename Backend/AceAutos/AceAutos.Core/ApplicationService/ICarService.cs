using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface ICarService
    {
        public List<Car> GetCars();

        Car Create(Car car);
        
        Car Delete(int id);
        Car ReadCarById(int id);
        Car UpdateCar(int id, Car car);

        Car GetCar(long id);
    }
}