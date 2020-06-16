using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusicLearning.InstrumentElements
{
    public enum StringsType
    {
        [Description("Скрипка")]
        violin,
        [Description("Альт")]
        viola,
        [Description("Виолончель")]
        cello,
        [Description("Контрабас")]
        contrabass,
        [Description("Гитара")]
        guitar,
        [Description("Укулеле")]
        ukulele,
        [Description("Арфа")]
        harp
    }
    public class StringsEl
    {
        public StringsType Strings { get; set; } = StringsType.violin;
        public StringsEl(StringsType type)
        {
            Strings = type;
        }
    }
}
