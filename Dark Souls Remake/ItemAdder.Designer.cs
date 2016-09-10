using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DSSE
{
	partial class ItemAdder : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemAdder));
			this.Panel1 = new System.Windows.Forms.Panel();
			this.ListView1 = new System.Windows.Forms.ListView();
			this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CheckAllUnaquiredItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.AddItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.UncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.Searchbox = new System.Windows.Forms.ToolStripTextBox();
			this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.ToolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.Label2 = new System.Windows.Forms.Label();
			this.Panel1.SuspendLayout();
			this.ContextMenuStrip1.SuspendLayout();
			this.ToolStrip1.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.ListView1);
			this.Panel1.Location = new System.Drawing.Point(1, 67);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(636, 264);
			this.Panel1.TabIndex = 0;
			// 
			// ListView1
			// 
			this.ListView1.CheckBoxes = true;
			this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader8,
            this.ColumnHeader11,
            this.ColumnHeader12});
			this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
			this.ListView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.ListView1.FullRowSelect = true;
			this.ListView1.GridLines = true;
			this.ListView1.Location = new System.Drawing.Point(0, 0);
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new System.Drawing.Size(636, 264);
			this.ListView1.TabIndex = 128;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader5
			// 
			this.ColumnHeader5.Text = "Name";
			this.ColumnHeader5.Width = 250;
			// 
			// ColumnHeader6
			// 
			this.ColumnHeader6.Text = "Item ID";
			this.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnHeader6.Width = 125;
			// 
			// ColumnHeader8
			// 
			this.ColumnHeader8.Text = "Durability";
			this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ColumnHeader11
			// 
			this.ColumnHeader11.Text = "Sort";
			// 
			// ColumnHeader12
			// 
			this.ColumnHeader12.Text = "Section";
			this.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnHeader12.Width = 100;
			// 
			// ContextMenuStrip1
			// 
			this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckAllUnaquiredItemsToolStripMenuItem,
            this.ToolStripSeparator5,
            this.AddItemToolStripMenuItem,
            this.ToolStripSeparator4,
            this.UncheckAllToolStripMenuItem});
			this.ContextMenuStrip1.Name = "ContextMenuStrip1";
			this.ContextMenuStrip1.Size = new System.Drawing.Size(221, 82);
			// 
			// CheckAllUnaquiredItemsToolStripMenuItem
			// 
			this.CheckAllUnaquiredItemsToolStripMenuItem.Name = "CheckAllUnaquiredItemsToolStripMenuItem";
			this.CheckAllUnaquiredItemsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.CheckAllUnaquiredItemsToolStripMenuItem.Text = "Check All Unavailable Items";
			this.CheckAllUnaquiredItemsToolStripMenuItem.Click += new System.EventHandler(this.CheckAllUnaquiredItemsToolStripMenuItem_Click);
			// 
			// ToolStripSeparator5
			// 
			this.ToolStripSeparator5.Name = "ToolStripSeparator5";
			this.ToolStripSeparator5.Size = new System.Drawing.Size(217, 6);
			// 
			// AddItemToolStripMenuItem
			// 
			this.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem";
			this.AddItemToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.AddItemToolStripMenuItem.Text = "Check All";
			this.AddItemToolStripMenuItem.Click += new System.EventHandler(this.AddItemToolStripMenuItem_Click);
			// 
			// ToolStripSeparator4
			// 
			this.ToolStripSeparator4.Name = "ToolStripSeparator4";
			this.ToolStripSeparator4.Size = new System.Drawing.Size(217, 6);
			// 
			// UncheckAllToolStripMenuItem
			// 
			this.UncheckAllToolStripMenuItem.Name = "UncheckAllToolStripMenuItem";
			this.UncheckAllToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.UncheckAllToolStripMenuItem.Text = "Uncheck All";
			this.UncheckAllToolStripMenuItem.Click += new System.EventHandler(this.UncheckAllToolStripMenuItem_Click);
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.Transparent;
			this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Searchbox,
            this.ToolStripButton1,
            this.ToolStripSeparator1,
            this.ToolStripComboBox1,
            this.ToolStripSeparator3,
            this.ToolStripLabel1,
            this.ToolStripTextBox2,
            this.ToolStripSeparator2,
            this.ToolStripButton2});
			this.ToolStrip1.Location = new System.Drawing.Point(1, 33);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.Size = new System.Drawing.Size(656, 31);
			this.ToolStrip1.TabIndex = 1;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// Searchbox
			// 
			this.Searchbox.Name = "Searchbox";
			this.Searchbox.Size = new System.Drawing.Size(230, 31);
			this.Searchbox.ToolTipText = "Enter Name or ID to Search";
			this.Searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Searchbox_KeyDown);
			// 
			// ToolStripButton1
			// 
			this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton1.Image")));
			this.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButton1.Name = "ToolStripButton1";
			this.ToolStripButton1.Size = new System.Drawing.Size(28, 28);
			this.ToolStripButton1.Text = "Search";
			this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// ToolStripComboBox1
			// 
			this.ToolStripComboBox1.Name = "ToolStripComboBox1";
			this.ToolStripComboBox1.Size = new System.Drawing.Size(150, 31);
			this.ToolStripComboBox1.ToolTipText = "Item Section";
			this.ToolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBox1_SelectedIndexChanged);
			// 
			// ToolStripSeparator3
			// 
			this.ToolStripSeparator3.Name = "ToolStripSeparator3";
			this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// ToolStripLabel1
			// 
			this.ToolStripLabel1.Name = "ToolStripLabel1";
			this.ToolStripLabel1.Size = new System.Drawing.Size(62, 28);
			this.ToolStripLabel1.Text = "Ammount";
			// 
			// ToolStripTextBox2
			// 
			this.ToolStripTextBox2.MaxLength = 3;
			this.ToolStripTextBox2.Name = "ToolStripTextBox2";
			this.ToolStripTextBox2.Size = new System.Drawing.Size(100, 31);
			this.ToolStripTextBox2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ToolStripTextBox2.ToolTipText = "Ammount For each checked item";
			// 
			// ToolStripSeparator2
			// 
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// ToolStripButton2
			// 
			this.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton2.Image")));
			this.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButton2.Name = "ToolStripButton2";
			this.ToolStripButton2.Size = new System.Drawing.Size(28, 28);
			this.ToolStripButton2.Text = "Add Checked Items";
			this.ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
			// 
			// GroupBox1
			// 
			this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
			this.GroupBox1.Controls.Add(this.Button2);
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.ProgressBar1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Location = new System.Drawing.Point(1, 337);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(630, 82);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Progress";
			// 
			// Button2
			// 
			this.Button2.Location = new System.Drawing.Point(526, 46);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(104, 30);
			this.Button2.TabIndex = 3;
			this.Button2.Text = "Close";
			this.Button2.UseVisualStyleBackColor = true;
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(526, 10);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(104, 30);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Cancel";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button1.Visible = false;
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = System.Drawing.Color.Green;
			this.Label3.Location = new System.Drawing.Point(302, 10);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(115, 16);
			this.Label3.TabIndex = 3;
			this.Label3.Text = "Green = Available";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(63, 37);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(0, 13);
			this.Label1.TabIndex = 1;
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(66, 53);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(415, 23);
			this.ProgressBar1.TabIndex = 0;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Location = new System.Drawing.Point(168, 10);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(128, 16);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Red = Not Available";
			// 
			// ItemAdder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 431);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.ToolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ItemAdder";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ItemAdder";
			this.Panel1.ResumeLayout(false);
			this.ContextMenuStrip1.ResumeLayout(false);
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.ToolStrip ToolStrip1;
		internal System.Windows.Forms.ToolStripTextBox Searchbox;
		internal System.Windows.Forms.ToolStripButton ToolStripButton1;
		internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
		internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox2;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripComboBox ToolStripComboBox1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton ToolStripButton2;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ProgressBar ProgressBar1;
		internal System.Windows.Forms.ListView ListView1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		internal System.Windows.Forms.ColumnHeader ColumnHeader8;
		internal System.Windows.Forms.ColumnHeader ColumnHeader11;
		internal System.Windows.Forms.ColumnHeader ColumnHeader12;
		internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem AddItemToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
		internal System.Windows.Forms.ToolStripMenuItem UncheckAllToolStripMenuItem;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.ToolStripMenuItem CheckAllUnaquiredItemsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		private System.ComponentModel.IContainer components;

	}
}

