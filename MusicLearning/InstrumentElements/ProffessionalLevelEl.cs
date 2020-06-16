using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusicLearning.InstrumentElements
{
    public enum ProfType
    {
        [Description("Новичок")]
        beginner,
        [Description("Любитель")]
        amateur,
        [Description("Продвинутый")]
        advanced,
        [Description("Профессионал")]
        professional
    }
    public class ProffessionalLevelEl
    {
        public ProfType Prof { get; set; } = ProfType.beginner;
        public ProffessionalLevelEl(ProfType type)
        {
            Prof = type;
        }
    }
}
