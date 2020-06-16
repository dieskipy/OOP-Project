using MusicLearning.Attributes;
using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicLearning.LearningObject.Instruments
{
    [ProductType("Струнные инструменты")]
    public class Strings:Instrument
    {
        public StringsEl StringsName { set; get; }

        public Strings()
        {
            TeacherInfo = new Teacher();
        }
    }
}
