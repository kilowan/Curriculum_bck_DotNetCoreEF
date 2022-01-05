using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Value")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IValueBz valueBz;
        public ValueController(IValueBz valueBz)
        {
            this.valueBz = valueBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddValue(ValueDto value)
        {
            try
            {
                return valueBz.AddValue(value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
