using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceAutos.Core.ApplicationService;
using AceAutos.Core.DomainService;
using AceAutos.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetShopApplication.Core.Entities;

namespace WebAPI.Controllers
{
    [Route("/token")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
 
        }

        [HttpPost]
        public IActionResult Login([FromBody] JObject data)
        {
            try
            {
                var validatedUser = _userService.ValidateUser(new Tuple<string, string>(data["username"].ToString(), data["password"].ToString()));

                return Ok(new
                {
                    Token = validatedUser
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }

}
