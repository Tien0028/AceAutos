using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceAutos.Infrastructure.SQL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DBContext _ctx;
        public static int CarId = 1;

        private static List<Car> _listOfCars = new List<Car>();

        public CarRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _listOfCars;
        }

        public List<Car> GetAllCars()
        {
            return _ctx.Cars.ToList();
        }

        public Car CreateCar(Car car)
        {
            _ctx.Attach(car).State = EntityState.Added;
            _ctx.SaveChanges();
            return car;
        }

        public Car GetCarById(int id)
        {
            return _ctx.Cars.FirstOrDefault(car => car.Id == id);
        }

        public Car Update(int id, Car updateCar)
        {
            var currentCar = GetCarById(id);
            if(currentCar != null){
                currentCar.Color = updateCar.Color;
                currentCar.Description = updateCar.Description;
                currentCar.Fuel = updateCar.Fuel;
                currentCar.Manufacturer = updateCar.Manufacturer;
                currentCar.Mileage = updateCar.Mileage;
                currentCar.Model = updateCar.Model;
                currentCar.Price = updateCar.Price;
                currentCar.Type = updateCar.Type;
                currentCar.Year = updateCar.Year;
                _ctx.Entry(currentCar).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            return updateCar;
        }

        public Car DeleteCar(int id)
        {
            var car = _ctx.Cars.FirstOrDefault(c => c.Id == id);
            _ctx.Entry(car).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return car;
        }

        public Car GetCar(long id)
        {
            return _ctx.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void AddCar(Car addCar)
        {
            _ctx.Cars.Add(addCar);
            _ctx.SaveChanges();
        }

        public void RemoveCar(long id)
        {
            var car = _ctx.Cars.FirstOrDefault(c => c.Id == id);
            _ctx.Cars.Remove(car);
            _ctx.SaveChanges();
        }

        public Car EditCar(string Model, string Type, int Year, string Manufacturer, int Price, string Fuel, string Color, int Mileage)
        {
            throw new NotImplementedException();
        }

        public Car ReadCarByID(int carID)
        {
            return _ctx.Cars.FirstOrDefault(car => car.Id == carID);
        }
    }
}
