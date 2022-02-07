﻿using HouseSellingBaseRedactionApi.Controllers;
using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HouseSellingTests
{
    public class UsersControllerTest
    {
        private readonly Mock<IUsersRepositore> mockUsers = new();

        [Fact]
        public void GetWhithCorrectResult()
        {
            mockUsers.Setup(f => f.GetAllUsersAsync()).ReturnsAsync(new List<User>
            {
                new User { Id = 1, Name = "lalala"}
            });
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Get();

            var objectResult = Assert.IsType<ObjectResult>(result.Result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(objectResult.Value);
            Assert.NotEmpty(model);
        }
        [Fact]
        public void GetWhithCorrectResultAndInputInt()
        {
            mockUsers.Setup(f => f.GetUserByIdAsync(1)).ReturnsAsync(new User
            {
                Id = 1,
                Name = "lalala"
            });
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Get(1);

            var objectResult = Assert.IsType<ObjectResult>(result.Result.Result);
            var model = Assert.IsAssignableFrom<User>(objectResult.Value);
            Assert.NotNull(model);
        }
        [Fact]
        public void GetWhithNotFoundException()
        {
            mockUsers.Setup(f => f.GetAllUsersAsync()).Throws(new NotFoundException());
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result.Result);
        }
        [Fact]
        public void GetWhithNotFoundExceptionAndInputInt()
        {
            mockUsers.Setup(f => f.GetUserByIdAsync(1)).Throws(new NotFoundException());
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Get(1);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result.Result);
        }

        [Fact]
        public void AddWhithCorrectInput()
        {
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Add(new User());

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }

        [Fact]
        public void PutWhithCorrectInput()
        {
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Put(new User());

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void SetAdminRoleWhithCorrectInput()
        {
            User user = new()
            {
                Id = 1,
                Name = "Lalaal"
            };

            mockUsers.Setup(f => f.GetUserByIdAsync(1)).ReturnsAsync(user);
            var controller = new UsersController(mockUsers.Object);

            var result = controller.SetAdminRole(1);

            Assert.NotNull(result);
            Assert.Equal("admin", user.Role);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void SetAdminRoleWhithNotFoundException()
        {
            User user = new()
            {
                Id = 1,
                Name = "Lalaal"
            };

            mockUsers.Setup(f => f.GetUserByIdAsync(1)).Throws(new NotFoundException());
            var controller = new UsersController(mockUsers.Object);

            var result = controller.SetAdminRole(1);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteWhithCorrectInput()
        {
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Delete(1);

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public void DeleteWhithNotFoundException()
        {
            mockUsers.Setup(f => f.RemoveUserAsync(1)).Throws(new NotFoundException());
            var controller = new UsersController(mockUsers.Object);

            var result = controller.Delete(1);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}