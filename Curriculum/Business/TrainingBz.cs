using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class TrainingBz : ITrainingBz
    {
        private readonly ITrainingData trainingData;
        public TrainingBz(ITrainingData trainingData)
        {
            this.trainingData = trainingData;
        }

        public bool AddTraining(TrainingDto training)
        {
            try
            {
                return trainingData.AddTraining(training);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
