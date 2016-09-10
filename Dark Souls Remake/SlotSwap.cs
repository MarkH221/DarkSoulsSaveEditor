using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSSE
{
	public partial class SlotSwap : Form
	{
		private string _Slot1;
		private string _Slot2;

		public SlotSwap(string[] names)
		{
			InitializeComponent();
			foreach (string Name in names)
			{
				if (!Name.ToLower().EndsWith("0a"))
				{
					comboBoxSlot1.Items.Add(Name);
					comboBoxSlot2.Items.Add(Name);
				}
			}
			if (comboBoxSlot1.Items.Count > 0)
			{
				comboBoxSlot1.SelectedIndex = 0;
				comboBoxSlot2.SelectedIndex = 0;
			}
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			if (comboBoxSlot1.SelectedIndex > -1)
				_Slot1 = comboBoxSlot1.SelectedItem.ToString();
			if (comboBoxSlot2.SelectedIndex > -1)
				_Slot2 = comboBoxSlot2.SelectedItem.ToString();

			this.Close();
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_Slot1 = null;
			_Slot2 = null;
			this.Close();
		}

		public string Slot1
		{ get { return _Slot1; } }
		public string Slot2
		{ get { return _Slot2; } }

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			OK_Button.Enabled = comboBoxSlot1.SelectedIndex != comboBoxSlot2.SelectedIndex;
		}
	}
}
