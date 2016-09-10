namespace DSSE
{
	partial class SlotImport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlotImport));
			this.comboBoxSlot = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BrowseB = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxHash = new System.Windows.Forms.CheckBox();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBoxSlot
			// 
			this.comboBoxSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlot.FormattingEnabled = true;
			this.comboBoxSlot.Location = new System.Drawing.Point(102, 90);
			this.comboBoxSlot.Name = "comboBoxSlot";
			this.comboBoxSlot.Size = new System.Drawing.Size(222, 21);
			this.comboBoxSlot.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(488, 39);
			this.label1.TabIndex = 8;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// textBoxFile
			// 
			this.textBoxFile.Location = new System.Drawing.Point(81, 64);
			this.textBoxFile.Name = "textBoxFile";
			this.textBoxFile.Size = new System.Drawing.Size(292, 20);
			this.textBoxFile.TabIndex = 9;
			this.textBoxFile.TextChanged += new System.EventHandler(this.textBoxFile_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Source File:";
			// 
			// BrowseB
			// 
			this.BrowseB.Location = new System.Drawing.Point(379, 64);
			this.BrowseB.Name = "BrowseB";
			this.BrowseB.Size = new System.Drawing.Size(29, 20);
			this.BrowseB.TabIndex = 11;
			this.BrowseB.Text = "...";
			this.BrowseB.UseVisualStyleBackColor = true;
			this.BrowseB.Click += new System.EventHandler(this.BrowseB_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Destination Slot:";
			// 
			// checkBoxHash
			// 
			this.checkBoxHash.AutoSize = true;
			this.checkBoxHash.Checked = true;
			this.checkBoxHash.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxHash.Location = new System.Drawing.Point(414, 66);
			this.checkBoxHash.Name = "checkBoxHash";
			this.checkBoxHash.Size = new System.Drawing.Size(67, 17);
			this.checkBoxHash.TabIndex = 12;
			this.checkBoxHash.Text = "Fix Hash";
			this.checkBoxHash.UseVisualStyleBackColor = true;
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(433, 90);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(67, 21);
			this.Cancel_Button.TabIndex = 13;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// OK_Button
			// 
			this.OK_Button.Enabled = false;
			this.OK_Button.Location = new System.Drawing.Point(360, 90);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(67, 21);
			this.OK_Button.TabIndex = 14;
			this.OK_Button.Text = "OK";
			this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
			// 
			// SlotImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 124);
			this.Controls.Add(this.OK_Button);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.checkBoxHash);
			this.Controls.Add(this.BrowseB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSlot);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SlotImport";
			this.Text = "Import a Save Slot";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ComboBox comboBoxSlot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BrowseB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBoxHash;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Button OK_Button;
	}
}