using CarStore.Bussines.Services.Interfaces;
using CarStore.Domain.Models;
using CarStore.DataAccess;
using AutoMapper;

namespace CarStore.Bussines.Services.Implementations
{
    public class CarStoreService : ICarStoreService
    {
        private readonly CarStoreDbContext _carStoreDbContext;
        private readonly IMapper _mapper;
        public CarStoreService(CarStoreDbContext carStoreDbContext, IMapper mapper)
        {
            _carStoreDbContext = carStoreDbContext;
            _mapper = mapper;
        }

        public async Task<CarModel> GetCarById(int id)
        {
            var car = _carStoreDbContext.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                var carModel = _mapper.Map<CarModel>(car);
                return await Task.FromResult(carModel);
            }

            return new CarModel();
        }

        public Task<IEnumerable<CarModel>> GetCars()
        {
            var cars = _carStoreDbContext.Cars.ToList();
            var carModels = _mapper.Map<IEnumerable<CarModel>>(cars);
            return Task.FromResult(carModels);
        }
    }
}
