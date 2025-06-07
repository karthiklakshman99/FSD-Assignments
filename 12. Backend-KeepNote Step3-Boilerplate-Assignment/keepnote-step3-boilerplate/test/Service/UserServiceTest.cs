using DAL;
using Entities;
using Exceptions;
using Moq;
using Service;
using Xunit;

namespace Test.Service
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class UserServiceTest
    {
        #region positive tests

        [Fact, TestPriority(1)]
        public void RegisterUserShouldReturnUser()
        {
            User user = new User { UserId = 8105847, UserName = "Sam Gomes", Password = "test123", Contact = "9876543210" };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.RegisterUser(user)).Returns(true);
            var service = new UserService(mockRepo.Object);

            var actual = service.RegisterUser(user);

            Assert.True(actual);
        }

        [Fact, TestPriority(2)]
        public void DeleteUserShouldReturnTrue()
        {
            int userId = 8105847;
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(userId)).Returns(new User());
            mockRepo.Setup(repo => repo.DeleteUser(userId)).Returns(true);
            var service = new UserService(mockRepo.Object);

            var actual = service.DeleteUser(userId);

            Assert.True(actual);
        }

        [Fact, TestPriority(4)]
        public void UpdateUserShouldreturnTrue()
        {
            int userId = 8105845;
            User user = new User { UserId = 8105845, UserName = "John Simon", Password = "admin123", Contact = "9812345670" };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(userId)).Returns(user);
            mockRepo.Setup(repo => repo.UpdateUser(user)).Returns(true);
            var service = new UserService(mockRepo.Object);

            var actual = service.UpdateUser(userId,user);

            Assert.True(actual);
        }

        [Fact, TestPriority(3)]
        public void GetUserByIdShouldReturnUser()
        {
            int userId = 8105845;
            User user = new User { UserId = 8105845, UserName = "John Simon", Password = "test123", Contact = "9812345670" };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(userId)).Returns(user);
            var service = new UserService(mockRepo.Object);

            var actual = service.GetUserById(userId);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<User>(actual);
            Assert.Equal("John Simon", actual.UserName);
        }

        #endregion positive tests

        #region negative tests

        [Fact, TestPriority(5)]
        public void RegisterUserShouldThrowException()
        {
            User user = new User { UserId = 8105845, UserName = "John Simon", Password = "test123", Contact = "9812345670" };
            //User _user = null;
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(user.UserId)).Returns(user);
            var service = new UserService(mockRepo.Object);

            var actual = Assert.Throws<UserAlreadyExistException>(() => service.RegisterUser(user));
            Assert.Equal($"This userid: {user.UserId} already exists", actual.Message);

        }

        /*
        [Fact]
        public void DeleteUserShouldThrowException()
        {
            string userId = "Sachin";
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.DeleteUser(userId)).Returns(false);
            var service = new API.Service.UserService(mockRepo.Object);

            var actual = Assert.Throws<UserNotFoundException>(() => service.DeleteUser(userId));

            Assert.Equal("This user id does not exist", actual.Message);
        }
        */
        [Fact, TestPriority(6)]
        public void UpdateUserShouldThrowException()
        {
            int userId = 8105848;
            User user = new User { UserId = 8105848, UserName = "Dinesh", Password = "admin123", Contact = "9892134560"};
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.UpdateUser(user)).Returns(false);
            var service = new UserService(mockRepo.Object);

            var actual = Assert.Throws<UserNotFoundException>(() => service.UpdateUser(userId, user));

            Assert.Equal($"User with id: {userId} does not exist", actual.Message);
        }

        [Fact, TestPriority(7)]
        public void GetUserByIdShouldThrowException()
        {
            int userId = 8105849;
            User user = null;
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(userId)).Returns(user);
            var service = new UserService(mockRepo.Object);

            var actual = Assert.Throws<UserNotFoundException>(() => service.GetUserById(userId));

            Assert.Equal($"User with id: {userId} does not exist", actual.Message);
        }


        #endregion negative tests
    }
}
