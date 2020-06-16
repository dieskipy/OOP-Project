using MusicLearning.InstrumentElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicLearning.FormLearningObject
{
    public partial class FAccessory : FPersonalService
    {
        public FAccessory()
        {
            InitializeComponent();
            SetComboBoxes(cbLessonType, typeof(Lesson));
        }
        public void SetLessonType(LessonTypeEl level)
        {

            cbLessonType.SelectedIndex = (int)level.Lesson;
        }

        public LessonTypeEl GetLessonType()
        {

            Lesson type = (Lesson)cbLessonType.SelectedIndex;
            LessonTypeEl level = new LessonTypeEl(type);
            return level;
        }
    }
}
