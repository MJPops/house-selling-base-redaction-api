using HouseSellingBaseRedactionApi.Controllers;
using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HouseSellingTests
{
    public class HousesControllerTest
    {
        private readonly Mock<IHousesRepositore> mockHouses = new();

        [Fact]
        public void GetWithCorrectResult()
        {
            mockHouses.Setup(f => f.GetAllHousesAsync()).ReturnsAsync(new List<House>
            {
                new House { Id = 1, Description = "lalala"}
            });
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get();

            var objectResult = Assert.IsType<ObjectResult>(result.Result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<House>>(objectResult.Value);
            Assert.NotEmpty(model);
        }
        [Fact]
        public void GetWithCorrectResultAndInputInt()
        {
            mockHouses.Setup(f => f.GetHouseByIdAsync(1)).ReturnsAsync(new House
            {
                Id = 1,
                Description = "lalala"
            });
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get(1);

            var objectResult = Assert.IsType<ObjectResult>(result.Result.Result);
            var model = Assert.IsAssignableFrom<House>(objectResult.Value);
            Assert.NotNull(model);
        }
        [Fact]
        public void GetWithNotFoundException()
        {
            mockHouses.Setup(f => f.GetAllHousesAsync()).Throws(new NotFoundException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result.Result);
        }
        [Fact]
        public void GetWithNotFoundExceptionAndInputInt()
        {
            mockHouses.Setup(f => f.GetHouseByIdAsync(1)).Throws(new NotFoundException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get(1);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result.Result);
        }

        [Fact]
        public void AddWithCorrectInput()
        {
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Add(new House());

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void AddWithAlreadyContainsException()
        {
            House house = new()
            {
                Id = 1,
                Description = "Lalaal"
            };

            mockHouses.Setup(f => f.AddNewHouseAsync(house)).Throws(new AlreadyContainsException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Add(house);

            Assert.NotNull(result);
            Assert.IsType<ConflictObjectResult>(result.Result);
        }

        [Fact]
        public void PutWithCorrectInput()
        {
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Put(new House());

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void PutWithNotFoundException()
        {
            House house = new()
            {
                Id = 1,
                Description = "Lalaal"
            };

            mockHouses.Setup(f => f.UpdateHouseAsync(house)).Throws(new NotFoundException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Put(house);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteWithCorrectInput()
        {
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Delete(1);

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void DeleteWithNotFoundException()
        {
            mockHouses.Setup(f => f.RemoveHouseAsync(1)).Throws(new NotFoundException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Delete(1);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
