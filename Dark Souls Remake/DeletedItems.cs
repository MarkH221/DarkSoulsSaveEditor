using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DSSE
{
	public partial class DeletedItems
	{
		public DeletedItems(List<Items> itemlist)
		{
			InitializeComponent();
			ListViewItem lv;
			for (int i = 0; i <= itemlist.Count - 1; i++)
			{
				lv = new ListViewItem(itemlist[i].Name);
				lv.SubItems.Add(itemlist[i].ID);
				ListView1.Items.Add(lv);
			}
		}

		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		public void CheckAllToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in ListView1.Items)
			{
				item.Checked = true;
			}
		}

		public void UncheckAllToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in ListView1.Items)
			{
				item.Checked = false;
			}
		}

		public Items GetitemFromList(string id)
		{
			for (int i = 0; i <= Program.mainForm.RemovedItems.Count - 1; i++)
			{
				if (Program.mainForm.RemovedItems[i].ID == id)
					return Program.mainForm.RemovedItems[i];
			}
			return null;
		}

		public void RestoreToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			if (ListView1.SelectedItems.Count > 0)
			{
				int count = 0;
				foreach (ListViewItem item in ListView1.SelectedItems)
				{
					Program.mainForm.ReplaceItem(GetitemFromList(item.SubItems[1].Text));
					Program.mainForm.RemovedItems.RemoveAt(item.Index);
					item.Remove();
					count += 1;
				}
				if (count > 0)
					MessageBox.Show(count.ToString() + " Items Restored");
				else
					MessageBox.Show("Select some items first");
			}
		}

		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			int count = 0;
			foreach (ListViewItem item in ListView1.Items)
			{
				if (item.Checked)
				{
					Program.mainForm.ReplaceItem(GetitemFromList(item.SubItems[1].Text));
					Program.mainForm.RemovedItems.RemoveAt(item.Index);
					item.Remove();
					count += 1;
				}
			}
			if (count > 0)
				MessageBox.Show(count.ToString() + " Items Restored");
			else
				MessageBox.Show("Select some items first");
		}

		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			if (ListView1.Items.Count > 0)
			{
				int count = 0;
				foreach (ListViewItem item in ListView1.Items)
				{
					Program.mainForm.ReplaceItem(GetitemFromList(item.SubItems[1].Text));
					item.Remove();
					count += 1;
				}
				Program.mainForm.RemovedItems.Clear();
				if (count > 0)
					MessageBox.Show(count.ToString() + " Items Restored");
				else
					MessageBox.Show("Select some items first");
			}
		}
	}
}