using curriculum.Models;

namespace curriculum.Business
{
    public interface ITrainingBz
    {
        public bool AddTraining(TrainingDto training);
        public bool UpdateTraining(TrainingDto training, int trainingId);
    }
}
