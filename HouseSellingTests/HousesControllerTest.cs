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
        readonly Mock<IHousesRepositore> mockHouses = new();

        [Fact]
        public void GetWhithNotCorrectResult()
        { 
            mockHouses.Setup(f => f.GetAllHousesAsync()).ReturnsAsync(new List<House>
            {
                new House { Id = 1, Description = "lalala"}
            });
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result.Result.Result);
        }
        [Fact]
        public void GetWhithNotFoundException()
        {
            mockHouses.Setup(f => f.GetAllHousesAsync()).Throws(new NotFoundException());
            var controller = new HousesController(mockHouses.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result.Result);
        }
    }
}
