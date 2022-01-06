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
        public bool UpdateTraining(TrainingDto training, int trainingId)
        {
            try
            {
                return trainingData.UpdateTraining(training, trainingId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteTraining(int trainingId)
        {
            try
            {
                return trainingData.DeleteTraining(trainingId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
