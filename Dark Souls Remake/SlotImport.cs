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
	public partial class SlotImport : Form
	{
		private string _Source = null;
		private string _Destination = null;

		public SlotImport(string[] names)
		{
			InitializeComponent();
			foreach (string Name in names)
			{
				if (!Name.ToLower().EndsWith("0a"))
				{
					comboBoxSlot.Items.Add(Name);
				}
			}
			if (comboBoxSlot.Items.Count > 0)
			{
				comboBoxSlot.SelectedIndex = 0;
			}
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			
			_Source = textBoxFile.Text;
			if (comboBoxSlot.SelectedIndex > -1)
				_Destination = comboBoxSlot.SelectedItem.ToString();

			this.Close();
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_Source = null;
			_Destination = null;
			this.Close();
		}

		public string Source
		{ get { return _Source; } }
		public string Destination
		{ get { return _Destination; } }
		public bool FixHash
		{ get { return checkBoxHash.Checked; } }

		private void BrowseB_Click(object sender, EventArgs e)
		{
			OpenFileDialog file = new OpenFileDialog();
			file.Title = "Choose Source File";
			file.FileName = comboBoxSlot.SelectedItem.ToString();
			file.Filter = "All Files|*.*";
			file.CheckFileExists = true;
			file.SupportMultiDottedExtensions = true;
			file.ValidateNames = true;
			file.AddExtension = false;
			if (file.ShowDialog() == DialogResult.OK)
			{
				textBoxFile.Text = file.FileName;
			}
		}

		private void textBoxFile_TextChanged(object sender, EventArgs e)
		{
			OK_Button.Enabled = System.IO.File.Exists(textBoxFile.Text);
		}
	}
}
