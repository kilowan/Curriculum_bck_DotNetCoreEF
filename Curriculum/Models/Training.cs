using curriculum.Data.Models;
using System;
using System.Collections.Generic;

namespace curriculum.Models
{
    public class Training
    {
        public int id { get; set; }
        public string name { get; set; }
        public TrainingType type { get; set; }
        public string place { get; set; }
        public DateTime? initDatetime { get; set; }
        public DateTime? finishDateTime { get; set; }
        public DateTime? graduationDate { get; set; }
        public IList<Content> contents { get; set; }

        public Training(Data.Models.Training training)
        {
            id = training.id;
            name = training.name;
            type = training.type;
            place = training.place;
            initDatetime = training.initDatetime;
            finishDateTime = training.finishDateTime;
            graduationDate = training.graduationDate;
            contents = new List<Content>();
            foreach (Data.Models.Content cont in training.contents)
            {
                contents.Add(new Content(cont));
            }
        }
    }
}
