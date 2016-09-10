namespace DSSE
{
	partial class SlotExtract
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlotExtract));
			this.comboBoxSlot = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBoxSlot
			// 
			this.comboBoxSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlot.FormattingEnabled = true;
			this.comboBoxSlot.Location = new System.Drawing.Point(74, 47);
			this.comboBoxSlot.Name = "comboBoxSlot";
			this.comboBoxSlot.Size = new System.Drawing.Size(222, 21);
			this.comboBoxSlot.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(542, 26);
			this.label1.TabIndex = 7;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Save Slot:";
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(489, 45);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
			this.Cancel_Button.TabIndex = 10;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// OK_Button
			// 
			this.OK_Button.Location = new System.Drawing.Point(343, 45);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(140, 23);
			this.OK_Button.TabIndex = 11;
			this.OK_Button.Text = "Choose Destination...";
			this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
			// 
			// SlotExtract
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 80);
			this.Controls.Add(this.OK_Button);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSlot);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SlotExtract";
			this.Text = "Extract a Save Slot";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ComboBox comboBoxSlot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Button OK_Button;
	}
}