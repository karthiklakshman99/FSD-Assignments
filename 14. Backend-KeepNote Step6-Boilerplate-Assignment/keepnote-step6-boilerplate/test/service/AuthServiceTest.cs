﻿using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using InfraSetup;
using Microsoft.AspNetCore.Authentication;
using Moq;
using Test;
using UserService.Models;
using Xunit;

namespace ServiceTest
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class AuthServiceTest
    {
        [Fact, TestPriority(1)]
        public void RegisterUserShouldSuccess()
        {
            var mockRepo = new Mock<IAuthRepository>();
            var user = new AuthenticationService.Models.User("Sachin", "admin123") { UserId = "Sachin", Password = "admin123" };
            mockRepo.Setup(repo => repo.IsUserExists(user.UserId)).Returns(false);
            mockRepo.Setup(repo => repo.CreateUser(user)).Returns(true);
            var service = new AuthenticationService.Service.AuthService(mockRepo.Object);

            var actual = service.RegisterUser(user);
            Assert.True(actual);
        }

        [Fact, TestPriority(2)]
        public void LoginUserShouldSuccess()
        {
            var mockRepo = new Mock<IAuthRepository>();
            var user = new AuthenticationService.Models.User("Sachin", "admin123") { UserId = "Sachin", Password = "admin123" };
            mockRepo.Setup(repo => repo.LoginUser(user)).Returns(true);
            var service = new AuthenticationService.Service.AuthService(mockRepo.Object);

            var actual = service.LoginUser(user);
            Assert.True(actual);
        }

        [Fact, TestPriority(3)]
        public void RegisterUserShouldFail()
        {
            var mockRepo = new Mock<IAuthRepository>();
            var user = new AuthenticationService.Models.User("Mukesh", "admin123") { UserId = "Mukesh", Password = "admin123" };
            mockRepo.Setup(repo => repo.IsUserExists(user.UserId)).Returns(true);
            var service = new AuthenticationService.Service.AuthService(mockRepo.Object);

            var actual = Assert.Throws<UserAlreadyExistsException>(() => service.RegisterUser(user));
            Assert.Equal($"This userId {user.UserId} already in use", actual.Message);
        }
    }
}
