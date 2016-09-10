using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DSSE
{
	public partial class ItemAdder
	{
		public bool Cancel = false;
		public List<ItemDBList> List = null;
		public ItemAdder(List<ItemDBList> items)
		{
			InitializeComponent();
			ListView1.BeginUpdate();
			if (items.Count > 0)
				List = items;
			else
				return;

			ToolStripComboBox1.Items.Add("All");
			foreach (object o in Program.mainForm.SectionContainer2.Items)
				ToolStripComboBox1.Items.Add(o);

			/*HashSet<string> CurrentSections = new HashSet<string>();
			foreach (ItemDBList item in items)
			{
				if (!CurrentSections.Contains(item.Section))
				{
					CurrentSections.Add(item.Section);
					ToolStripComboBox1.Items.Add(item.Section);
				}
			}*/
			ToolStripComboBox1.SelectedIndex = 1;
			ListView1.EndUpdate();
		}

		public void Viewsection()
		{
			if (List.Count > 0)
			{
				ListView1.Items.Clear();
				ListView1.BeginUpdate();
				ListViewItem lv;
				bool all = ToolStripComboBox1.SelectedItem.ToString() == "All";
				foreach (ItemDBList item in List)
				{
					if (all || item.Section == ToolStripComboBox1.SelectedItem.ToString())
					{
						lv = new ListViewItem(item.Name);
						if (Program.mainForm.IDExist(item.ID, item.Section, ItemStorage.Save))
							lv.ForeColor = Color.Green;
						else
							lv.ForeColor = Color.Red;
						lv.SubItems.Add(item.ID);
						lv.SubItems.Add(item.Durability.ToString());
						lv.SubItems.Add(item.SortValue);
						lv.SubItems.Add(item.Section);
						ListView1.Items.Add(lv);

						Application.DoEvents();
					}
				}
				ListView1.EndUpdate();
			}
		}

		public void ToolStripComboBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			Viewsection();
		}

		public void ToolStripButton2_Click(System.Object sender, System.EventArgs e)
		{
			if (Program.mainForm.ItemList == null || ListView1.Items.Count == 0)
				return;
			if (ListView1.CheckedItems.Count == 0) { MessageBox.Show("No Items Checked!"); return; }
			int Value = 0;
			int i = 0;
			Application.DoEvents();
			Button1.Visible = true;
			foreach (ListViewItem item in ListView1.CheckedItems)
			{
				if (item.Checked)
				{
                    if(Cancel)
						break;
                    Application.DoEvents();
                    ProgressBar1.Value = (int)Math.Round(new Decimal((i / (float)ListView1.CheckedItems.Count) * 100), 0);
                    Application.DoEvents();
                    Label1.Text = "Adding >> " + item.Text;
                    Value = Program.mainForm.GetAvailibleSpot(item.SubItems[4].Text.ToLower().Contains("keys"));
                    if(Value == -1)
					{
						MessageBox.Show("Inventory limit reached!");
						break;
					}
					Items x = new Items(item.SubItems[1].Text, item.Text, IsvalidValue(ToolStripTextBox2.Text) ? int.Parse(ToolStripTextBox2.Text) : (item.SubItems[4].Text == "Ammo" ? 999 : 1), item.SubItems[3].Text, (uint)Value, int.Parse(item.SubItems[2].Text), 0, 1, Program.mainForm.ItemList[Value].Offset, item.SubItems[4].Text);
                    i++;
					Program.mainForm.ReplaceItem(x);
				}
			}
			Cancel = false;
			Label1.Text = "";
			ProgressBar1.Value = 0;
			Button1.Visible = false;
			Program.mainForm.ViewSection(ToolStripComboBox1.SelectedItem.ToString(), ItemStorage.Save);
			Program.mainForm.Status.Text = Program.mainForm.Getstatustext();
			Viewsection();
			MessageBox.Show(i.ToString() + " Items Added");
		}

		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Cancel = true;
			Button1.Visible = false;
		}

		public bool IsvalidValue(string value)
		{
			try
			{
				if (value.Replace("\0", "") == "")
					return false;
				List<char> x = new List<char>();
				for (int i = 0; i <= 10; i++)
				{
					x.Add((char)((int)'0' + i));
				}
				foreach (char c in value)
				{
					if (!x.Contains(c))
						return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void AddItemToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
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

		public void ToolStripButton1_Click(System.Object sender, System.EventArgs e)
		{
			if (Program.mainForm.ItemTextLists == null || Program.mainForm.ItemTextLists.Count == 0)
				return;
			if (Searchbox.Text == "") { MessageBox.Show("Enter something to look for"); return; }
			List<ItemDBList> result = new List<ItemDBList>();
			int ResultsInSection = 0;
			for (int i = 0; i <= Program.mainForm.ItemTextLists.Count - 1; i++)
			{
				if (Program.mainForm.ItemTextLists[i].Name.ToLower().Contains(Searchbox.Text.ToLower()) || Program.mainForm.ItemTextLists[i].ID.ToLower().Contains(Searchbox.Text.ToLower()) || Program.mainForm.ItemTextLists[i].Section.ToLower().Contains(Searchbox.Text.ToLower()))
					result.Add(Program.mainForm.ItemTextLists[i]);
			}
			if (result.Count > 0)
			{
				ListView1.Items.Clear();
				ListView1.BeginUpdate();
				ListViewItem lv;
				bool all = ToolStripComboBox1.SelectedItem.ToString() == "All";
				foreach (ItemDBList item in result)
				{
					if (all || item.Section == ToolStripComboBox1.SelectedItem.ToString())
					{
						ResultsInSection++;

						lv = new ListViewItem(item.Name);
						if (Program.mainForm.IDExist(item.ID, item.Section, ItemStorage.Save))
							lv.ForeColor = Color.Green;
						else
							lv.ForeColor = Color.Red;
						lv.SubItems.Add(item.ID);
						lv.SubItems.Add(item.Durability.ToString());
						lv.SubItems.Add(item.SortValue);
						lv.SubItems.Add(item.Section);
						ListView1.Items.Add(lv);
					}
				}
				ListView1.EndUpdate();
				if(ResultsInSection > 1)
					MessageBox.Show(ResultsInSection.ToString() + " Results Found!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else if (ResultsInSection > 0)
					MessageBox.Show(ResultsInSection.ToString() + " Result Found!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("No results found in this section!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Nothing Found!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public void Searchbox_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				ToolStripButton1.PerformClick();
			}
		}

		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}

		public void CheckAllUnaquiredItemsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in ListView1.Items)
			{
				if (item.ForeColor == Color.Red)
					item.Checked = true;
				else
					item.Checked = false;
			}
		}
	}
}