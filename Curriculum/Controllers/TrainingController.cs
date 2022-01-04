using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingController : Controller
    {
        private readonly ITrainingBz trainingBz;
        public TrainingController(ITrainingBz trainingBz)
        {
            this.trainingBz = trainingBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddTraining(TrainingDto training)
        {
            try
            {
                return trainingBz.AddTraining(training);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut("{trainingId}")]
        [Authorize]
        public bool UpdateTraining(TrainingDto training, int trainingId)
        {
            try
            {
                return trainingBz.UpdateTraining(training, trainingId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
