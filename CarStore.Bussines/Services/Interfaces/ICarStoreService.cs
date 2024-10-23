using CarStore.Domain.Models;

namespace CarStore.Bussines.Services.Interfaces
{
    public interface ICarStoreService
    {
        public Task<IEnumerable<CarModel>> GetCars();
        public Task<CarModel> GetCarById(int id);
    }
}
