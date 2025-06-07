using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Test.InfraSetup
{
    public class AuthDbFixture : IDisposable
    {
        public AuthDbContext context;

        public AuthDbFixture()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(databaseName: "AuthDB")
                .Options;

            //Initializing DbContext with InMemory
            context = new AuthDbContext(options);

            // Insert seed data into the database using one instance of the context
            context.Users.Add(new AuthenticationService.Models.User("Mukesh","admin123") { UserId = "Mukesh", Password = "admin123" });
            context.SaveChanges();
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
