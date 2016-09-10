using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace DSSE
{
	partial class DeletedItems : System.Windows.Forms.Form
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
			this.ListView1 = new System.Windows.Forms.ListView();
			this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.CheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.UncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.ContextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ListView1
			// 
			this.ListView1.CheckBoxes = true;
			this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
			this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
			this.ListView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ListView1.FullRowSelect = true;
			this.ListView1.GridLines = true;
			this.ListView1.Location = new System.Drawing.Point(0, 0);
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new System.Drawing.Size(435, 207);
			this.ListView1.TabIndex = 1;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Text = "Name";
			this.ColumnHeader1.Width = 250;
			// 
			// ColumnHeader2
			// 
			this.ColumnHeader2.Text = "ID";
			this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnHeader2.Width = 150;
			// 
			// ContextMenuStrip1
			// 
			this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreToolStripMenuItem,
            this.ToolStripSeparator2,
            this.CheckAllToolStripMenuItem,
            this.ToolStripSeparator1,
            this.UncheckAllToolStripMenuItem});
			this.ContextMenuStrip1.Name = "ContextMenuStrip1";
			this.ContextMenuStrip1.Size = new System.Drawing.Size(153, 104);
			// 
			// RestoreToolStripMenuItem
			// 
			this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
			this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.RestoreToolStripMenuItem.Text = "Restore";
			this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
			// 
			// ToolStripSeparator2
			// 
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// CheckAllToolStripMenuItem
			// 
			this.CheckAllToolStripMenuItem.Name = "CheckAllToolStripMenuItem";
			this.CheckAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.CheckAllToolStripMenuItem.Text = "Check All";
			this.CheckAllToolStripMenuItem.Click += new System.EventHandler(this.CheckAllToolStripMenuItem_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// UncheckAllToolStripMenuItem
			// 
			this.UncheckAllToolStripMenuItem.Name = "UncheckAllToolStripMenuItem";
			this.UncheckAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.UncheckAllToolStripMenuItem.Text = "Uncheck All";
			this.UncheckAllToolStripMenuItem.Click += new System.EventHandler(this.UncheckAllToolStripMenuItem_Click);
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Cancel_Button.Location = new System.Drawing.Point(323, 213);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(100, 32);
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "Done";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// OK_Button
			// 
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point(217, 213);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(100, 32);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "Restore All";
			this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
			// 
			// Button1
			// 
			this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Button1.Location = new System.Drawing.Point(111, 213);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(100, 32);
			this.Button1.TabIndex = 3;
			this.Button1.Text = "Restore Checked";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// DeletedItems
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(435, 257);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.OK_Button);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.ListView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeletedItems";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Deleted Items";
			this.ContextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		internal System.Windows.Forms.ListView ListView1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem CheckAllToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripMenuItem UncheckAllToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.Button Button1;
		private System.ComponentModel.IContainer components;

	}
}

