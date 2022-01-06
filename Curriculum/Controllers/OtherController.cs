using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/OtherData")]
    [ApiController]
    public class OtherController : Controller
    {
        private readonly IOtherBz otherBz;
        public OtherController(IOtherBz otherBz)
        {
            this.otherBz = otherBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddOtherData(OtherDataDto otherData)
        {
            try
            {
                return otherBz.AddOtherData(otherData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{otherDataId}")]
        [Authorize]
        public bool UpdateOtherData(OtherDataDto otherData, int otherDataId)
        {
            try
            {
                return otherBz.UpdateOtherData(otherData, otherDataId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{otherDataId}")]
        [Authorize]
        public bool DeleteOtherData(int otherDataId)
        {
            try
            {
                return otherBz.DeleteOtherData(otherDataId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
