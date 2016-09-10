namespace DSSE
{
	partial class SlotSwap
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
			this.comboBoxSlot2 = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBoxSlot1 = new System.Windows.Forms.ComboBox();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxSlot2
			// 
			this.comboBoxSlot2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlot2.FormattingEnabled = true;
			this.comboBoxSlot2.Location = new System.Drawing.Point(6, 19);
			this.comboBoxSlot2.Name = "comboBoxSlot2";
			this.comboBoxSlot2.Size = new System.Drawing.Size(222, 21);
			this.comboBoxSlot2.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBoxSlot2);
			this.groupBox2.Location = new System.Drawing.Point(255, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(234, 48);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Slot 2";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBoxSlot1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(234, 48);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Slot 1";
			// 
			// comboBoxSlot1
			// 
			this.comboBoxSlot1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlot1.FormattingEnabled = true;
			this.comboBoxSlot1.Location = new System.Drawing.Point(6, 19);
			this.comboBoxSlot1.Name = "comboBoxSlot1";
			this.comboBoxSlot1.Size = new System.Drawing.Size(222, 21);
			this.comboBoxSlot1.TabIndex = 3;
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(422, 66);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
			this.Cancel_Button.TabIndex = 8;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// OK_Button
			// 
			this.OK_Button.Enabled = false;
			this.OK_Button.Location = new System.Drawing.Point(349, 66);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(67, 23);
			this.OK_Button.TabIndex = 7;
			this.OK_Button.Text = "OK";
			this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
			// 
			// SlotSwap
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(501, 100);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.OK_Button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SlotSwap";
			this.Text = "Swap Slots";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.ComboBox comboBoxSlot2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.ComboBox comboBoxSlot1;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Button OK_Button;
	}
}