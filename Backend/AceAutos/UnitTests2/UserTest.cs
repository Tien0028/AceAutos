using AceAutos.Core.ApplicationService;
using AceAutos.Core.ApplicationService.Implemented;
using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using AceAutos.Infrastructure.Data.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests2
{
    public class UserTest
    {
        [Theory]
        [InlineData("UserJohn", "UserJohn")] //Incorrect Password
        [InlineData("5678", "5678")] //Incorrect Username
        public void ValidateUser(string name, string password)
        {

            Mock<IUserRepository> userRepo = new Mock<IUserRepository>();

            Byte[] secretBytes = new byte[40];
            Random rand = new Random(); // Random is a random number generator, which produces a sequence of numbers
            rand.NextBytes(secretBytes); // Here, the specificed Array is filled with random numbers

            IAuthenticationHelper authenService = new AuthenticationHelper(secretBytes);

            //string password = "5678";
            byte[] passwordHashJohn, passwordSaltJohn;

            authenService.CreatePasswordHash("5678", out passwordHashJohn, out passwordSaltJohn);

            User user = new User()
            {
                Username = "UserJohn",
                PasswordHash = passwordHashJohn,
                PasswordSalt = passwordSaltJohn,
                IsAdmin = true
            };

            userRepo.Setup(repo => repo.GetUserByUsername(user.Username)).Returns(user);

            IUserService userService = new UserService(userRepo.Object, authenService);


            Assert.Throws<ArgumentException>((Action)(() => userService.ValidateUser(new Tuple<string, string>(name, password))));

        }
    }
}
