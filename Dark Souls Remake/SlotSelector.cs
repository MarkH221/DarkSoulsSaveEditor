using System;
using System.Linq;
using System.Windows.Forms;

namespace DSSE
{
    public partial class SlotSelector
    {
        public int xselectedindex;
        public string xselectedsave;

        public SlotSelector(ComboboxItem[] names)
        {
            InitializeComponent();
            foreach (var t in names.Where(t => !Text.ToLower().EndsWith("0a")))
            {
                ComboBox1.Items.Add(t);
            }
            if (ComboBox1.Items.Count > -1)
                ComboBox1.SelectedIndex = 0;
        }

        public SlotSelector(string[] names)
        {
            InitializeComponent();
            for (var index = 0; index < names.Length; index++)
            {
                if (!names[index].ToLower().EndsWith("0a"))
                {
                    ComboBox1.Items.Add(new ComboboxItem { Text = names[index], Value = index });
                }
            }
            if (ComboBox1.Items.Count > -1)
                ComboBox1.SelectedIndex = 0;
        }

        public string SelectedSave
        {
            get { return xselectedsave; }
            set { xselectedsave = value; }
        }

        public int SelectedIndex
        {
            get { return xselectedindex; }
            set { xselectedindex = value; }
        }

        public void OK_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (ComboBox1.SelectedIndex > -1)
            {
                xselectedsave = ((ComboboxItem)ComboBox1.SelectedItem).Text;
                xselectedindex = ((ComboboxItem)ComboBox1.SelectedItem).Value;
            }
            Close();
        }

        public void Cancel_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            xselectedsave = null;
            xselectedindex = -1;
            Close();
        }
    }
}