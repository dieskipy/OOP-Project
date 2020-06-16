using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLearning.LearningObject
{
    abstract public class Accessory: PersonalService
    {
        public LessonTypeEl LesType { get; set; }
    }
}
