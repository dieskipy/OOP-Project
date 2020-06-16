using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusicLearning.InstrumentElements
{
    public enum InstrGroup
    {
        [Description("Духовые")]
        wind,
        [Description("Струнные")]
        strings,
        [Description("Клавишные")]
        keyboard
    }
    public class InstrumentAcccessoriesEl
    {
        public InstrGroup Group { get; set; } = InstrGroup.wind;
        public InstrumentAcccessoriesEl(InstrGroup type)
        {
            Group = type;
        }

    }
}
