using AceAutos.Core.ApplicationService;
using AceAutos.Core.ApplicationService.Implemented;
using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Moq;
using System;
using Xunit;

namespace UnitTests2
{
    public class CarTest
    {
        [Fact]
        public void ReadById()
        {
            //Validate Read Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();

            int Id = 1;
            Car car1 = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "5",
                Color = "Black",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.ReadCarByID(Id)).Returns(car1);
            ICarService carService = new CarService(carRepo.Object);
            var actual = carService.ReadCarById(Id);
            Assert.Equal(car1, actual);
            //Assert.Equal(true, false);
        }

        [Fact]
        public void DeleteById()
        {
            //Validate Delete Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            int Id = 1;
            Car car1 = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "5",
                Color = "Black",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.DeleteCar(Id)).Returns(car1);
            ICarService carService = new CarService(carRepo.Object);
            var actual = carService.Delete(Id);
            Assert.Equal(car1, actual);
        }

        [Fact]
        public void CreateCar_WithMíssingManufacturer_ShouldThrowArgumentException()
        {
            //Validate Create Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            int Id = 1;
            Car car1 = new Car()
            {
                Id = Id,
                Manufacturer = "",
                Model = "5",
                Color = "Black",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.CreateCar(car1)).Returns(car1);
            ICarService carService = new CarService(carRepo.Object);
            Assert.Throws<ArgumentException>((Action)(() => carService.Create(car1)));
        }

        [Fact]
        public void CreateCar_WithTooLongModel_ShouldThrowArgumentException()
        {
            //Validate Create Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            int Id = 1;
            Car car1 = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "",
                Color = "Black",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.CreateCar(car1)).Returns(car1);
            ICarService carService = new CarService(carRepo.Object);
            Assert.Throws<ArgumentException>((Action)(() => carService.Create(car1)));
        }

        [Fact]
        public void CreateCar_WithMíssingColor_ShouldThrowArgumentException()
        {
            //Validate Create Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            int Id = 1;
            Car car1 = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "5",
                Color = "",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.CreateCar(car1)).Returns(car1);
            ICarService carService = new CarService(carRepo.Object);
            Assert.Throws<ArgumentException>((Action)(() => carService.Create(car1)));
        }

        [Fact]
        public void EditCar()
        {
            //Validate Edit Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            int Id = 1;
            Car given = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "5",
                Color = "Black",
                Type = "Family Van",
                Price = 99,
                Fuel = "Diesel",
                Year = 2014,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            
            Car expected = new Car()
            {
                Id = Id,
                Manufacturer = "Mazda",
                Model = "5",
                Color = "White",
                Type = "Family Van",
                Price = 99,
                Fuel = "Black",
                Year = 2016,
                Mileage = 1000,
                Description = "This is not a family car. This... Is.... SPARTA!"
            };
            carRepo.Setup(repo => repo.ReadCarByID(Id)).Returns(given);
            carRepo.Setup(repo => repo.Update(given.Id, given)).Returns(expected);
            ICarService carService = new CarService(carRepo.Object);
            var actual = carService.UpdateCar(given.Id, given);
            Assert.Equal(expected, actual);
        }
    }
}
