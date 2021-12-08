using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Models
{
    public class Language
    {
        public string name { get; set; }
        public string level { get; set; }
        public Language(Data.Models.Language language)
        {
            name = language.name;
            level = language.level.name;
        }
    }
}
