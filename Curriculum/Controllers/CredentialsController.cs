using curriculum.Business;
using curriculum.Models.Employee;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Credentials")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly ICredentialsBz credentialsBz;
        public CredentialsController(ICredentialsBz credentialsBz)
        {
            this.credentialsBz = credentialsBz;
        }

        [HttpGet("{username}/{password}")]
        public string Login(string username, string password)
        {
            try
            {
                return credentialsBz.Login(username, password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{username}")]
        public bool CheckUsername(string username)
        {
            try
            {
                return credentialsBz.CheckUsername(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut("{code}")]
        public bool UpdateCredentials(CredentialsDto credentials, string code)
        {
            try
            {
                return credentialsBz.UpdatePassword(credentials, code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
