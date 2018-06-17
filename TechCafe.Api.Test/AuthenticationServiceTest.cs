using Microsoft.EntityFrameworkCore;
using TechCafe.Repository;
using TechCafe.Repository.Entities;
using Xunit;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using FakeItEasy;
using TechCafe.Api.Services;

namespace TechCafe.Api.Test
{
    public class AuthenticationServiceTest : BaseTest
    {
        private IConfiguration config;

        private TechCafeDbContext dbContext;

        private IPasswordHasher<User> passwordHasher;

        private IMapper mapper;

        public AuthenticationServiceTest()
        {
            config = A.Fake<IConfiguration>();
            passwordHasher = new PasswordHasher<User>();
            mapper = Mapper.Instance;

            var options = new DbContextOptionsBuilder<TechCafeDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            dbContext = new TechCafeDbContext(options);
        }

        [Fact]
        public void Authenticate_Success()
        {
            var user = new User { Username = "test" };
            var hashedPassword = passwordHasher.HashPassword(user, "test");
            dbContext.Set<User>().Add(new User { Id = 1, Username = "test", Password = hashedPassword });
            dbContext.SaveChanges();

            var authenticateService = new AuthenticationService(config,dbContext, mapper,passwordHasher);
            var model = authenticateService.Authenticate("test", "test");
            Assert.NotNull(model);
        }
    }
}
