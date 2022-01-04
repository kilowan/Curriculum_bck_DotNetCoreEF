using curriculum.Models;

namespace curriculum.Data
{
    public interface ITrainingData
    {
        public bool AddTraining(TrainingDto training);
        public bool UpdateTraining(TrainingDto training, int trainingId);
    }
}
