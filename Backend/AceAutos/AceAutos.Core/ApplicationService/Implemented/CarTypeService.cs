using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AceAutos.Core.ApplicationService.Implemented
{
    public class CarTypeService : ICarTypeService
    {
        private ICarTypeRepository _carTypeRepo;

        public CarTypeService(ICarTypeRepository carTypeRepo)
        {
            _carTypeRepo = carTypeRepo;
        }

        public CarType CreateCarType(CarType carType)
        {
            return _carTypeRepo.Create(carType);
        }

        public IEnumerable<CarType> GetAllCarTypes()
        {
            return _carTypeRepo.ReadAllCarTypes();
        }

        public IEnumerable<CarType> GetFilteredCarType(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _carTypeRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }

            return _carTypeRepo.ReadAllCarTypes(filter);
        }

        public CarType GetCarTypeWithId(int id)
        {
            return _carTypeRepo.ReadyById(id);
        }

        public CarType RemoveCarType(int id)
        {
            return _carTypeRepo.DeleteCarType(id);
        }

        public CarType UpdateCarType(CarType carTypeToUpdate)
        {
            var carType = GetCarTypeWithId(carTypeToUpdate.Id);
            carType.Name = carTypeToUpdate.Name;
            _carTypeRepo.UpdateCarTypeInDB(carType);
            return carType;
        }
    }
}
