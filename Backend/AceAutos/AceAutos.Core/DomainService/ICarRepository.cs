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
        Car CreateProduct(Car product);
        Car GetProductByID(int id);
        Car Update(Car updateCar);
        Car DeleteCar(int id);
        Car GetCar(long id);
        void AddProduct(Car addProduct);
        void RemoveProduct(long id);
        Car EditCar(string Model, string Type, int Year, string Manufacturer, int Price, string Fuel, string Color, int Mileage);

    }
}
