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
    [Suitable((new Type[] { typeof(Keyboard) }))]
    public partial class FKeyboard : FInstrument

    {
        private Keyboard FinalKeyboard = null;
        public FKeyboard()
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(KeyboardType));
        }
        public FKeyboard(object myObject, bool readOnly)
        {
            InitializeComponent();
            SetComboBoxes(cbInstrument, typeof(KeyboardType));
            SetKeyboard((Keyboard)myObject);
            if (readOnly)
            {
                SetReadOnly();
                ReceivedTeacher.ReadOnly = true;
            }
        }

        public void SetKeyboard(Keyboard instrument)
        {
            FinalKeyboard = instrument;
            SetCourseName(instrument.CourseName);
            SetDate(instrument.Data);
            SetProffessionalLevel(instrument.ProfLevel);
            SetLessonType(instrument.KeyboardName);
            SetTeacherNameFunction(instrument.TeacherInfo.Name);
            SetTeacherExpirienceFunction(instrument.TeacherInfo.Experience);
        }

        public void GetKeyboard(Keyboard instrument)
        {
            instrument.CourseName = GetCourseName();
            instrument.Data = GetDate();
            instrument.ProfLevel = GetProffessionalLevel();
            instrument.KeyboardName = GetLessonType();
            Teacher teacher = new Teacher(GetTeacherNameFunction(), GetTeacherExpirienceFunction());
            instrument.TeacherInfo = teacher;
        }

        public void SetLessonType(KeyboardEl level)
        {

            cbInstrument.SelectedIndex = (int)level.Keyboard;
        }

        public KeyboardEl GetLessonType()
        {
            KeyboardType type = (KeyboardType)cbInstrument.SelectedIndex;
            KeyboardEl level = new KeyboardEl(type);
            return level;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FinalKeyboard == null)
            {
                Keyboard instr = new Keyboard();
                GetKeyboard(instr);
                MainForm.AddObject(instr);
            }
            else
                GetKeyboard(FinalKeyboard);
            Close();
        }
    }
}
