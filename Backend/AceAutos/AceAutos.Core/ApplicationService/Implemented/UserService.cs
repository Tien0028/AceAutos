using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using AceAutos.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AceAutos.Core.ApplicationService.Implemented
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthenticationHelper _authentication;

        public UserService(IUserRepository userRepo, IAuthenticationHelper auth)
        {
            _userRepo = userRepo;
            _authentication = auth;
        }

        public String ValidateUser(Tuple<string, string> attemptToLogin)
        {
            //Checks if the user is valid, first, otherwise it's gonna return invalid and checks the first item, which is the username.
            var user = CheckForValidUser(attemptToLogin.Item1);

            //Next, if there's no verified hashed password, it's gonna throw an exception.
            if (!_authentication.VerifyPasswordHash(attemptToLogin.Item2, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid password");
            }

            var claims = SetUpClaims(user);

            //Generate refresh token and save it for user.

            return _authentication.GenerateToken(claims);
        }

        private List<Claim> SetUpClaims(User user)
        {
            //Generate claims for token
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };

            if (user.IsAdmin) claims.Add(new Claim(ClaimTypes.Role, "Administrator")); //Uses if-else to add a role to a claim, depending on the role of the user.
            else claims.Add(new Claim(ClaimTypes.Role, "User"));

            return claims;
        }

        private User CheckForValidUser(String username)
        {
            //Method made and used to check if the user is valid.
            var user = _userRepo.GetUserByUsername(username);

            if (user == null)
            {
                throw new ArgumentException("Invalid User");
            }

            return user;
        }

        public User DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }

        public User EditUser(int id, User user)
        {
            return _userRepo.Edit(id, user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
    }
}
