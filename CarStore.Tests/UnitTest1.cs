using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CarStore.Api.Controllers;
using CarStore.Bussines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CarStore.Domain.Models;

namespace CarStore.Tests.Controllers
{
    [TestClass]
    public class CarStoreControllerTests
    {
        private Mock<ICarStoreService> _mockCarStoreService;
        private CarStoreController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockCarStoreService = new Mock<ICarStoreService>();
            _controller = new CarStoreController(_mockCarStoreService.Object);
        }

        [TestMethod]
        public async Task GetAllCars_ReturnsOkResult_WithListOfCars()
        {
            // Arrange
            var cars = new List<CarModel>
            {
                new CarModel { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red", Price = 20000 },
                new CarModel { Id = 2, Make = "Honda", Model = "Civic", Year = 2019, Color = "Blue", Price = 18000 }
            };
            _mockCarStoreService.Setup(service => service.GetCars()).ReturnsAsync(cars);

            // Act
            var result = await _controller.GetAllCars();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(cars, okResult.Value);
        }

        [TestMethod]
        public async Task GetCarById_ReturnsOkResult_WithCar()
        {
            // Arrange
            var car = new CarModel { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red", Price = 20000 };
            _mockCarStoreService.Setup(service => service.GetCarById(1)).ReturnsAsync(car);

            // Act
            var result = await _controller.GetCarById(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(car, okResult.Value);
        }
    }
}
