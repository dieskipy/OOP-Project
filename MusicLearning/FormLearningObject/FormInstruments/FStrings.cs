using MusicLearning.Attributes;
using MusicLearning.FormLearningObject;
using MusicLearning.InstrumentElements;
using MusicLearning.LearningObject.Instruments;
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
    [Suitable((new Type[] { typeof(Strings) }))]
    public partial class FStrings : FInstrument
    {
        private Strings FinalStrings = null;
        public FStrings()
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(StringsType));
        }

        public FStrings(object myObject, bool readOnly)
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(StringsType));
            SetStrings((Strings)myObject);
            if (readOnly)
            {
                SetReadOnly();
                ReceivedTeacher.ReadOnly = true;
            }
        }

        public void SetStrings(Strings instrument)
        {
            FinalStrings = instrument;
            SetCourseName(instrument.CourseName);
            SetDate(instrument.Data);
            SetProffessionalLevel(instrument.ProfLevel);
            SetLessonType(instrument.StringsName);
            SetTeacherNameFunction(instrument.TeacherInfo.Name);
            SetTeacherExpirienceFunction(instrument.TeacherInfo.Experience);
        }

        public void GetStrings(Strings instrument)
        {
            instrument.CourseName = GetCourseName();
            instrument.Data = GetDate();
            instrument.ProfLevel = GetProffessionalLevel();
            instrument.StringsName = GetLessonType();
            Teacher teacher = new Teacher(GetTeacherNameFunction(), GetTeacherExpirienceFunction());
            instrument.TeacherInfo = teacher;
        }

        public void SetLessonType(StringsEl level)
        {

            cbInstrument.SelectedIndex = (int)level.Strings;
        }

        public StringsEl GetLessonType()
        {
            StringsType type = (StringsType)cbInstrument.SelectedIndex;
            StringsEl level = new StringsEl(type);
            return level;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FinalStrings == null)
            {
                Strings instr = new Strings();
                GetStrings(instr);
                MainForm.AddObject(instr);
            }
            else
                GetStrings(FinalStrings);
            Close();
        }
    }
}
