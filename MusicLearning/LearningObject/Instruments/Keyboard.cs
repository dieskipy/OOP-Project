using MusicLearning.Attributes;
using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicLearning.LearningObject.Instruments
{
    [ProductType("Клавишные инструменты")]
    public class Keyboard:Instrument
    {
        public KeyboardEl KeyboardName { set; get; }

        public Keyboard()
        {
            TeacherInfo = new Teacher();
        }
    }
}
