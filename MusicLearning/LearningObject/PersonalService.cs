using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLearning.LearningObject
{
    abstract public class PersonalService
    {
        public string CourseName { get; set; }
        public Teacher TeacherInfo { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
