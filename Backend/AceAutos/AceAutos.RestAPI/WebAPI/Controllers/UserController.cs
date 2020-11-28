using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceAutos.Core.DomainService;
using AceAutos.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Core.Entities;

namespace WebAPI.Controllers
{
    [Route("/token")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthenticationHelper _authenHelper;

        public UserController(IUserRepository userRepo, IAuthenticationHelper authenHelper)
        {
            _userRepo = userRepo;
            _authenHelper = authenHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Username == model.Username);
            // check if username exists
            if (user == null)
                return Unauthorized();

            if (!_authenHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = _authenHelper.GenerateToken(user)
            });
        }


    }

}
