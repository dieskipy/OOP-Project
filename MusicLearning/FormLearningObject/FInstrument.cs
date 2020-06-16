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
    public partial class FInstrument : FPersonalService
    {
        public FInstrument()
        {
            InitializeComponent();
            SetComboBoxes(cbProffessionalLevel, typeof(ProfType));
        }
        public void SetProffessionalLevel(ProffessionalLevelEl level)
        {

            cbProffessionalLevel.SelectedIndex = (int)level.Prof;
        }

        public ProffessionalLevelEl GetProffessionalLevel()
        {

            ProfType type = (ProfType)cbProffessionalLevel.SelectedIndex;
            ProffessionalLevelEl level = new ProffessionalLevelEl(type);
            return level;
        }

    }
}
