using System;
using System.Linq;
using System.Windows.Forms;

namespace DSSE
{
    public partial class SlotSwap : Form
    {
        public SlotSwap(ComboboxItem[] names)
        {
            InitializeComponent();
            foreach (var t in names.Where(t => !Name.ToLower().EndsWith("0a")))
            {
                comboBoxSlot1.Items.Add(t);
                comboBoxSlot2.Items.Add(t);
            }
            if (comboBoxSlot1.Items.Count > -1)
                comboBoxSlot1.SelectedIndex = 0;
            if (comboBoxSlot2.Items.Count > -1)
                comboBoxSlot2.SelectedIndex = 0;
        }

        public SlotSwap(string[] names)
        {
            InitializeComponent();
            foreach (var Name in names.Where(Name => !Name.ToLower().EndsWith("0a")))
            {
                comboBoxSlot1.Items.Add(Name);
                comboBoxSlot2.Items.Add(Name);
            }
            if (comboBoxSlot1.Items.Count > 0)
            {
                comboBoxSlot1.SelectedIndex = 0;
                comboBoxSlot2.SelectedIndex = 0;
            }
        }

        public ComboboxItem Slot1 { get; private set; }
        public ComboboxItem Slot2 { get; private set; }

        public void OK_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (comboBoxSlot1.SelectedIndex > -1)
                Slot1 = ((ComboboxItem)comboBoxSlot1.SelectedItem);
            if (comboBoxSlot2.SelectedIndex > -1)
                Slot2 = ((ComboboxItem)comboBoxSlot2.SelectedItem);
            ;

            Close();
        }

        public void Cancel_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Slot1 = null;
            Slot2 = null;
            Close();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OK_Button.Enabled = comboBoxSlot1.SelectedIndex != comboBoxSlot2.SelectedIndex;
        }
    }
}