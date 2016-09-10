using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DSSE
{
	public partial class Rename
	{
		public Rename(string name, List<string> sections, string sectionname)
		{
			InitializeComponent();
			TextBox1.Text = name;
			foreach (string item in sections)
			{
				ComboBox1.Items.Add(item);
			}
			if (sectionname == "Unknown")
			{
				ComboBox1.SelectedIndex = 0;
			}
			else
			{
				ComboBox1.SelectedItem = sectionname;
			}
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			if (TextBox1.Text == "") { MessageBox.Show("Enter a valid Name"); return; }
			if (ComboBox1.Text == "") { MessageBox.Show("Choose a section first"); return; }
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

	}
}

