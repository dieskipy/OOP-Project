﻿using MusicLearning.Attributes;
using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicLearning.LearningObject.Instruments
{
    [ProductType("Духовые инструменты")]
    public class Wind:Instrument
    {
        public WindEl WindName { set; get; }

        public Wind()
        {
            TeacherInfo = new Teacher();
        }
    }
}
