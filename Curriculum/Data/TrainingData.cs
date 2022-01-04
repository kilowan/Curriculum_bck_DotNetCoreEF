using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curriculum.Data
{
    public class TrainingData : ITrainingData
    {
        private readonly CurriculumContext _context;
        public TrainingData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddTraining(TrainingDto training)
        {
            try
            {
                bool result = false;
                int lastId = _context.Trainings
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;

                _context.Trainings.AddRange(new Models.Training() 
                { 
                    id = lastId,
                    curriculumId = training.curriculumId,
                    name = training.name,
                    place = training.place,
                    graduationDate = training.graduationDate,
                    initDatetime = training.initDateTime,
                    finishDateTime = training.finishDateTime,
                    type = training.type
                });
                if (_context.SaveChanges() == 1) result = true;

                return result;

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
                bool result = false;
                Models.Training tr = _context.Trainings
                    .Where(tr => tr.id == trainingId)
                    .FirstOrDefault();
                tr.name = !string.IsNullOrEmpty(training.name) ? training.name : null;
                tr.place = !string.IsNullOrEmpty(training.place) ? training.place : null;
                tr.graduationDate = training.graduationDate;
                tr.initDatetime = training.initDateTime;
                tr.finishDateTime = training.finishDateTime;
                _context.Trainings.Update(tr);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
