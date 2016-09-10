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
	public partial class SlotCopy : Form
	{
		private string _Source;
		private string _Destination;

		public SlotCopy(string[] names)
		{
			InitializeComponent();
			foreach (string Name in names)
			{
				if (!Name.ToLower().EndsWith("0a"))
				{
					comboBoxSource.Items.Add(Name);
					comboBoxDestination.Items.Add(Name);
				}
			}
			if (comboBoxSource.Items.Count > 0)
			{
				comboBoxSource.SelectedIndex = 0;
				comboBoxDestination.SelectedIndex = 0;
			}
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			if (comboBoxSource.SelectedIndex > -1)
				_Source = comboBoxSource.SelectedItem.ToString();
			if (comboBoxDestination.SelectedIndex > -1)
				_Destination = comboBoxDestination.SelectedItem.ToString();

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

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			OK_Button.Enabled = comboBoxSource.SelectedIndex != comboBoxDestination.SelectedIndex;
		}
	}
}
