using MusicLearning.Attributes;
using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicLearning.LearningObject.Accessories
{

    [ProductType("Инструментальные аксессуары")]
    public class InstrumentAccessories:Accessory
    {
        public InstrumentAcccessoriesEl InstrAcGroup { set; get; }
        public InstrumentAccessories()
        {
            TeacherInfo = new Teacher();
        }
    }
}
