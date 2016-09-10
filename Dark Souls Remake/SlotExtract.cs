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
	public partial class SlotExtract : Form
	{
		private string _Slot = null;
		private string _File = null;

		public SlotExtract(string[] names)
		{
			InitializeComponent();
			foreach (string Name in names)
			{
				if (!Name.ToLower().EndsWith("0a"))
					comboBoxSlot.Items.Add(Name);
			}
			if (comboBoxSlot.Items.Count > 0)
				comboBoxSlot.SelectedIndex = 0;
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_Slot = null;
			_File = null;
			this.Close();
		}

		public string Slot
		{ get { return _Slot; } }
		public string Filename
		{ get { return _File; } }

		private void OK_Button_Click(object sender, EventArgs e)
		{
			if (comboBoxSlot.SelectedItem == null)
				return;

			SaveFileDialog file = new SaveFileDialog();
			file.Title = "Choose Destination File";
			file.FileName = comboBoxSlot.SelectedItem.ToString();
			file.Filter = "All Files|*.*";
			file.OverwritePrompt = true;
			file.SupportMultiDottedExtensions = true;
			file.ValidateNames = true;
			file.AddExtension = false;
			if (file.ShowDialog() == DialogResult.OK)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				_Slot = comboBoxSlot.SelectedItem.ToString();
				_File = file.FileName;
				this.Close();
			}
		}
	}
}
