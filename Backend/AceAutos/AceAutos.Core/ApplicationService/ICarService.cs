using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface ICarService
    {
        public List<Car> GetCars();
        Car CreateProduct(string Model, string Type, int Year, string Manufacturer, int Price, string Fuel, string Color, int Mileage);
        Car Create(Car car);
        Car Update(Car car);
        Car Delete(int id);
        Car ReadProductById(int id);
    }
}