using DAL;
using Entities;
using Xunit;

namespace Test.Repository
{
    [Collection("Database collection")]
    [TestCaseOrderer("Test.PriorityOrderer","Test")]
    public class UserRepositoryTest
    {
        UserRepository repository;
        public UserRepositoryTest(DatabaseFixture fixture)
        {
            repository = new UserRepository(fixture.context);
        }

        [Fact, TestPriority(4)]
        public void RegisterUserShouldSuccess()
        {
            User user = new User {UserId=8105847, UserName="Sam Gomes", Password="test123", Contact="9876543210" };

            var actual = repository.RegisterUser(user);
            Assert.True(actual);
        }
        [Fact, TestPriority(5)]
        public void DeleteUserShouldSuccess()
        {
            int userId = 8105845;

            var actual = repository.DeleteUser(userId);
            Assert.True(actual);
        }

        [Fact,TestPriority(3)]
        public void UpdateUserShouldSuccess()
        {
            var user = repository.GetUserById(8105845);
            user.Password = "admin123";

            var actual = repository.UpdateUser(user);
            Assert.True(actual);
        }

        [Fact, TestPriority(2)]
        public void GetUserByIdShouldSuccess()
        {
            var user = repository.GetUserById(8105845);

            Assert.IsAssignableFrom<User>(user);
            Assert.Equal("John Simon", user.UserName);
        }

        [Fact, TestPriority(1)]
        public void ValidateUserShouldSuccess()
        {
            int userId = 8105845;
            string password = "test123";
            var actual = repository.ValidateUser(userId,password);

            Assert.True(actual);
        }
    }
}
