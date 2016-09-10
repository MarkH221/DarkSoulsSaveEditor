using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace DSSE
{
	partial class MainForm : System.Windows.Forms.Form
  {
    //Form overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
      try {
        if (disposing && components != null) {
          components.Dispose();
        }
      } finally {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenB = new System.Windows.Forms.ToolStripDropDownButton();
            this.xbox360ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.SaveAllB = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.SaveAsB = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.SlotB = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator16 = new System.Windows.Forms.ToolStripLabel();
            this.CopyB = new System.Windows.Forms.ToolStripButton();
            this.SwapB = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Status = new System.Windows.Forms.ToolStripLabel();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxHSID = new System.Windows.Forms.ComboBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.comboBoxHairStyle = new System.Windows.Forms.ComboBox();
            this.ComboBoxPhysique = new System.Windows.Forms.ComboBox();
            this.numericUpDownSkinBrightness = new System.Windows.Forms.NumericUpDown();
            this.textBoxHC = new System.Windows.Forms.TextBox();
            this.textBoxEC = new System.Windows.Forms.TextBox();
            this.ComboBoxGift = new System.Windows.Forms.ComboBox();
            this.ComboBoxClass = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ComboBoxGender = new System.Windows.Forms.ComboBox();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Label18 = new System.Windows.Forms.Label();
            this.Souls = new System.Windows.Forms.NumericUpDown();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBoxCovenant = new System.Windows.Forms.ComboBox();
            this.Strength = new System.Windows.Forms.NumericUpDown();
            this.MaxAllB = new System.Windows.Forms.Button();
            this.Label17 = new System.Windows.Forms.Label();
            this.Stamina2 = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CharacterName = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Resistance = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.labe1 = new System.Windows.Forms.Label();
            this.HP1 = new System.Windows.Forms.NumericUpDown();
            this.Humanity = new System.Windows.Forms.NumericUpDown();
            this.HP2 = new System.Windows.Forms.NumericUpDown();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Endurance = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Stamina1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPlaythrough = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSin = new System.Windows.Forms.NumericUpDown();
            this.Level = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.Vitality = new System.Windows.Forms.NumericUpDown();
            this.Faith = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Attunement = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.Intelligence = new System.Windows.Forms.NumericUpDown();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Dexterity = new System.Windows.Forms.NumericUpDown();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBoxRing2 = new System.Windows.Forms.ComboBox();
            this.comboBoxRing1 = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.comboBoxBolt1 = new System.Windows.Forms.ComboBox();
            this.comboBoxArrow2 = new System.Windows.Forms.ComboBox();
            this.comboBoxBolt2 = new System.Windows.Forms.ComboBox();
            this.comboBoxArrow1 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.comboBoxLW1 = new System.Windows.Forms.ComboBox();
            this.comboBoxRW2 = new System.Windows.Forms.ComboBox();
            this.comboBoxLW2 = new System.Windows.Forms.ComboBox();
            this.comboBoxRW1 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBoxGauntlets = new System.Windows.Forms.ComboBox();
            this.comboBoxArmor = new System.Windows.Forms.ComboBox();
            this.comboBoxLeggings = new System.Windows.Forms.ComboBox();
            this.comboBoxHelm = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxUI5 = new System.Windows.Forms.ComboBox();
            this.comboBoxUI4 = new System.Windows.Forms.ComboBox();
            this.comboBoxUI3 = new System.Windows.Forms.ComboBox();
            this.comboBoxUI2 = new System.Windows.Forms.ComboBox();
            this.comboBoxUI1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.numericUpDownMC12 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC11 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMC1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxAttune12 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune11 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune10 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune9 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune8 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune7 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune6 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune5 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune4 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAttune1 = new System.Windows.Forms.ComboBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.RenameItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.MaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuantityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DurabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
            this.RefreshItems = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveItems = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.Search = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SectionContainer1 = new System.Windows.Forms.ToolStripComboBox();
            this.MaxSection = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ammount = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.dura = new System.Windows.Forms.ToolStripTextBox();
            this.SetValue = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator15 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Itemsort = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.ItemSection = new System.Windows.Forms.ComboBox();
            this.DeleteB = new System.Windows.Forms.Button();
            this.AddB = new System.Windows.Forms.Button();
            this.ReplaceB = new System.Windows.Forms.Button();
            this.ItemDurability = new System.Windows.Forms.NumericUpDown();
            this.Label23 = new System.Windows.Forms.Label();
            this.ItemID = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.ItemName = new System.Windows.Forms.TextBox();
            this.ListView2 = new System.Windows.Forms.ListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.UncheckItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UncheckAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.AddSelectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.RefreshItemList = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveitemlist = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.Searchbox2 = new System.Windows.Forms.ToolStripTextBox();
            this.Findbutton2 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.SectionContainer2 = new System.Windows.Forms.ToolStripComboBox();
            this.DBAmount = new System.Windows.Forms.ToolStripLabel();
            this.dataSetItems = new System.Data.DataSet();
            this.dataTableAttune = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.ToolStrip1.SuspendLayout();
            this.ToolStrip2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkinBrightness)).BeginInit();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Souls)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Strength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stamina2)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Humanity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Endurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stamina1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlaythrough)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vitality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Faith)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attunement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.ContextMenuStrip1.SuspendLayout();
            this.ToolStrip3.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDurability)).BeginInit();
            this.ContextMenuStrip2.SuspendLayout();
            this.ToolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAttune)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenB,
            this.ToolStripLabel11,
            this.SaveAllB,
            this.ToolStripSeparator4,
            this.ToolStripLabel10,
            this.SaveAsB,
            this.ToolStripLabel9,
            this.SlotB,
            this.ToolStripButton1,
            this.ToolStripLabel8,
            this.ToolStripButton5,
            this.ToolStripLabel7,
            this.ToolStripButton4,
            this.ToolStripSeparator16,
            this.CopyB,
            this.SwapB,
            this.toolStripLabel2,
            this.ToolStripButton3});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(861, 31);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // OpenB
            // 
            this.OpenB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xbox360ToolStripMenuItem,
            this.pS3ToolStripMenuItem,
            this.PCToolStripMenuItem});
            this.OpenB.Image = ((System.Drawing.Image)(resources.GetObject("OpenB.Image")));
            this.OpenB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OpenB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(37, 28);
            this.OpenB.Text = "ToolStripButton1";
            this.OpenB.ToolTipText = "Open Save";
            // 
            // xbox360ToolStripMenuItem
            // 
            this.xbox360ToolStripMenuItem.Name = "xbox360ToolStripMenuItem";
            this.xbox360ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.xbox360ToolStripMenuItem.Text = "Xbox360";
            this.xbox360ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // pS3ToolStripMenuItem
            // 
            this.pS3ToolStripMenuItem.Name = "pS3ToolStripMenuItem";
            this.pS3ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.pS3ToolStripMenuItem.Text = "PS3";
            this.pS3ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // PCToolStripMenuItem
            // 
            this.PCToolStripMenuItem.Name = "PCToolStripMenuItem";
            this.PCToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.PCToolStripMenuItem.Text = "PC";
            this.PCToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // ToolStripLabel11
            // 
            this.ToolStripLabel11.Name = "ToolStripLabel11";
            this.ToolStripLabel11.Size = new System.Drawing.Size(16, 28);
            this.ToolStripLabel11.Text = " | ";
            // 
            // SaveAllB
            // 
            this.SaveAllB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAllB.Image = ((System.Drawing.Image)(resources.GetObject("SaveAllB.Image")));
            this.SaveAllB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveAllB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAllB.Name = "SaveAllB";
            this.SaveAllB.Size = new System.Drawing.Size(28, 28);
            this.SaveAllB.Text = "ToolStripButton2";
            this.SaveAllB.ToolTipText = "Save All";
            this.SaveAllB.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel10
            // 
            this.ToolStripLabel10.Name = "ToolStripLabel10";
            this.ToolStripLabel10.Size = new System.Drawing.Size(16, 28);
            this.ToolStripLabel10.Text = " | ";
            // 
            // SaveAsB
            // 
            this.SaveAsB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsB.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsB.Image")));
            this.SaveAsB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveAsB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsB.Name = "SaveAsB";
            this.SaveAsB.Size = new System.Drawing.Size(28, 28);
            this.SaveAsB.Text = "ToolStripButton3";
            this.SaveAsB.ToolTipText = "Save as";
            this.SaveAsB.Click += new System.EventHandler(this.SaveAsB_Click);
            // 
            // ToolStripLabel9
            // 
            this.ToolStripLabel9.Name = "ToolStripLabel9";
            this.ToolStripLabel9.Size = new System.Drawing.Size(16, 28);
            this.ToolStripLabel9.Text = " | ";
            // 
            // SlotB
            // 
            this.SlotB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SlotB.Image = ((System.Drawing.Image)(resources.GetObject("SlotB.Image")));
            this.SlotB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SlotB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SlotB.Name = "SlotB";
            this.SlotB.Size = new System.Drawing.Size(28, 28);
            this.SlotB.Text = "Choose Save Slot";
            this.SlotB.Click += new System.EventHandler(this.SlotB_Click);
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton1.Image")));
            this.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.ToolStripButton1.Text = "Exit";
            this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // ToolStripLabel8
            // 
            this.ToolStripLabel8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripLabel8.Name = "ToolStripLabel8";
            this.ToolStripLabel8.Size = new System.Drawing.Size(16, 28);
            this.ToolStripLabel8.Text = " | ";
            // 
            // ToolStripButton5
            // 
            this.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton5.Image")));
            this.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton5.Name = "ToolStripButton5";
            this.ToolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.ToolStripButton5.Text = "View Instructions";
            this.ToolStripButton5.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // ToolStripLabel7
            // 
            this.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripLabel7.Name = "ToolStripLabel7";
            this.ToolStripLabel7.Size = new System.Drawing.Size(16, 28);
            this.ToolStripLabel7.Text = " | ";
            // 
            // ToolStripButton4
            // 
            this.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton4.Image")));
            this.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton4.Name = "ToolStripButton4";
            this.ToolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.ToolStripButton4.Text = "About";
            this.ToolStripButton4.Click += new System.EventHandler(this.ToolStripButton4_Click_1);
            // 
            // ToolStripSeparator16
            // 
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";
            this.ToolStripSeparator16.Size = new System.Drawing.Size(16, 28);
            this.ToolStripSeparator16.Text = " | ";
            this.ToolStripSeparator16.Visible = false;
            // 
            // CopyB
            // 
            this.CopyB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyB.Image = ((System.Drawing.Image)(resources.GetObject("CopyB.Image")));
            this.CopyB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyB.Name = "CopyB";
            this.CopyB.Size = new System.Drawing.Size(23, 28);
            this.CopyB.Text = "toolStripButton6";
            this.CopyB.ToolTipText = "Copy Save Slot";
            this.CopyB.Click += new System.EventHandler(this.CopyB_Click);
            // 
            // SwapB
            // 
            this.SwapB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SwapB.Image = ((System.Drawing.Image)(resources.GetObject("SwapB.Image")));
            this.SwapB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SwapB.Name = "SwapB";
            this.SwapB.Size = new System.Drawing.Size(23, 28);
            this.SwapB.Text = "toolStripButton7";
            this.SwapB.ToolTipText = "Swap Save Slots";
            this.SwapB.Click += new System.EventHandler(this.SwapB_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 28);
            this.toolStripLabel2.Text = " | ";
            // 
            // ToolStripButton3
            // 
            this.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton3.Image")));
            this.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton3.Name = "ToolStripButton3";
            this.ToolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.ToolStripButton3.Text = "Add Items";
            this.ToolStripButton3.Visible = false;
            this.ToolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar1,
            this.ToolStripSeparator1,
            this.Status});
            this.ToolStrip2.Location = new System.Drawing.Point(0, 466);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(861, 25);
            this.ToolStrip2.TabIndex = 5;
            this.ToolStrip2.Text = "ToolStrip2";
            // 
            // ToolStripProgressBar1
            // 
            this.ToolStripProgressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ToolStripProgressBar1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            this.ToolStripProgressBar1.Size = new System.Drawing.Size(150, 22);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(26, 22);
            this.Status.Text = "Idle";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPage4);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.tabPage5);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TabControl1.Location = new System.Drawing.Point(0, 34);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(861, 432);
            this.TabControl1.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.GroupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(853, 406);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Appearance";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.comboBoxHSID);
            this.GroupBox2.Controls.Add(this.comboBoxColor);
            this.GroupBox2.Controls.Add(this.comboBoxHairStyle);
            this.GroupBox2.Controls.Add(this.ComboBoxPhysique);
            this.GroupBox2.Controls.Add(this.numericUpDownSkinBrightness);
            this.GroupBox2.Controls.Add(this.textBoxHC);
            this.GroupBox2.Controls.Add(this.textBoxEC);
            this.GroupBox2.Controls.Add(this.ComboBoxGift);
            this.GroupBox2.Controls.Add(this.ComboBoxClass);
            this.GroupBox2.Controls.Add(this.label31);
            this.GroupBox2.Controls.Add(this.label29);
            this.GroupBox2.Controls.Add(this.label28);
            this.GroupBox2.Controls.Add(this.label27);
            this.GroupBox2.Controls.Add(this.label25);
            this.GroupBox2.Controls.Add(this.Label14);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Controls.Add(this.Label12);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.ComboBoxGender);
            this.GroupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(8, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(291, 311);
            this.GroupBox2.TabIndex = 132;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Character Settings";
            // 
            // comboBoxHSID
            // 
            this.comboBoxHSID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHSID.FormattingEnabled = true;
            this.comboBoxHSID.Location = new System.Drawing.Point(6, 166);
            this.comboBoxHSID.Name = "comboBoxHSID";
            this.comboBoxHSID.Size = new System.Drawing.Size(279, 23);
            this.comboBoxHSID.TabIndex = 133;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "Black",
            "Dark Brown",
            "Light Brown",
            "Dark Red",
            "Dark Blue",
            "Gray",
            "Gold",
            "Silver",
            "Dark Purple",
            "Red"});
            this.comboBoxColor.Location = new System.Drawing.Point(146, 195);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(139, 23);
            this.comboBoxColor.TabIndex = 91;
            // 
            // comboBoxHairStyle
            // 
            this.comboBoxHairStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHairStyle.FormattingEnabled = true;
            this.comboBoxHairStyle.Items.AddRange(new object[] {
            "Shaved",
            "Receding",
            "Short",
            "Swept Back",
            "Ponytail",
            "Wild",
            "Parted Center",
            "Semi-Long",
            "Curly",
            "Bobbed"});
            this.comboBoxHairStyle.Location = new System.Drawing.Point(146, 137);
            this.comboBoxHairStyle.Name = "comboBoxHairStyle";
            this.comboBoxHairStyle.Size = new System.Drawing.Size(139, 23);
            this.comboBoxHairStyle.TabIndex = 91;
            // 
            // ComboBoxPhysique
            // 
            this.ComboBoxPhysique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPhysique.FormattingEnabled = true;
            this.ComboBoxPhysique.Items.AddRange(new object[] {
            "Average",
            "Slim",
            "Very Slim",
            "Large",
            "Very Large",
            "Large Upper Body",
            "Large Lower Body",
            "Top-Heavy",
            "Tiny Head"});
            this.ComboBoxPhysique.Location = new System.Drawing.Point(146, 108);
            this.ComboBoxPhysique.Name = "ComboBoxPhysique";
            this.ComboBoxPhysique.Size = new System.Drawing.Size(139, 23);
            this.ComboBoxPhysique.TabIndex = 91;
            // 
            // numericUpDownSkinBrightness
            // 
            this.numericUpDownSkinBrightness.Location = new System.Drawing.Point(146, 280);
            this.numericUpDownSkinBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSkinBrightness.Name = "numericUpDownSkinBrightness";
            this.numericUpDownSkinBrightness.Size = new System.Drawing.Size(139, 22);
            this.numericUpDownSkinBrightness.TabIndex = 128;
            // 
            // textBoxHC
            // 
            this.textBoxHC.Location = new System.Drawing.Point(146, 224);
            this.textBoxHC.Name = "textBoxHC";
            this.textBoxHC.Size = new System.Drawing.Size(139, 22);
            this.textBoxHC.TabIndex = 129;
            // 
            // textBoxEC
            // 
            this.textBoxEC.Location = new System.Drawing.Point(146, 252);
            this.textBoxEC.Name = "textBoxEC";
            this.textBoxEC.Size = new System.Drawing.Size(139, 22);
            this.textBoxEC.TabIndex = 127;
            // 
            // ComboBoxGift
            // 
            this.ComboBoxGift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGift.FormattingEnabled = true;
            this.ComboBoxGift.Items.AddRange(new object[] {
            "None",
            "Divine Blessing",
            "Black Firebombs",
            "Twin Humanities",
            "Binoculars",
            "Pendant",
            "Master Key",
            "Tiny Being\'s Ring",
            "Old Witch\'s Ring"});
            this.ComboBoxGift.Location = new System.Drawing.Point(146, 79);
            this.ComboBoxGift.Name = "ComboBoxGift";
            this.ComboBoxGift.Size = new System.Drawing.Size(139, 23);
            this.ComboBoxGift.TabIndex = 90;
            // 
            // ComboBoxClass
            // 
            this.ComboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxClass.FormattingEnabled = true;
            this.ComboBoxClass.Items.AddRange(new object[] {
            "Warrior",
            "Knight",
            "Wanderer",
            "Thief",
            "Bandit",
            "Hunter",
            "Sorcerer",
            "Pyromancer",
            "Cleric",
            "Deprived"});
            this.ComboBoxClass.Location = new System.Drawing.Point(146, 50);
            this.ComboBoxClass.Name = "ComboBoxClass";
            this.ComboBoxClass.Size = new System.Drawing.Size(120, 23);
            this.ComboBoxClass.TabIndex = 89;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 280);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 18);
            this.label31.TabIndex = 88;
            this.label31.Text = "Skin Lightness";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(6, 253);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 18);
            this.label29.TabIndex = 88;
            this.label29.Text = "Eye Color (RGBA)";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(6, 225);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(108, 18);
            this.label28.TabIndex = 88;
            this.label28.Text = "Hair Color (RGBA)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(3, 196);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(139, 18);
            this.label27.TabIndex = 88;
            this.label27.Text = "Hair/Eye Color (Display)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(6, 138);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 18);
            this.label25.TabIndex = 88;
            this.label25.Text = "Hair Style";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(6, 109);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(56, 18);
            this.Label14.TabIndex = 88;
            this.Label14.Text = "Physique";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(6, 80);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(28, 18);
            this.Label13.TabIndex = 87;
            this.Label13.Text = "Gift";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(6, 51);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(37, 18);
            this.Label12.TabIndex = 86;
            this.Label12.Text = "Class";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, 22);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 18);
            this.Label3.TabIndex = 85;
            this.Label3.Text = "Gender";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxGender
            // 
            this.ComboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGender.FormattingEnabled = true;
            this.ComboBoxGender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.ComboBoxGender.Location = new System.Drawing.Point(146, 21);
            this.ComboBoxGender.Name = "ComboBoxGender";
            this.ComboBoxGender.Size = new System.Drawing.Size(78, 23);
            this.ComboBoxGender.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Label18);
            this.TabPage1.Controls.Add(this.Souls);
            this.TabPage1.Controls.Add(this.CheckBox1);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Controls.Add(this.Strength);
            this.TabPage1.Controls.Add(this.MaxAllB);
            this.TabPage1.Controls.Add(this.Label17);
            this.TabPage1.Controls.Add(this.Stamina2);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Controls.Add(this.label30);
            this.TabPage1.Controls.Add(this.label26);
            this.TabPage1.Controls.Add(this.Label11);
            this.TabPage1.Controls.Add(this.Resistance);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.labe1);
            this.TabPage1.Controls.Add(this.HP1);
            this.TabPage1.Controls.Add(this.Humanity);
            this.TabPage1.Controls.Add(this.HP2);
            this.TabPage1.Controls.Add(this.Label16);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.Endurance);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.Label15);
            this.TabPage1.Controls.Add(this.Stamina1);
            this.TabPage1.Controls.Add(this.numericUpDownPlaythrough);
            this.TabPage1.Controls.Add(this.numericUpDownSin);
            this.TabPage1.Controls.Add(this.Level);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.Vitality);
            this.TabPage1.Controls.Add(this.Faith);
            this.TabPage1.Controls.Add(this.Label6);
            this.TabPage1.Controls.Add(this.Label10);
            this.TabPage1.Controls.Add(this.Attunement);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.Intelligence);
            this.TabPage1.Controls.Add(this.Label9);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.Dexterity);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(853, 406);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Statistics";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(529, 57);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(42, 19);
            this.Label18.TabIndex = 123;
            this.Label18.Text = "Souls";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Souls
            // 
            this.Souls.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Souls.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Souls.Location = new System.Drawing.Point(577, 58);
            this.Souls.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Souls.Name = "Souls";
            this.Souls.Size = new System.Drawing.Size(135, 22);
            this.Souls.TabIndex = 0;
            this.Souls.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox1.Location = new System.Drawing.Point(8, 129);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(160, 19);
            this.CheckBox1.TabIndex = 122;
            this.CheckBox1.Text = "Enable All Warp Bonfires";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.ComboBoxCovenant);
            this.GroupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(271, 41);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(184, 50);
            this.GroupBox3.TabIndex = 89;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Covenant";
            // 
            // ComboBoxCovenant
            // 
            this.ComboBoxCovenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCovenant.FormattingEnabled = true;
            this.ComboBoxCovenant.Items.AddRange(new object[] {
            "None",
            "Way of White",
            "Princess\'s Guard ",
            "Warrior of Sunlight",
            "Darkwraith",
            "Path of Dragon",
            "Gravelord Servant",
            "Forest Hunter",
            "Darkmoon Blade",
            "Chaos Servant"});
            this.ComboBoxCovenant.Location = new System.Drawing.Point(6, 17);
            this.ComboBoxCovenant.Name = "ComboBoxCovenant";
            this.ComboBoxCovenant.Size = new System.Drawing.Size(162, 23);
            this.ComboBoxCovenant.TabIndex = 0;
            // 
            // Strength
            // 
            this.Strength.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Strength.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Strength.Location = new System.Drawing.Point(637, 154);
            this.Strength.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(76, 22);
            this.Strength.TabIndex = 99;
            this.Strength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaxAllB
            // 
            this.MaxAllB.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAllB.Location = new System.Drawing.Point(271, 333);
            this.MaxAllB.Name = "MaxAllB";
            this.MaxAllB.Size = new System.Drawing.Size(442, 57);
            this.MaxAllB.TabIndex = 118;
            this.MaxAllB.Text = "Max All Statistics";
            this.MaxAllB.UseVisualStyleBackColor = true;
            this.MaxAllB.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(427, 215);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(11, 15);
            this.Label17.TabIndex = 116;
            this.Label17.Text = "/";
            // 
            // Stamina2
            // 
            this.Stamina2.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Stamina2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stamina2.Location = new System.Drawing.Point(443, 209);
            this.Stamina2.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Stamina2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Stamina2.Name = "Stamina2";
            this.Stamina2.Size = new System.Drawing.Size(76, 22);
            this.Stamina2.TabIndex = 115;
            this.Stamina2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CharacterName);
            this.GroupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(8, 41);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(228, 50);
            this.GroupBox1.TabIndex = 87;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Character Name";
            // 
            // CharacterName
            // 
            this.CharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharacterName.Location = new System.Drawing.Point(6, 19);
            this.CharacterName.MaxLength = 13;
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.Size = new System.Drawing.Size(216, 22);
            this.CharacterName.TabIndex = 0;
            this.CharacterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label19.Location = new System.Drawing.Point(100, 41);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(0, 15);
            this.Label19.TabIndex = 117;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(268, 103);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(73, 15);
            this.label30.TabIndex = 107;
            this.label30.Text = "Playthrough";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(268, 131);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 15);
            this.label26.TabIndex = 107;
            this.label26.Text = "Indictments";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label26.Visible = false;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(268, 156);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(36, 15);
            this.Label11.TabIndex = 107;
            this.Label11.Text = "Level";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Resistance
            // 
            this.Resistance.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Resistance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resistance.Location = new System.Drawing.Point(636, 207);
            this.Resistance.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Resistance.Name = "Resistance";
            this.Resistance.Size = new System.Drawing.Size(76, 22);
            this.Resistance.TabIndex = 114;
            this.Resistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(268, 182);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 15);
            this.Label1.TabIndex = 86;
            this.Label1.Text = "HP";
            // 
            // labe1
            // 
            this.labe1.AutoSize = true;
            this.labe1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labe1.Location = new System.Drawing.Point(560, 208);
            this.labe1.Name = "labe1";
            this.labe1.Size = new System.Drawing.Size(65, 15);
            this.labe1.TabIndex = 113;
            this.labe1.Text = "Resistance";
            this.labe1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HP1
            // 
            this.HP1.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.HP1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HP1.Location = new System.Drawing.Point(342, 183);
            this.HP1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.HP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.HP1.Name = "HP1";
            this.HP1.Size = new System.Drawing.Size(76, 22);
            this.HP1.TabIndex = 88;
            this.HP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Humanity
            // 
            this.Humanity.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Humanity.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Humanity.Location = new System.Drawing.Point(636, 285);
            this.Humanity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Humanity.Name = "Humanity";
            this.Humanity.Size = new System.Drawing.Size(76, 22);
            this.Humanity.TabIndex = 112;
            this.Humanity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HP2
            // 
            this.HP2.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.HP2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HP2.Location = new System.Drawing.Point(443, 182);
            this.HP2.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.HP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.HP2.Name = "HP2";
            this.HP2.Size = new System.Drawing.Size(76, 22);
            this.HP2.TabIndex = 90;
            this.HP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(561, 286);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(59, 15);
            this.Label16.TabIndex = 111;
            this.Label16.Text = "Humanity";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(427, 185);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(11, 15);
            this.Label2.TabIndex = 91;
            this.Label2.Text = "/";
            // 
            // Endurance
            // 
            this.Endurance.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Endurance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Endurance.Location = new System.Drawing.Point(342, 287);
            this.Endurance.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Endurance.Name = "Endurance";
            this.Endurance.Size = new System.Drawing.Size(76, 22);
            this.Endurance.TabIndex = 110;
            this.Endurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(268, 208);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 15);
            this.Label4.TabIndex = 92;
            this.Label4.Text = "Stamina";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(268, 286);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(64, 15);
            this.Label15.TabIndex = 109;
            this.Label15.Text = "Endurance";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Stamina1
            // 
            this.Stamina1.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Stamina1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stamina1.Location = new System.Drawing.Point(342, 209);
            this.Stamina1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Stamina1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Stamina1.Name = "Stamina1";
            this.Stamina1.Size = new System.Drawing.Size(76, 22);
            this.Stamina1.TabIndex = 93;
            this.Stamina1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownPlaythrough
            // 
            this.numericUpDownPlaythrough.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.numericUpDownPlaythrough.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPlaythrough.Location = new System.Drawing.Point(342, 101);
            this.numericUpDownPlaythrough.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDownPlaythrough.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPlaythrough.Name = "numericUpDownPlaythrough";
            this.numericUpDownPlaythrough.Size = new System.Drawing.Size(76, 22);
            this.numericUpDownPlaythrough.TabIndex = 108;
            this.numericUpDownPlaythrough.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPlaythrough.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownSin
            // 
            this.numericUpDownSin.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.numericUpDownSin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSin.Location = new System.Drawing.Point(342, 129);
            this.numericUpDownSin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownSin.Name = "numericUpDownSin";
            this.numericUpDownSin.Size = new System.Drawing.Size(76, 22);
            this.numericUpDownSin.TabIndex = 108;
            this.numericUpDownSin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSin.Visible = false;
            // 
            // Level
            // 
            this.Level.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Level.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(342, 156);
            this.Level.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(76, 22);
            this.Level.TabIndex = 108;
            this.Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(268, 234);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(44, 15);
            this.Label5.TabIndex = 94;
            this.Label5.Text = "Vitality";
            // 
            // Vitality
            // 
            this.Vitality.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Vitality.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vitality.Location = new System.Drawing.Point(342, 235);
            this.Vitality.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Vitality.Name = "Vitality";
            this.Vitality.Size = new System.Drawing.Size(76, 22);
            this.Vitality.TabIndex = 95;
            this.Vitality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Faith
            // 
            this.Faith.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Faith.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Faith.Location = new System.Drawing.Point(636, 259);
            this.Faith.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Faith.Name = "Faith";
            this.Faith.Size = new System.Drawing.Size(76, 22);
            this.Faith.TabIndex = 106;
            this.Faith.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(268, 260);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(71, 15);
            this.Label6.TabIndex = 96;
            this.Label6.Text = "Attunement";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(561, 260);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(34, 15);
            this.Label10.TabIndex = 105;
            this.Label10.Text = "Faith";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Attunement
            // 
            this.Attunement.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Attunement.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attunement.Location = new System.Drawing.Point(342, 261);
            this.Attunement.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Attunement.Name = "Attunement";
            this.Attunement.Size = new System.Drawing.Size(76, 22);
            this.Attunement.TabIndex = 97;
            this.Attunement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(560, 156);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(53, 15);
            this.Label7.TabIndex = 98;
            this.Label7.Text = "Strength";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Intelligence
            // 
            this.Intelligence.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Intelligence.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intelligence.Location = new System.Drawing.Point(636, 233);
            this.Intelligence.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Intelligence.Name = "Intelligence";
            this.Intelligence.Size = new System.Drawing.Size(76, 22);
            this.Intelligence.TabIndex = 103;
            this.Intelligence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(561, 234);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(69, 15);
            this.Label9.TabIndex = 102;
            this.Label9.Text = "Intelligence";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(560, 182);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(55, 15);
            this.Label8.TabIndex = 100;
            this.Label8.Text = "Dexterity";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dexterity
            // 
            this.Dexterity.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.Dexterity.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dexterity.Location = new System.Drawing.Point(637, 181);
            this.Dexterity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Dexterity.Name = "Dexterity";
            this.Dexterity.Size = new System.Drawing.Size(76, 22);
            this.Dexterity.TabIndex = 101;
            this.Dexterity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox11);
            this.tabPage5.Controls.Add(this.groupBox9);
            this.tabPage5.Controls.Add(this.groupBox8);
            this.tabPage5.Controls.Add(this.groupBox7);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(853, 406);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Equipment";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBoxRing2);
            this.groupBox11.Controls.Add(this.comboBoxRing1);
            this.groupBox11.Location = new System.Drawing.Point(565, 327);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(200, 76);
            this.groupBox11.TabIndex = 2;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Rings";
            // 
            // comboBoxRing2
            // 
            this.comboBoxRing2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRing2.FormattingEnabled = true;
            this.comboBoxRing2.Location = new System.Drawing.Point(6, 46);
            this.comboBoxRing2.Name = "comboBoxRing2";
            this.comboBoxRing2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxRing2.TabIndex = 1;
            // 
            // comboBoxRing1
            // 
            this.comboBoxRing1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRing1.FormattingEnabled = true;
            this.comboBoxRing1.Location = new System.Drawing.Point(6, 19);
            this.comboBoxRing1.Name = "comboBoxRing1";
            this.comboBoxRing1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxRing1.TabIndex = 1;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label37);
            this.groupBox9.Controls.Add(this.label39);
            this.groupBox9.Controls.Add(this.comboBoxBolt1);
            this.groupBox9.Controls.Add(this.comboBoxArrow2);
            this.groupBox9.Controls.Add(this.comboBoxBolt2);
            this.groupBox9.Controls.Add(this.comboBoxArrow1);
            this.groupBox9.Location = new System.Drawing.Point(565, 165);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 156);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Ammo";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 83);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(30, 13);
            this.label37.TabIndex = 2;
            this.label37.Text = "Bolts";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(39, 13);
            this.label39.TabIndex = 2;
            this.label39.Text = "Arrows";
            // 
            // comboBoxBolt1
            // 
            this.comboBoxBolt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBolt1.FormattingEnabled = true;
            this.comboBoxBolt1.Location = new System.Drawing.Point(6, 99);
            this.comboBoxBolt1.Name = "comboBoxBolt1";
            this.comboBoxBolt1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxBolt1.TabIndex = 1;
            // 
            // comboBoxArrow2
            // 
            this.comboBoxArrow2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArrow2.FormattingEnabled = true;
            this.comboBoxArrow2.Location = new System.Drawing.Point(6, 59);
            this.comboBoxArrow2.Name = "comboBoxArrow2";
            this.comboBoxArrow2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxArrow2.TabIndex = 1;
            // 
            // comboBoxBolt2
            // 
            this.comboBoxBolt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBolt2.FormattingEnabled = true;
            this.comboBoxBolt2.Location = new System.Drawing.Point(6, 126);
            this.comboBoxBolt2.Name = "comboBoxBolt2";
            this.comboBoxBolt2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxBolt2.TabIndex = 1;
            // 
            // comboBoxArrow1
            // 
            this.comboBoxArrow1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArrow1.FormattingEnabled = true;
            this.comboBoxArrow1.Location = new System.Drawing.Point(6, 32);
            this.comboBoxArrow1.Name = "comboBoxArrow1";
            this.comboBoxArrow1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxArrow1.TabIndex = 1;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.label40);
            this.groupBox8.Controls.Add(this.comboBoxLW1);
            this.groupBox8.Controls.Add(this.comboBoxRW2);
            this.groupBox8.Controls.Add(this.comboBoxLW2);
            this.groupBox8.Controls.Add(this.comboBoxRW1);
            this.groupBox8.Location = new System.Drawing.Point(565, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 156);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Weapons";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 83);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(25, 13);
            this.label38.TabIndex = 2;
            this.label38.Text = "Left";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(32, 13);
            this.label40.TabIndex = 2;
            this.label40.Text = "Right";
            // 
            // comboBoxLW1
            // 
            this.comboBoxLW1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLW1.FormattingEnabled = true;
            this.comboBoxLW1.Location = new System.Drawing.Point(6, 99);
            this.comboBoxLW1.Name = "comboBoxLW1";
            this.comboBoxLW1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxLW1.TabIndex = 1;
            // 
            // comboBoxRW2
            // 
            this.comboBoxRW2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRW2.FormattingEnabled = true;
            this.comboBoxRW2.Location = new System.Drawing.Point(6, 59);
            this.comboBoxRW2.Name = "comboBoxRW2";
            this.comboBoxRW2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxRW2.TabIndex = 1;
            // 
            // comboBoxLW2
            // 
            this.comboBoxLW2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLW2.FormattingEnabled = true;
            this.comboBoxLW2.Location = new System.Drawing.Point(6, 126);
            this.comboBoxLW2.Name = "comboBoxLW2";
            this.comboBoxLW2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxLW2.TabIndex = 1;
            // 
            // comboBoxRW1
            // 
            this.comboBoxRW1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRW1.FormattingEnabled = true;
            this.comboBoxRW1.Location = new System.Drawing.Point(6, 32);
            this.comboBoxRW1.Name = "comboBoxRW1";
            this.comboBoxRW1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxRW1.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label36);
            this.groupBox7.Controls.Add(this.label35);
            this.groupBox7.Controls.Add(this.label34);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.comboBoxGauntlets);
            this.groupBox7.Controls.Add(this.comboBoxArmor);
            this.groupBox7.Controls.Add(this.comboBoxLeggings);
            this.groupBox7.Controls.Add(this.comboBoxHelm);
            this.groupBox7.Location = new System.Drawing.Point(359, 165);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 184);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Apparel";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 138);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(30, 13);
            this.label36.TabIndex = 2;
            this.label36.Text = "Legs";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 98);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 13);
            this.label35.TabIndex = 2;
            this.label35.Text = "Arms";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(34, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Chest";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(33, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Head";
            // 
            // comboBoxGauntlets
            // 
            this.comboBoxGauntlets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGauntlets.FormattingEnabled = true;
            this.comboBoxGauntlets.Location = new System.Drawing.Point(6, 114);
            this.comboBoxGauntlets.Name = "comboBoxGauntlets";
            this.comboBoxGauntlets.Size = new System.Drawing.Size(188, 21);
            this.comboBoxGauntlets.TabIndex = 1;
            // 
            // comboBoxArmor
            // 
            this.comboBoxArmor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArmor.FormattingEnabled = true;
            this.comboBoxArmor.Location = new System.Drawing.Point(6, 74);
            this.comboBoxArmor.Name = "comboBoxArmor";
            this.comboBoxArmor.Size = new System.Drawing.Size(188, 21);
            this.comboBoxArmor.TabIndex = 1;
            // 
            // comboBoxLeggings
            // 
            this.comboBoxLeggings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLeggings.FormattingEnabled = true;
            this.comboBoxLeggings.Location = new System.Drawing.Point(6, 154);
            this.comboBoxLeggings.Name = "comboBoxLeggings";
            this.comboBoxLeggings.Size = new System.Drawing.Size(188, 21);
            this.comboBoxLeggings.TabIndex = 1;
            // 
            // comboBoxHelm
            // 
            this.comboBoxHelm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHelm.FormattingEnabled = true;
            this.comboBoxHelm.Location = new System.Drawing.Point(6, 32);
            this.comboBoxHelm.Name = "comboBoxHelm";
            this.comboBoxHelm.Size = new System.Drawing.Size(188, 21);
            this.comboBoxHelm.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxUI5);
            this.groupBox6.Controls.Add(this.comboBoxUI4);
            this.groupBox6.Controls.Add(this.comboBoxUI3);
            this.groupBox6.Controls.Add(this.comboBoxUI2);
            this.groupBox6.Controls.Add(this.comboBoxUI1);
            this.groupBox6.Location = new System.Drawing.Point(359, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 156);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usable Items";
            // 
            // comboBoxUI5
            // 
            this.comboBoxUI5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUI5.FormattingEnabled = true;
            this.comboBoxUI5.Location = new System.Drawing.Point(6, 126);
            this.comboBoxUI5.Name = "comboBoxUI5";
            this.comboBoxUI5.Size = new System.Drawing.Size(188, 21);
            this.comboBoxUI5.TabIndex = 1;
            // 
            // comboBoxUI4
            // 
            this.comboBoxUI4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUI4.FormattingEnabled = true;
            this.comboBoxUI4.Location = new System.Drawing.Point(6, 99);
            this.comboBoxUI4.Name = "comboBoxUI4";
            this.comboBoxUI4.Size = new System.Drawing.Size(188, 21);
            this.comboBoxUI4.TabIndex = 1;
            // 
            // comboBoxUI3
            // 
            this.comboBoxUI3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUI3.FormattingEnabled = true;
            this.comboBoxUI3.Location = new System.Drawing.Point(6, 72);
            this.comboBoxUI3.Name = "comboBoxUI3";
            this.comboBoxUI3.Size = new System.Drawing.Size(188, 21);
            this.comboBoxUI3.TabIndex = 1;
            // 
            // comboBoxUI2
            // 
            this.comboBoxUI2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUI2.FormattingEnabled = true;
            this.comboBoxUI2.Location = new System.Drawing.Point(6, 45);
            this.comboBoxUI2.Name = "comboBoxUI2";
            this.comboBoxUI2.Size = new System.Drawing.Size(188, 21);
            this.comboBoxUI2.TabIndex = 1;
            // 
            // comboBoxUI1
            // 
            this.comboBoxUI1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUI1.FormattingEnabled = true;
            this.comboBoxUI1.Location = new System.Drawing.Point(6, 19);
            this.comboBoxUI1.Name = "comboBoxUI1";
            this.comboBoxUI1.Size = new System.Drawing.Size(188, 21);
            this.comboBoxUI1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.numericUpDownMC12);
            this.groupBox5.Controls.Add(this.numericUpDownMC11);
            this.groupBox5.Controls.Add(this.numericUpDownMC10);
            this.groupBox5.Controls.Add(this.numericUpDownMC9);
            this.groupBox5.Controls.Add(this.numericUpDownMC8);
            this.groupBox5.Controls.Add(this.numericUpDownMC7);
            this.groupBox5.Controls.Add(this.numericUpDownMC6);
            this.groupBox5.Controls.Add(this.numericUpDownMC5);
            this.groupBox5.Controls.Add(this.numericUpDownMC4);
            this.groupBox5.Controls.Add(this.numericUpDownMC3);
            this.groupBox5.Controls.Add(this.numericUpDownMC2);
            this.groupBox5.Controls.Add(this.numericUpDownMC1);
            this.groupBox5.Controls.Add(this.comboBoxAttune12);
            this.groupBox5.Controls.Add(this.comboBoxAttune11);
            this.groupBox5.Controls.Add(this.comboBoxAttune10);
            this.groupBox5.Controls.Add(this.comboBoxAttune9);
            this.groupBox5.Controls.Add(this.comboBoxAttune8);
            this.groupBox5.Controls.Add(this.comboBoxAttune7);
            this.groupBox5.Controls.Add(this.comboBoxAttune6);
            this.groupBox5.Controls.Add(this.comboBoxAttune5);
            this.groupBox5.Controls.Add(this.comboBoxAttune4);
            this.groupBox5.Controls.Add(this.comboBoxAttune3);
            this.groupBox5.Controls.Add(this.comboBoxAttune2);
            this.groupBox5.Controls.Add(this.comboBoxAttune1);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(350, 346);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Attunement";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.SystemColors.Window;
            this.label32.Location = new System.Drawing.Point(270, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 13);
            this.label32.TabIndex = 3;
            this.label32.Text = "Remaining";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownMC12
            // 
            this.numericUpDownMC12.Location = new System.Drawing.Point(271, 317);
            this.numericUpDownMC12.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC12.Name = "numericUpDownMC12";
            this.numericUpDownMC12.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC12.TabIndex = 2;
            // 
            // numericUpDownMC11
            // 
            this.numericUpDownMC11.Location = new System.Drawing.Point(271, 290);
            this.numericUpDownMC11.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC11.Name = "numericUpDownMC11";
            this.numericUpDownMC11.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC11.TabIndex = 2;
            // 
            // numericUpDownMC10
            // 
            this.numericUpDownMC10.Location = new System.Drawing.Point(271, 263);
            this.numericUpDownMC10.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC10.Name = "numericUpDownMC10";
            this.numericUpDownMC10.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC10.TabIndex = 2;
            // 
            // numericUpDownMC9
            // 
            this.numericUpDownMC9.Location = new System.Drawing.Point(271, 236);
            this.numericUpDownMC9.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC9.Name = "numericUpDownMC9";
            this.numericUpDownMC9.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC9.TabIndex = 2;
            // 
            // numericUpDownMC8
            // 
            this.numericUpDownMC8.Location = new System.Drawing.Point(271, 209);
            this.numericUpDownMC8.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC8.Name = "numericUpDownMC8";
            this.numericUpDownMC8.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC8.TabIndex = 2;
            // 
            // numericUpDownMC7
            // 
            this.numericUpDownMC7.Location = new System.Drawing.Point(271, 182);
            this.numericUpDownMC7.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC7.Name = "numericUpDownMC7";
            this.numericUpDownMC7.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC7.TabIndex = 2;
            // 
            // numericUpDownMC6
            // 
            this.numericUpDownMC6.Location = new System.Drawing.Point(271, 155);
            this.numericUpDownMC6.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC6.Name = "numericUpDownMC6";
            this.numericUpDownMC6.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC6.TabIndex = 2;
            // 
            // numericUpDownMC5
            // 
            this.numericUpDownMC5.Location = new System.Drawing.Point(271, 128);
            this.numericUpDownMC5.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC5.Name = "numericUpDownMC5";
            this.numericUpDownMC5.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC5.TabIndex = 2;
            // 
            // numericUpDownMC4
            // 
            this.numericUpDownMC4.Location = new System.Drawing.Point(271, 101);
            this.numericUpDownMC4.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC4.Name = "numericUpDownMC4";
            this.numericUpDownMC4.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC4.TabIndex = 2;
            // 
            // numericUpDownMC3
            // 
            this.numericUpDownMC3.Location = new System.Drawing.Point(271, 74);
            this.numericUpDownMC3.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC3.Name = "numericUpDownMC3";
            this.numericUpDownMC3.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC3.TabIndex = 2;
            // 
            // numericUpDownMC2
            // 
            this.numericUpDownMC2.Location = new System.Drawing.Point(271, 47);
            this.numericUpDownMC2.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC2.Name = "numericUpDownMC2";
            this.numericUpDownMC2.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC2.TabIndex = 2;
            // 
            // numericUpDownMC1
            // 
            this.numericUpDownMC1.Location = new System.Drawing.Point(271, 20);
            this.numericUpDownMC1.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownMC1.Name = "numericUpDownMC1";
            this.numericUpDownMC1.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownMC1.TabIndex = 2;
            // 
            // comboBoxAttune12
            // 
            this.comboBoxAttune12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune12.FormattingEnabled = true;
            this.comboBoxAttune12.Location = new System.Drawing.Point(6, 316);
            this.comboBoxAttune12.Name = "comboBoxAttune12";
            this.comboBoxAttune12.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune12.TabIndex = 1;
            // 
            // comboBoxAttune11
            // 
            this.comboBoxAttune11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune11.FormattingEnabled = true;
            this.comboBoxAttune11.Location = new System.Drawing.Point(6, 289);
            this.comboBoxAttune11.Name = "comboBoxAttune11";
            this.comboBoxAttune11.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune11.TabIndex = 1;
            // 
            // comboBoxAttune10
            // 
            this.comboBoxAttune10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune10.FormattingEnabled = true;
            this.comboBoxAttune10.Location = new System.Drawing.Point(6, 262);
            this.comboBoxAttune10.Name = "comboBoxAttune10";
            this.comboBoxAttune10.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune10.TabIndex = 1;
            // 
            // comboBoxAttune9
            // 
            this.comboBoxAttune9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune9.FormattingEnabled = true;
            this.comboBoxAttune9.Location = new System.Drawing.Point(6, 235);
            this.comboBoxAttune9.Name = "comboBoxAttune9";
            this.comboBoxAttune9.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune9.TabIndex = 1;
            // 
            // comboBoxAttune8
            // 
            this.comboBoxAttune8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune8.FormattingEnabled = true;
            this.comboBoxAttune8.Location = new System.Drawing.Point(6, 208);
            this.comboBoxAttune8.Name = "comboBoxAttune8";
            this.comboBoxAttune8.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune8.TabIndex = 1;
            // 
            // comboBoxAttune7
            // 
            this.comboBoxAttune7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune7.FormattingEnabled = true;
            this.comboBoxAttune7.Location = new System.Drawing.Point(6, 181);
            this.comboBoxAttune7.Name = "comboBoxAttune7";
            this.comboBoxAttune7.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune7.TabIndex = 1;
            // 
            // comboBoxAttune6
            // 
            this.comboBoxAttune6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune6.FormattingEnabled = true;
            this.comboBoxAttune6.Location = new System.Drawing.Point(6, 154);
            this.comboBoxAttune6.Name = "comboBoxAttune6";
            this.comboBoxAttune6.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune6.TabIndex = 1;
            // 
            // comboBoxAttune5
            // 
            this.comboBoxAttune5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune5.FormattingEnabled = true;
            this.comboBoxAttune5.Location = new System.Drawing.Point(6, 127);
            this.comboBoxAttune5.Name = "comboBoxAttune5";
            this.comboBoxAttune5.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune5.TabIndex = 1;
            // 
            // comboBoxAttune4
            // 
            this.comboBoxAttune4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune4.FormattingEnabled = true;
            this.comboBoxAttune4.Location = new System.Drawing.Point(6, 100);
            this.comboBoxAttune4.Name = "comboBoxAttune4";
            this.comboBoxAttune4.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune4.TabIndex = 1;
            // 
            // comboBoxAttune3
            // 
            this.comboBoxAttune3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune3.FormattingEnabled = true;
            this.comboBoxAttune3.Location = new System.Drawing.Point(6, 73);
            this.comboBoxAttune3.Name = "comboBoxAttune3";
            this.comboBoxAttune3.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune3.TabIndex = 1;
            // 
            // comboBoxAttune2
            // 
            this.comboBoxAttune2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune2.FormattingEnabled = true;
            this.comboBoxAttune2.Location = new System.Drawing.Point(6, 46);
            this.comboBoxAttune2.Name = "comboBoxAttune2";
            this.comboBoxAttune2.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune2.TabIndex = 1;
            // 
            // comboBoxAttune1
            // 
            this.comboBoxAttune1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttune1.FormattingEnabled = true;
            this.comboBoxAttune1.Location = new System.Drawing.Point(6, 19);
            this.comboBoxAttune1.Name = "comboBoxAttune1";
            this.comboBoxAttune1.Size = new System.Drawing.Size(259, 21);
            this.comboBoxAttune1.TabIndex = 1;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.ListView1);
            this.TabPage2.Controls.Add(this.ToolStrip3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(853, 406);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Inventory";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            this.ListView1.CheckBoxes = true;
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader7});
            this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.HideSelection = false;
            this.ListView1.Location = new System.Drawing.Point(3, 34);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(847, 369);
            this.ListView1.TabIndex = 125;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this.ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Tag = "String";
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 250;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Tag = "NumericHex";
            this.ColumnHeader2.Text = "Item ID";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 125;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Tag = "NumericDec";
            this.ColumnHeader3.Text = "Quantity";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Tag = "NumericDec";
            this.ColumnHeader4.Text = "Durability";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Tag = "NumericDec";
            this.ColumnHeader9.Text = "Index";
            this.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader9.Width = 50;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Tag = "String";
            this.ColumnHeader10.Text = "Section";
            this.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader10.Width = 150;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Tag = "NumericHex";
            this.ColumnHeader7.Text = "Offset";
            this.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader7.Width = 80;
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteItemToolStripMenuItem,
            this.ToolStripSeparator13,
            this.RenameItemToolStripMenuItem,
            this.ToolStripSeparator14,
            this.MaxToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(145, 82);
            // 
            // DeleteItemToolStripMenuItem
            // 
            this.DeleteItemToolStripMenuItem.Name = "DeleteItemToolStripMenuItem";
            this.DeleteItemToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.DeleteItemToolStripMenuItem.Text = "Delete";
            this.DeleteItemToolStripMenuItem.Click += new System.EventHandler(this.DeleteItemToolStripMenuItem_Click);
            // 
            // ToolStripSeparator13
            // 
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";
            this.ToolStripSeparator13.Size = new System.Drawing.Size(141, 6);
            // 
            // RenameItemToolStripMenuItem
            // 
            this.RenameItemToolStripMenuItem.Name = "RenameItemToolStripMenuItem";
            this.RenameItemToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RenameItemToolStripMenuItem.Text = "Rename Item";
            this.RenameItemToolStripMenuItem.Click += new System.EventHandler(this.RenameItemToolStripMenuItem_Click);
            // 
            // ToolStripSeparator14
            // 
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";
            this.ToolStripSeparator14.Size = new System.Drawing.Size(141, 6);
            // 
            // MaxToolStripMenuItem
            // 
            this.MaxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuantityToolStripMenuItem,
            this.DurabilityToolStripMenuItem});
            this.MaxToolStripMenuItem.Name = "MaxToolStripMenuItem";
            this.MaxToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.MaxToolStripMenuItem.Text = "Max ";
            // 
            // QuantityToolStripMenuItem
            // 
            this.QuantityToolStripMenuItem.Name = "QuantityToolStripMenuItem";
            this.QuantityToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.QuantityToolStripMenuItem.Text = "Quantity";
            this.QuantityToolStripMenuItem.Click += new System.EventHandler(this.QuantityToolStripMenuItem_Click);
            // 
            // DurabilityToolStripMenuItem
            // 
            this.DurabilityToolStripMenuItem.Name = "DurabilityToolStripMenuItem";
            this.DurabilityToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.DurabilityToolStripMenuItem.Text = "Durability";
            this.DurabilityToolStripMenuItem.Click += new System.EventHandler(this.DurabilityToolStripMenuItem_Click);
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.BackColor = System.Drawing.Color.Gainsboro;
            this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshItems,
            this.ToolStripSeparator11,
            this.SaveItems,
            this.ToolStripSeparator2,
            this.searchBox,
            this.Search,
            this.ToolStripSeparator3,
            this.ToolStripLabel1,
            this.SectionContainer1,
            this.MaxSection,
            this.ToolStripSeparator9,
            this.ToolStripLabel3,
            this.ammount,
            this.ToolStripSeparator10,
            this.ToolStripLabel5,
            this.dura,
            this.SetValue,
            this.ToolStripSeparator15,
            this.ToolStripButton2});
            this.ToolStrip3.Location = new System.Drawing.Point(3, 3);
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.Size = new System.Drawing.Size(847, 31);
            this.ToolStrip3.TabIndex = 3;
            this.ToolStrip3.Text = "Refresh Items";
            // 
            // RefreshItems
            // 
            this.RefreshItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshItems.Image = ((System.Drawing.Image)(resources.GetObject("RefreshItems.Image")));
            this.RefreshItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshItems.Name = "RefreshItems";
            this.RefreshItems.Size = new System.Drawing.Size(28, 28);
            this.RefreshItems.Text = "Refresh Items";
            this.RefreshItems.Click += new System.EventHandler(this.RefreshItems_Click);
            // 
            // ToolStripSeparator11
            // 
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            this.ToolStripSeparator11.Size = new System.Drawing.Size(6, 31);
            // 
            // SaveItems
            // 
            this.SaveItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveItems.Image = ((System.Drawing.Image)(resources.GetObject("SaveItems.Image")));
            this.SaveItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveItems.Name = "SaveItems";
            this.SaveItems.Size = new System.Drawing.Size(28, 28);
            this.SaveItems.Text = "Save Changes";
            this.SaveItems.Click += new System.EventHandler(this.SaveItems_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.AutoSize = false;
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(200, 31);
            this.searchBox.ToolTipText = "Enter name,id ,index or section to Search";
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // Search
            // 
            this.Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Search.Image = ((System.Drawing.Image)(resources.GetObject("Search.Image")));
            this.Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(28, 28);
            this.Search.Text = "Search for item";
            this.Search.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(32, 28);
            this.ToolStripLabel1.Text = "View";
            // 
            // SectionContainer1
            // 
            this.SectionContainer1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionContainer1.Name = "SectionContainer1";
            this.SectionContainer1.Size = new System.Drawing.Size(150, 31);
            this.SectionContainer1.ToolTipText = "Section to View";
            this.SectionContainer1.SelectedIndexChanged += new System.EventHandler(this.SectionContainer1_SelectedIndexChanged);
            // 
            // MaxSection
            // 
            this.MaxSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MaxSection.Image = ((System.Drawing.Image)(resources.GetObject("MaxSection.Image")));
            this.MaxSection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MaxSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MaxSection.Name = "MaxSection";
            this.MaxSection.Size = new System.Drawing.Size(28, 28);
            this.MaxSection.Text = "Max out Quanity of this section";
            this.MaxSection.Click += new System.EventHandler(this.MaxSection_Click);
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel3
            // 
            this.ToolStripLabel3.Name = "ToolStripLabel3";
            this.ToolStripLabel3.Size = new System.Drawing.Size(53, 28);
            this.ToolStripLabel3.Text = "Quantity";
            // 
            // ammount
            // 
            this.ammount.MaxLength = 3;
            this.ammount.Name = "ammount";
            this.ammount.Size = new System.Drawing.Size(50, 31);
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel5
            // 
            this.ToolStripLabel5.Name = "ToolStripLabel5";
            this.ToolStripLabel5.Size = new System.Drawing.Size(58, 28);
            this.ToolStripLabel5.Text = "Durability";
            // 
            // dura
            // 
            this.dura.MaxLength = 4;
            this.dura.Name = "dura";
            this.dura.Size = new System.Drawing.Size(50, 31);
            // 
            // SetValue
            // 
            this.SetValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetValue.Image = ((System.Drawing.Image)(resources.GetObject("SetValue.Image")));
            this.SetValue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SetValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetValue.Name = "SetValue";
            this.SetValue.Size = new System.Drawing.Size(28, 28);
            this.SetValue.Text = "Set Values";
            this.SetValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // ToolStripSeparator15
            // 
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";
            this.ToolStripSeparator15.Size = new System.Drawing.Size(16, 28);
            this.ToolStripSeparator15.Text = " | ";
            // 
            // ToolStripButton2
            // 
            this.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton2.Image")));
            this.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton2.Name = "ToolStripButton2";
            this.ToolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.ToolStripButton2.Text = "Trash containing the removed items";
            this.ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click_1);
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.GroupBox4);
            this.TabPage3.Controls.Add(this.ListView2);
            this.TabPage3.Controls.Add(this.ToolStrip4);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(853, 406);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Item DataBase";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Itemsort);
            this.GroupBox4.Controls.Add(this.Label22);
            this.GroupBox4.Controls.Add(this.Label24);
            this.GroupBox4.Controls.Add(this.ItemSection);
            this.GroupBox4.Controls.Add(this.DeleteB);
            this.GroupBox4.Controls.Add(this.AddB);
            this.GroupBox4.Controls.Add(this.ReplaceB);
            this.GroupBox4.Controls.Add(this.ItemDurability);
            this.GroupBox4.Controls.Add(this.Label23);
            this.GroupBox4.Controls.Add(this.ItemID);
            this.GroupBox4.Controls.Add(this.Label21);
            this.GroupBox4.Controls.Add(this.Label20);
            this.GroupBox4.Controls.Add(this.ItemName);
            this.GroupBox4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox4.Location = new System.Drawing.Point(645, 34);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(200, 359);
            this.GroupBox4.TabIndex = 128;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Item DataBase Information";
            // 
            // Itemsort
            // 
            this.Itemsort.Location = new System.Drawing.Point(6, 166);
            this.Itemsort.MaxLength = 6;
            this.Itemsort.Name = "Itemsort";
            this.Itemsort.Size = new System.Drawing.Size(188, 22);
            this.Itemsort.TabIndex = 15;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(6, 191);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(79, 15);
            this.Label22.TabIndex = 13;
            this.Label22.Text = "Item Section :";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(6, 148);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(67, 15);
            this.Label24.TabIndex = 14;
            this.Label24.Text = "Sort Value :";
            // 
            // ItemSection
            // 
            this.ItemSection.FormattingEnabled = true;
            this.ItemSection.Location = new System.Drawing.Point(6, 209);
            this.ItemSection.MaxDropDownItems = 16;
            this.ItemSection.Name = "ItemSection";
            this.ItemSection.Size = new System.Drawing.Size(188, 23);
            this.ItemSection.TabIndex = 12;
            // 
            // DeleteB
            // 
            this.DeleteB.Enabled = false;
            this.DeleteB.Location = new System.Drawing.Point(6, 281);
            this.DeleteB.Name = "DeleteB";
            this.DeleteB.Size = new System.Drawing.Size(188, 33);
            this.DeleteB.TabIndex = 11;
            this.DeleteB.Text = "Delete Item";
            this.DeleteB.UseVisualStyleBackColor = true;
            this.DeleteB.Click += new System.EventHandler(this.DeleteB_Click);
            // 
            // AddB
            // 
            this.AddB.Location = new System.Drawing.Point(6, 320);
            this.AddB.Name = "AddB";
            this.AddB.Size = new System.Drawing.Size(188, 33);
            this.AddB.TabIndex = 10;
            this.AddB.Text = "Add Item to DataBase";
            this.AddB.UseVisualStyleBackColor = true;
            this.AddB.Click += new System.EventHandler(this.AddB_Click);
            // 
            // ReplaceB
            // 
            this.ReplaceB.Enabled = false;
            this.ReplaceB.Location = new System.Drawing.Point(6, 242);
            this.ReplaceB.Name = "ReplaceB";
            this.ReplaceB.Size = new System.Drawing.Size(188, 33);
            this.ReplaceB.TabIndex = 9;
            this.ReplaceB.Text = "Replace Item";
            this.ReplaceB.UseVisualStyleBackColor = true;
            this.ReplaceB.Click += new System.EventHandler(this.ReplaceB_Click);
            // 
            // ItemDurability
            // 
            this.ItemDurability.Location = new System.Drawing.Point(6, 123);
            this.ItemDurability.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ItemDurability.Name = "ItemDurability";
            this.ItemDurability.Size = new System.Drawing.Size(188, 22);
            this.ItemDurability.TabIndex = 7;
            this.ItemDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(6, 105);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(92, 15);
            this.Label23.TabIndex = 6;
            this.Label23.Text = "Item Durability :";
            // 
            // ItemID
            // 
            this.ItemID.Location = new System.Drawing.Point(6, 80);
            this.ItemID.MaxLength = 16;
            this.ItemID.Name = "ItemID";
            this.ItemID.Size = new System.Drawing.Size(188, 22);
            this.ItemID.TabIndex = 3;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(6, 62);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(52, 15);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "Item ID :";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(6, 18);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(69, 15);
            this.Label20.TabIndex = 1;
            this.Label20.Text = "Item Name :";
            // 
            // ItemName
            // 
            this.ItemName.Location = new System.Drawing.Point(6, 37);
            this.ItemName.MaxLength = 50;
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(188, 22);
            this.ItemName.TabIndex = 0;
            // 
            // ListView2
            // 
            this.ListView2.CheckBoxes = true;
            this.ListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader8,
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.ListView2.ContextMenuStrip = this.ContextMenuStrip2;
            this.ListView2.FullRowSelect = true;
            this.ListView2.GridLines = true;
            this.ListView2.HideSelection = false;
            this.ListView2.Location = new System.Drawing.Point(3, 34);
            this.ListView2.Name = "ListView2";
            this.ListView2.Size = new System.Drawing.Size(636, 369);
            this.ListView2.TabIndex = 127;
            this.ListView2.UseCompatibleStateImageBehavior = false;
            this.ListView2.View = System.Windows.Forms.View.Details;
            this.ListView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView2_ColumnClick);
            this.ListView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView2_ItemSelectionChanged);
            this.ListView2.SelectedIndexChanged += new System.EventHandler(this.ListView2_SelectedIndexChanged);
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Tag = "String";
            this.ColumnHeader5.Text = "Name";
            this.ColumnHeader5.Width = 250;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Tag = "NumericHex";
            this.ColumnHeader6.Text = "Item ID";
            this.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader6.Width = 125;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Tag = "NumericDec";
            this.ColumnHeader8.Text = "Durability";
            this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Tag = "NumericHex";
            this.ColumnHeader11.Text = "Sort";
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Tag = "String";
            this.ColumnHeader12.Text = "Section";
            this.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader12.Width = 100;
            // 
            // ContextMenuStrip2
            // 
            this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckItemToolStripMenuItem,
            this.CheckAllItemsToolStripMenuItem,
            this.ToolStripSeparator5,
            this.UncheckItemToolStripMenuItem,
            this.UncheckAllItemsToolStripMenuItem,
            this.ToolStripSeparator12,
            this.AddSelectedItemsToolStripMenuItem});
            this.ContextMenuStrip2.Name = "ContextMenuStrip1";
            this.ContextMenuStrip2.Size = new System.Drawing.Size(190, 126);
            // 
            // CheckItemToolStripMenuItem
            // 
            this.CheckItemToolStripMenuItem.Name = "CheckItemToolStripMenuItem";
            this.CheckItemToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CheckItemToolStripMenuItem.Text = "Check Item";
            this.CheckItemToolStripMenuItem.Click += new System.EventHandler(this.CheckItemToolStripMenuItem_Click);
            // 
            // CheckAllItemsToolStripMenuItem
            // 
            this.CheckAllItemsToolStripMenuItem.Name = "CheckAllItemsToolStripMenuItem";
            this.CheckAllItemsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CheckAllItemsToolStripMenuItem.Text = "Check All Items";
            this.CheckAllItemsToolStripMenuItem.Click += new System.EventHandler(this.CheckAllItemsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            // 
            // UncheckItemToolStripMenuItem
            // 
            this.UncheckItemToolStripMenuItem.Name = "UncheckItemToolStripMenuItem";
            this.UncheckItemToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.UncheckItemToolStripMenuItem.Text = "Uncheck Item";
            this.UncheckItemToolStripMenuItem.Click += new System.EventHandler(this.UncheckItemToolStripMenuItem_Click);
            // 
            // UncheckAllItemsToolStripMenuItem
            // 
            this.UncheckAllItemsToolStripMenuItem.Name = "UncheckAllItemsToolStripMenuItem";
            this.UncheckAllItemsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.UncheckAllItemsToolStripMenuItem.Text = "Uncheck All Items";
            this.UncheckAllItemsToolStripMenuItem.Click += new System.EventHandler(this.UncheckAllItemsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator12
            // 
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            this.ToolStripSeparator12.Size = new System.Drawing.Size(186, 6);
            // 
            // AddSelectedItemsToolStripMenuItem
            // 
            this.AddSelectedItemsToolStripMenuItem.Name = "AddSelectedItemsToolStripMenuItem";
            this.AddSelectedItemsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.AddSelectedItemsToolStripMenuItem.Text = "Add All Checked Item";
            this.AddSelectedItemsToolStripMenuItem.Click += new System.EventHandler(this.AddSelectedItemsToolStripMenuItem_Click);
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.BackColor = System.Drawing.Color.Gainsboro;
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshItemList,
            this.ToolStripSeparator8,
            this.saveitemlist,
            this.ToolStripSeparator7,
            this.ToolStripLabel4,
            this.Searchbox2,
            this.Findbutton2,
            this.ToolStripSeparator6,
            this.ToolStripLabel6,
            this.SectionContainer2,
            this.DBAmount});
            this.ToolStrip4.Location = new System.Drawing.Point(3, 3);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.Size = new System.Drawing.Size(847, 31);
            this.ToolStrip4.TabIndex = 126;
            this.ToolStrip4.Text = "Refresh Items";
            // 
            // RefreshItemList
            // 
            this.RefreshItemList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshItemList.Image = ((System.Drawing.Image)(resources.GetObject("RefreshItemList.Image")));
            this.RefreshItemList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshItemList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshItemList.Name = "RefreshItemList";
            this.RefreshItemList.Size = new System.Drawing.Size(28, 28);
            this.RefreshItemList.Text = "Refresh Item List";
            this.RefreshItemList.Click += new System.EventHandler(this.RefreshItemList_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.AutoSize = false;
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // saveitemlist
            // 
            this.saveitemlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveitemlist.Image = ((System.Drawing.Image)(resources.GetObject("saveitemlist.Image")));
            this.saveitemlist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveitemlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveitemlist.Name = "saveitemlist";
            this.saveitemlist.Size = new System.Drawing.Size(28, 28);
            this.saveitemlist.Text = "Save changes";
            this.saveitemlist.Click += new System.EventHandler(this.Saveitemlist_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.AutoSize = false;
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel4
            // 
            this.ToolStripLabel4.Name = "ToolStripLabel4";
            this.ToolStripLabel4.Size = new System.Drawing.Size(19, 28);
            this.ToolStripLabel4.Text = "    ";
            // 
            // Searchbox2
            // 
            this.Searchbox2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbox2.Name = "Searchbox2";
            this.Searchbox2.Size = new System.Drawing.Size(200, 31);
            this.Searchbox2.ToolTipText = "Enter name,id ,index or section to Search";
            this.Searchbox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Searchbox2_KeyDown);
            // 
            // Findbutton2
            // 
            this.Findbutton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Findbutton2.Image = ((System.Drawing.Image)(resources.GetObject("Findbutton2.Image")));
            this.Findbutton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Findbutton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Findbutton2.Name = "Findbutton2";
            this.Findbutton2.Size = new System.Drawing.Size(28, 28);
            this.Findbutton2.Text = "Search for item";
            this.Findbutton2.Click += new System.EventHandler(this.Findbutton2_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLabel6
            // 
            this.ToolStripLabel6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripLabel6.Name = "ToolStripLabel6";
            this.ToolStripLabel6.Size = new System.Drawing.Size(32, 28);
            this.ToolStripLabel6.Text = "View";
            // 
            // SectionContainer2
            // 
            this.SectionContainer2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionContainer2.Name = "SectionContainer2";
            this.SectionContainer2.Size = new System.Drawing.Size(200, 31);
            this.SectionContainer2.ToolTipText = "Section to View";
            this.SectionContainer2.SelectedIndexChanged += new System.EventHandler(this.SectionContainer2_SelectedIndexChanged);
            // 
            // DBAmount
            // 
            this.DBAmount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DBAmount.Name = "DBAmount";
            this.DBAmount.Size = new System.Drawing.Size(0, 28);
            // 
            // dataSetItems
            // 
            this.dataSetItems.DataSetName = "Items";
            this.dataSetItems.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableAttune});
            // 
            // dataTableAttune
            // 
            this.dataTableAttune.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTableAttune.TableName = "Attune";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "DisplayName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Item";
            this.dataColumn2.DataType = typeof(object);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 491);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.ToolStrip2);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dark Souls Save Editor - V";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkinBrightness)).EndInit();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Souls)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Strength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stamina2)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Humanity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Endurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stamina1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlaythrough)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vitality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Faith)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attunement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMC1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ToolStrip3.ResumeLayout(false);
            this.ToolStrip3.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDurability)).EndInit();
            this.ContextMenuStrip2.ResumeLayout(false);
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAttune)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    internal System.Windows.Forms.ToolStrip ToolStrip1;
    internal System.Windows.Forms.ToolStrip ToolStrip2;
    internal System.Windows.Forms.TabControl TabControl1;
    internal System.Windows.Forms.TabPage TabPage1;
    internal System.Windows.Forms.NumericUpDown Souls;
    internal System.Windows.Forms.CheckBox CheckBox1;
    internal System.Windows.Forms.GroupBox GroupBox3;
	internal System.Windows.Forms.ComboBox ComboBoxCovenant;
    internal System.Windows.Forms.NumericUpDown Strength;
    internal System.Windows.Forms.Button MaxAllB;
    internal System.Windows.Forms.Label Label17;
    internal System.Windows.Forms.NumericUpDown Stamina2;
    internal System.Windows.Forms.GroupBox GroupBox1;
    internal System.Windows.Forms.TextBox CharacterName;
    internal System.Windows.Forms.Label Label19;
    internal System.Windows.Forms.Label Label11;
    internal System.Windows.Forms.NumericUpDown Resistance;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Label labe1;
    internal System.Windows.Forms.NumericUpDown HP1;
    internal System.Windows.Forms.NumericUpDown Humanity;
    internal System.Windows.Forms.NumericUpDown HP2;
    internal System.Windows.Forms.Label Label16;
    internal System.Windows.Forms.Label Label2;
    internal System.Windows.Forms.NumericUpDown Endurance;
    internal System.Windows.Forms.Label Label4;
    internal System.Windows.Forms.Label Label15;
    internal System.Windows.Forms.NumericUpDown Stamina1;
    internal System.Windows.Forms.NumericUpDown Level;
    internal System.Windows.Forms.Label Label5;
    internal System.Windows.Forms.NumericUpDown Vitality;
    internal System.Windows.Forms.NumericUpDown Faith;
    internal System.Windows.Forms.Label Label6;
    internal System.Windows.Forms.Label Label10;
    internal System.Windows.Forms.NumericUpDown Attunement;
    internal System.Windows.Forms.Label Label7;
    internal System.Windows.Forms.NumericUpDown Intelligence;
    internal System.Windows.Forms.Label Label9;
    internal System.Windows.Forms.Label Label8;
    internal System.Windows.Forms.NumericUpDown Dexterity;
    internal System.Windows.Forms.TabPage TabPage2;
    internal System.Windows.Forms.TabPage TabPage3;
    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip2;
    internal System.Windows.Forms.Label Label18;
    internal System.Windows.Forms.ToolStrip ToolStrip3;
    internal System.Windows.Forms.ToolStripButton SaveItems;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
    internal System.Windows.Forms.ToolStripTextBox searchBox;
    internal System.Windows.Forms.ToolStripButton Search;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
    internal System.Windows.Forms.ToolStripComboBox SectionContainer1;
    internal System.Windows.Forms.ToolStripButton RefreshItems;
    internal System.Windows.Forms.ToolStripButton SaveAllB;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
    internal System.Windows.Forms.ToolStripButton SaveAsB;
    internal System.Windows.Forms.ToolStripButton ToolStripButton5;
    internal System.Windows.Forms.ToolStripButton ToolStripButton4;
    internal System.Windows.Forms.ListView ListView1;
    internal System.Windows.Forms.ColumnHeader ColumnHeader1;
    internal System.Windows.Forms.ColumnHeader ColumnHeader2;
    internal System.Windows.Forms.ColumnHeader ColumnHeader3;
    internal System.Windows.Forms.ColumnHeader ColumnHeader4;
    internal System.Windows.Forms.ColumnHeader ColumnHeader9;
    internal System.Windows.Forms.ColumnHeader ColumnHeader10;
    internal System.Windows.Forms.GroupBox GroupBox4;
    internal System.Windows.Forms.Button AddB;
    internal System.Windows.Forms.Button ReplaceB;
    internal System.Windows.Forms.NumericUpDown ItemDurability;
    internal System.Windows.Forms.Label Label23;
    internal System.Windows.Forms.TextBox ItemID;
    internal System.Windows.Forms.Label Label21;
    internal System.Windows.Forms.Label Label20;
    internal System.Windows.Forms.TextBox ItemName;
    internal System.Windows.Forms.ListView ListView2;
    internal System.Windows.Forms.ColumnHeader ColumnHeader5;
    internal System.Windows.Forms.ColumnHeader ColumnHeader6;
    internal System.Windows.Forms.ColumnHeader ColumnHeader8;
    internal System.Windows.Forms.ColumnHeader ColumnHeader12;
    internal System.Windows.Forms.ToolStrip ToolStrip4;
    internal System.Windows.Forms.ToolStripButton RefreshItemList;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
    internal System.Windows.Forms.ToolStripButton saveitemlist;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel4;
    internal System.Windows.Forms.ToolStripTextBox Searchbox2;
    internal System.Windows.Forms.ToolStripButton Findbutton2;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel6;
    internal System.Windows.Forms.ToolStripComboBox SectionContainer2;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel3;
    internal System.Windows.Forms.ToolStripTextBox ammount;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel5;
    internal System.Windows.Forms.ToolStripTextBox dura;
    internal System.Windows.Forms.ToolStripButton SetValue;
    internal System.Windows.Forms.ColumnHeader ColumnHeader7;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator11;
    internal System.Windows.Forms.Label Label22;
    internal System.Windows.Forms.ComboBox ItemSection;
    internal System.Windows.Forms.Button DeleteB;
    internal System.Windows.Forms.ToolStripMenuItem CheckItemToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem CheckAllItemsToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem AddSelectedItemsToolStripMenuItem;
    internal System.Windows.Forms.ToolStripButton SlotB;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel11;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel10;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel9;
    internal System.Windows.Forms.ToolStripButton ToolStripButton1;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel8;
    internal System.Windows.Forms.ToolStripLabel ToolStripLabel7;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
    internal System.Windows.Forms.ToolStripMenuItem UncheckItemToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem UncheckAllItemsToolStripMenuItem;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator12;
    internal System.Windows.Forms.Label Label24;
    internal System.Windows.Forms.ColumnHeader ColumnHeader11;
    internal System.Windows.Forms.TextBox Itemsort;
    internal System.Windows.Forms.ToolStripButton MaxSection;
    internal System.Windows.Forms.ToolStripMenuItem DeleteItemToolStripMenuItem;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator13;
    internal System.Windows.Forms.ToolStripMenuItem RenameItemToolStripMenuItem;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator14;
    internal System.Windows.Forms.ToolStripMenuItem MaxToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem QuantityToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem DurabilityToolStripMenuItem;
    internal System.Windows.Forms.ToolStripLabel ToolStripSeparator15;
    internal System.Windows.Forms.ToolStripButton ToolStripButton2;
    internal System.Windows.Forms.ToolStripLabel DBAmount;
    internal System.Windows.Forms.ToolStripLabel ToolStripSeparator16;
    internal System.Windows.Forms.ToolStripLabel Status;
    internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar1;
    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
    internal System.Windows.Forms.ToolStripButton ToolStripButton3;
	private System.ComponentModel.IContainer components;
	private TabPage tabPage4;
	internal GroupBox GroupBox2;
	internal ComboBox comboBoxHairStyle;
	internal ComboBox ComboBoxPhysique;
	internal ComboBox ComboBoxGift;
	internal ComboBox ComboBoxClass;
	internal Label label25;
	internal Label Label14;
	internal Label Label13;
	internal Label Label12;
	internal Label Label3;
	internal ComboBox ComboBoxGender;
	private TextBox textBoxHC;
	private NumericUpDown numericUpDownSkinBrightness;
	private TextBox textBoxEC;
	internal ComboBox comboBoxColor;
	internal Label label27;
	internal Label label31;
	internal Label label29;
	internal Label label28;
	internal Label label26;
	internal NumericUpDown numericUpDownSin;
	internal Label label30;
	internal NumericUpDown numericUpDownPlaythrough;
	private TabPage tabPage5;
	private GroupBox groupBox5;
	internal ComboBox comboBoxAttune12;
	internal ComboBox comboBoxAttune11;
	internal ComboBox comboBoxAttune10;
	internal ComboBox comboBoxAttune9;
	internal ComboBox comboBoxAttune8;
	internal ComboBox comboBoxAttune7;
	internal ComboBox comboBoxAttune6;
	internal ComboBox comboBoxAttune5;
	internal ComboBox comboBoxAttune4;
	internal ComboBox comboBoxAttune3;
	internal ComboBox comboBoxAttune2;
	internal ComboBox comboBoxAttune1;
	private DataSet dataSetItems;
	private DataTable dataTableAttune;
	private DataColumn dataColumn1;
	private DataColumn dataColumn2;
	private NumericUpDown numericUpDownMC12;
	private NumericUpDown numericUpDownMC11;
	private NumericUpDown numericUpDownMC10;
	private NumericUpDown numericUpDownMC9;
	private NumericUpDown numericUpDownMC8;
	private NumericUpDown numericUpDownMC7;
	private NumericUpDown numericUpDownMC6;
	private NumericUpDown numericUpDownMC5;
	private NumericUpDown numericUpDownMC4;
	private NumericUpDown numericUpDownMC3;
	private NumericUpDown numericUpDownMC2;
	private NumericUpDown numericUpDownMC1;
	private Label label32;
	private GroupBox groupBox6;
	internal ComboBox comboBoxUI5;
	internal ComboBox comboBoxUI4;
	internal ComboBox comboBoxUI3;
	internal ComboBox comboBoxUI2;
	internal ComboBox comboBoxUI1;
	private GroupBox groupBox7;
	internal ComboBox comboBoxGauntlets;
	internal ComboBox comboBoxArmor;
	internal ComboBox comboBoxHelm;
	internal ComboBox comboBoxLeggings;
	private Label label33;
	private Label label36;
	private Label label35;
	private Label label34;
	private GroupBox groupBox8;
	internal ComboBox comboBoxLW1;
	internal ComboBox comboBoxRW2;
	internal ComboBox comboBoxLW2;
	internal ComboBox comboBoxRW1;
	private Label label38;
	private Label label40;
	internal ComboBox comboBoxHSID;
	private ToolStripButton CopyB;
	private ToolStripButton SwapB;
	internal ToolStripLabel toolStripLabel2;
	private GroupBox groupBox9;
	private Label label37;
	private Label label39;
	internal ComboBox comboBoxBolt1;
	internal ComboBox comboBoxArrow2;
	internal ComboBox comboBoxBolt2;
	internal ComboBox comboBoxArrow1;
	private GroupBox groupBox11;
	internal ComboBox comboBoxRing2;
	internal ComboBox comboBoxRing1;
    internal ToolStripDropDownButton OpenB;
    private ToolStripMenuItem xbox360ToolStripMenuItem;
    private ToolStripMenuItem pS3ToolStripMenuItem;
        private ToolStripMenuItem PCToolStripMenuItem;
    }
}

