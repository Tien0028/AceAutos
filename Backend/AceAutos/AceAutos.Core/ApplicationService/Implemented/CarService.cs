using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AceAutos.Core.ApplicationService.Implemented
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepo;

        public CarService(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Car Create(Car car)
        {
            if (car.Model == null || car.Model.Length < 1)
            {
                
                throw new ArgumentException("wrong!!");
            }
            if (string.IsNullOrEmpty(car.Manufacturer))
            {
                throw new ArgumentException("Car needs Manufacturer");
            }
            if (string.IsNullOrEmpty(car.Color))
            {
                throw new ArgumentException("Car needs a color!");
            }
            return _carRepo.CreateCar(car);
        }



        public Car Delete(int id)
        {
            if (id < 1)
            {
                throw new InvalidDataException("ID must be higher than one! Otherwise, you failed!");
            }
            return _carRepo.DeleteCar(id);
        }

        public Car GetCar(long id)
        {
            return _carRepo.GetCar(id);
        }

        public List<Car> GetCars()
        {
            return _carRepo.GetAllCars();
        }


        public Car ReadCarById(int id)
        {
            
            return _carRepo.ReadCarByID(id);
        }

        public Car UpdateCar(int id, Car car)
        {
           return _carRepo.Update(id ,car);
        }
    }
}