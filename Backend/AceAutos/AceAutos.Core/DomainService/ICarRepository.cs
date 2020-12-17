using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.DomainService
{
    public interface ICarRepository
    {
        IEnumerable<Car> ReadAllCars();
        List<Car> GetAllCars();
        Car CreateCar(Car car);
        Car GetCarById(int id);
        Car Update(int id, Car updateCar);
        Car DeleteCar(int id);
        Car GetCar(long id);
        void AddCar(Car addCar);
        Car ReadCarByID(int carID);

    }
}
