using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLearning.InstrumentElements
{
    public class Teacher
    {
        public string Name { set; get; } = "Не указано";
        public string Experience { set; get; } = "Не указано";
        public Teacher(string name, string experience)
        {
            this.Name = name;
            this.Experience = experience;
        }
        public Teacher() { }
    }
}
