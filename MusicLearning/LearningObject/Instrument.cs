using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLearning.InstrumentElements;

namespace MusicLearning.LearningObject
{
    abstract public class Instrument: PersonalService
    {
        public ProffessionalLevelEl ProfLevel { get; set; }
    }
}
