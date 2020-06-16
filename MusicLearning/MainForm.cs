using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicLearning.Attributes;
using MusicLearning.FormLearningObject.FormAccessories;
using MusicLearning.FormLearningObjects.FormInstruments;
using MusicLearning.LearningObject;
using MusicLearning.LearningObject.Accessories;
using MusicLearning.LearningObject.Instruments;

namespace MusicLearning
{
    public partial class MainForm : Form
    {
        private readonly List<Type> ServicesList = new List<Type>();
        private readonly List<Form> FormsList = new List<Form>();
        private static readonly List<object> ObjectList = new List<object>();
        public MainForm()
        {
            InitializeComponent();
            FillServicesList();
            FillFormsList();
            cbChooseService.SelectedIndex = 0;
        }

        //Methods for filling base lists
        private void FillServicesList()
        {
            ServicesList.Add(typeof(Keyboard));
            ServicesList.Add(typeof(Strings));
            ServicesList.Add(typeof(Wind));
            ServicesList.Add(typeof(InstrumentAccessories));
        }
        private void FillFormsList()
        {
            FormsList.Add(new FKeyboard());
            FormsList.Add(new FStrings());
            FormsList.Add(new FWind());
            FormsList.Add(new FInstrumentAccessories());
        }
        private void Redraw()
        {
            lvService.Items.Clear();
            int i = 1;
            string[] str = new string[3];
            foreach (PersonalService service in ObjectList)
            {
                Type type = service.GetType();
                str[0] = i.ToString();
                i++;
                if (Attribute.IsDefined(type, typeof(ProductType)))
                {
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(ProductType)) as ProductType;
                    str[2] = attributeValue.TypeName;
                }
                else
                    str[2] = "";

                str[1] = service.CourseName;
                ListViewItem item = new ListViewItem(str);
                lvService.Items.Add(item);
            }

        }

        
        public static void AddObject(object myObject)
        {
            ObjectList.Add(myObject);
        }

        //Method creates a new form to input for every selected class
        private void CreateFormForAdd(Type myType)
        {
            Form form = null;
            foreach (Form tmpForm in FormsList)
            {
                Type type = tmpForm.GetType();
                //Check for correct form from the FromsList
                if (Attribute.IsDefined(type, typeof(Suitable)))
                {
                    //Retrieve our custom attribute from received type
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(Suitable)) as Suitable;
                    if (attributeValue.CheckForAvailability(myType))
                        form = (Form)Activator.CreateInstance(type);
                }
            }
            if (form != null)
            {
                form.ShowDialog();
            }
        }

        private void CreateFormForViewOrEdit(Object myObject, bool readMode)
        {
            Form form = null;
            foreach (Form tmpForm in FormsList)
            {
                Type type = tmpForm.GetType();
                //Check for correct form from the FromsList
                if (Attribute.IsDefined(type, typeof(Suitable)))
                {
                    //Retrieve our custom attribute from received type
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(Suitable)) as Suitable;
                    //If our object's type == type of form
                    if (attributeValue.CheckForAvailability(myObject.GetType()))
                        form = (Form)Activator.CreateInstance(type, myObject, readMode);
                }
            }
            if (form != null)
            {
                form.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateFormForAdd(ServicesList[cbChooseService.SelectedIndex]);
            Redraw();
        }

        private void lvService_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvService.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvService.SelectedItems.Count == 1 && lvService.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvService.SelectedIndices;
                CreateFormForViewOrEdit(ObjectList[indexes[0]], true);
                Redraw();
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали");
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvService.SelectedItems.Count == 1 && lvService.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvService.SelectedIndices;
                CreateFormForViewOrEdit(ObjectList[indexes[0]], false);
                Redraw();
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали");
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvService.SelectedItems.Count == 1 && lvService.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvService.SelectedIndices;
                ObjectList.RemoveAt(indexes[0]);
                Redraw();
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали");
            }
        }
    }
}
