using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusicLearning.InstrumentElements
{
    public enum WindType
    {
        [Description("Кларнет")]
        clarinet,
        [Description("Саксофон")]
        saxophone,
        [Description("Гобой")]
        oboe,
        [Description("Флейта")]
        fluet,
        [Description("Валторна")]
        frhorn,
        [Description("Труба")]
        trumpet,
        [Description("Туба")]
        tuba
    }
    public class WindEl
    {
        public WindType Wind { get; set; } = WindType.clarinet;
        public WindEl(WindType type)
        {
            Wind = type;
        }
    }
}
