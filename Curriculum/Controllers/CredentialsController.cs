using curriculum.Business;
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
        public bool Details(string username, string password)
        {
            try
            {
                return credentialsBz.CheckCredentials(username, password);
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
    }
}
