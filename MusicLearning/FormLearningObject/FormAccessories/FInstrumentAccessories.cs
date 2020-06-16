using MusicLearning.Attributes;
using MusicLearning.InstrumentElements;
using MusicLearning.LearningObject.Accessories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicLearning.FormLearningObject.FormAccessories
{
    [Suitable((new Type[] { typeof(InstrumentAccessories) }))]

    public partial class FInstrumentAccessories : FAccessory
    {
        private InstrumentAccessories FinalAccessory = null;
        public FInstrumentAccessories()
        {
            InitializeComponent();
            SetComboBoxes(cbInstrumentGroup, typeof(InstrGroup));
        }
        public FInstrumentAccessories(object myObject, bool readOnly)
        {
            InitializeComponent();
            SetComboBoxes(cbInstrumentGroup, typeof(InstrGroup));
            SetInstrumentAccessories((InstrumentAccessories)myObject);
            if (readOnly)
            {
                SetReadOnly();
                ReceivedTeacher.ReadOnly = true;
            }
        }

        public void SetInstrumentAccessories(InstrumentAccessories instrument)
        {
            FinalAccessory = instrument;
            SetCourseName(instrument.CourseName);
            SetDate(instrument.Data);
            SetLessonType(instrument.LesType);
            SetInstrumentGroup(instrument.InstrAcGroup);
            SetTeacherNameFunction(instrument.TeacherInfo.Name);
            SetTeacherExpirienceFunction(instrument.TeacherInfo.Experience);
        }

        public void GetInstrumentAccessories(InstrumentAccessories instrument)
        {
            instrument.CourseName = GetCourseName();
            instrument.Data = GetDate();
            instrument.LesType = GetLessonType();
            instrument.InstrAcGroup = GetInstrumentGroup();
            Teacher teacher = new Teacher(GetTeacherNameFunction(), GetTeacherExpirienceFunction());
            instrument.TeacherInfo = teacher;
        }
        public void SetInstrumentGroup(InstrumentAcccessoriesEl level)
        {

            cbInstrumentGroup.SelectedIndex = (int)level.Group;
        }

        public InstrumentAcccessoriesEl GetInstrumentGroup()
        {

            InstrGroup type = (InstrGroup)cbInstrumentGroup.SelectedIndex;
            InstrumentAcccessoriesEl level = new InstrumentAcccessoriesEl(type);
            return level;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FinalAccessory == null)
            {
                InstrumentAccessories instr = new InstrumentAccessories();
                GetInstrumentAccessories(instr);
                MainForm.AddObject(instr);
            }
            else
                GetInstrumentAccessories(FinalAccessory);
            Close();
        }
    }
}
