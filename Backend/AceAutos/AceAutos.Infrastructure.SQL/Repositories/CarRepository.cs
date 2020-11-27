using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Infrastructure.SQL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DBContext _ctx;
        public static int CarID = 1;

        private static List<Car> _listOfCars = new List<Car>();

        public CarRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Car> ReadAllCars()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car CreateProduct(Car product)
        {
            throw new NotImplementedException();
        }

        public Car GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car updateCar)
        {
            throw new NotImplementedException();
        }

        public Car DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetCar(long id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Car addProduct)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(long id)
        {
            throw new NotImplementedException();
        }

        public Car EditCar(string Model, string Type, int Year, string Manufacturer, int Price, string Fuel, string Color, int Mileage)
        {
            throw new NotImplementedException();
        }
    }
}
