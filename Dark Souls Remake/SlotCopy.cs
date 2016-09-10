using System;
using System.Windows.Forms;

namespace DSSE
{
    public partial class SlotCopy : Form
    {
        public SlotCopy(ComboboxItem[] names)
        {
            InitializeComponent();
            SlotFunctions.SlotMagic(names, comboBoxSource, comboBoxDestination);
            ;
            //foreach (var t in names.Where(t => !Text.ToLower().EndsWith("0a")))
            //{
            //    comboBoxSource.Items.Add(t);
            //    comboBoxDestination.Items.Add(t);
            //}
            //if (comboBoxSource.Items.Count > -1)
            //    comboBoxSource.SelectedIndex = 0;
            //if (comboBoxDestination.Items.Count > -1)
            //    comboBoxDestination.SelectedIndex = 0;
        }

        public SlotCopy(string[] names)
        {
            InitializeComponent();
            SlotFunctions.SlotMagic(names, comboBoxSource, comboBoxDestination);
            //foreach (var name in names.Where(n => !n.ToLower().EndsWith("0a")))
            //{
            //    comboBoxSource.Items.Add(name);
            //    comboBoxDestination.Items.Add(name);
            //}
            //if (comboBoxSource.Items.Count > 0)
            //{
            //    comboBoxSource.SelectedIndex = 0;
            //    comboBoxDestination.SelectedIndex = 0;
            //}
        }

        public ComboboxItem Source { get; private set; }
        public ComboboxItem Destination { get; private set; }

        public void OK_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (comboBoxSource.SelectedIndex > -1)
                Source = ((ComboboxItem)comboBoxSource.SelectedItem);
            if (comboBoxDestination.SelectedIndex > -1)
                Destination = ((ComboboxItem)comboBoxDestination.SelectedItem);

            Close();
        }

        public void Cancel_Button_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Source = null;
            Destination = null;
            Close();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OK_Button.Enabled = comboBoxSource.SelectedIndex != comboBoxDestination.SelectedIndex;
        }
    }
}