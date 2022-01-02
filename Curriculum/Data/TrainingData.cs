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
                IList<SubContent> subs = new List<SubContent>();
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
    }
}
