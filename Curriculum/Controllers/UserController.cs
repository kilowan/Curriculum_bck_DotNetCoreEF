using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBz userBz;
        public UserController(IUserBz userBz)
        {
            this.userBz = userBz;
        }

        [HttpGet("{username}")]
        [Authorize]
        public User GetUserByUsername(string username)
        {
            try
            {
                return userBz.GetUserByUsername(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
