using CarStore.Bussines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarStoreController : ControllerBase
    {
        private readonly ICarStoreService _carStoreService;
        public CarStoreController(ICarStoreService carStoreService)
        {
            _carStoreService = carStoreService;
        }   

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carStoreService.GetCars();
            return Ok(cars);    
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carStoreService.GetCarById(id);
            return Ok(car);
        }
    }
}
