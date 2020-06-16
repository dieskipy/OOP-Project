using MusicLearning.Attributes;
using MusicLearning.FormLearningObject;
using MusicLearning.InstrumentElements;
using MusicLearning.FormInstrumentElements;
using MusicLearning.LearningObject.Instruments;
using MusicLearning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicLearning.FormLearningObjects.FormInstruments
{
    [Suitable((new Type[] { typeof(Wind) }))]
    public partial class FWind : FInstrument
    {
        private Wind FinalWind = null;
        public FWind()
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(WindType));
        }
        public FWind(object myObject, bool readOnly)
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(WindType));
            SetWind((Wind)myObject);
            if (readOnly)
            {
                SetReadOnly();
                ReceivedTeacher.ReadOnly = true;
            }
        }


        public void SetWind(Wind instrument)
        {
            FinalWind = instrument;
            SetCourseName(instrument.CourseName);
            SetDate(instrument.Data);
            SetProffessionalLevel(instrument.ProfLevel);
            SetLessonType(instrument.WindName);
            SetTeacherNameFunction(instrument.TeacherInfo.Name);
            SetTeacherExpirienceFunction(instrument.TeacherInfo.Experience);
        }

        public void GetWind(Wind instrument)
        {
            instrument.CourseName = GetCourseName();
            instrument.Data = GetDate();
            instrument.ProfLevel = GetProffessionalLevel();
            instrument.WindName = GetLessonType();
            Teacher teacher = new Teacher(GetTeacherNameFunction(), GetTeacherExpirienceFunction());
            instrument.TeacherInfo = teacher;
        }

        public void SetLessonType(WindEl level)
        {

            cbInstrument.SelectedIndex = (int)level.Wind;
        }

        public WindEl GetLessonType()
        {
            WindType type = (WindType)cbInstrument.SelectedIndex;
            WindEl level = new WindEl(type);
            return level;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FinalWind == null)
            {
                Wind instr = new Wind();
                GetWind(instr);
                MainForm.AddObject(instr);
            }
            else
                GetWind(FinalWind);
            Close();
        }
    }
}
