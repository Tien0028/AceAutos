using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceAutos.Core.ApplicationService;
using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using AceAutos.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetShopApplication.Core.Entities;

namespace WebAPI.Controllers
{
    [Route("api/token")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepo;

        public UserController(IUserService userService, IUserRepository userRepo)
        {
            _userService = userService;
            _userRepo = userRepo;
        }


        [HttpPost]
        public IActionResult Login([FromBody] JObject data)
        {
            try
            {
                var validatedUser = _userService.ValidateUser(new Tuple<string, string>(data["username"].ToString(), data["password"].ToString()));

                return Ok(new
                {
                    username = data["username"].ToString(),
                    token = validatedUser
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GET: api/User
        [Authorize(Roles = "Adminstrator")]
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAllUsers();
        }

        // DELETE api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        //PUT: api/User/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            
            try
            {
                if(id != user.Id)
                {
                    return BadRequest("Parameter ID and user ID have to be the same");
                }
                return Ok(_userService.EditUser(id, user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
