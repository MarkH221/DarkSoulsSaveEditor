using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace DSSE
{
	public partial class SlotSelector
	{
		public string xselectedsave;
		public SlotSelector(string[] names)
		{
			InitializeComponent();
			foreach (string Name in names)
			{
				if (!Name.ToLower().EndsWith("0a"))
				{
					ComboBox1.Items.Add(Name);
				}
			}
			if (ComboBox1.Items.Count > -1)
				ComboBox1.SelectedIndex = 0;
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			if (ComboBox1.SelectedIndex > -1)
			{
				xselectedsave = (string)ComboBox1.SelectedItem;
			}
			this.Close();
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			xselectedsave = null;
			this.Close();
		}

		public string SelectedSave
		{
			get { return xselectedsave; }
			set { xselectedsave = value; }
		}
	}
}

