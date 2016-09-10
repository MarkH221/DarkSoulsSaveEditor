using ISOLib.CONPackage;
using ISOLib.Conversions;
using ISOLib.IOPackage;
using PS3FileSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DSSE
{
    public partial class MainForm : Form
    {
        private int LastSortColumn = -1;
        private SortOrder LastSortOrder = SortOrder.Ascending;

        public MainForm()
        {
            InitializeComponent();
            Text += ProductVersion;

            //Box setup
            AttunementBoxes.Add(comboBoxAttune1);
            AttunementBoxes.Add(comboBoxAttune2);
            AttunementBoxes.Add(comboBoxAttune3);
            AttunementBoxes.Add(comboBoxAttune4);
            AttunementBoxes.Add(comboBoxAttune5);
            AttunementBoxes.Add(comboBoxAttune6);
            AttunementBoxes.Add(comboBoxAttune7);
            AttunementBoxes.Add(comboBoxAttune8);
            AttunementBoxes.Add(comboBoxAttune9);
            AttunementBoxes.Add(comboBoxAttune10);
            AttunementBoxes.Add(comboBoxAttune11);
            AttunementBoxes.Add(comboBoxAttune12);

            CountBoxes.Add(numericUpDownMC1);
            CountBoxes.Add(numericUpDownMC2);
            CountBoxes.Add(numericUpDownMC3);
            CountBoxes.Add(numericUpDownMC4);
            CountBoxes.Add(numericUpDownMC5);
            CountBoxes.Add(numericUpDownMC6);
            CountBoxes.Add(numericUpDownMC7);
            CountBoxes.Add(numericUpDownMC8);
            CountBoxes.Add(numericUpDownMC9);
            CountBoxes.Add(numericUpDownMC10);
            CountBoxes.Add(numericUpDownMC11);
            CountBoxes.Add(numericUpDownMC12);

            UsableItemBoxes.Add(comboBoxUI1);
            UsableItemBoxes.Add(comboBoxUI2);
            UsableItemBoxes.Add(comboBoxUI3);
            UsableItemBoxes.Add(comboBoxUI4);
            UsableItemBoxes.Add(comboBoxUI5);

            ArmorBoxes.Add(comboBoxHelm);
            ArmorBoxes.Add(comboBoxArmor);
            ArmorBoxes.Add(comboBoxGauntlets);
            ArmorBoxes.Add(comboBoxLeggings);

            WeaponBoxes.Add(comboBoxLW1);
            WeaponBoxes.Add(comboBoxRW1);
            WeaponBoxes.Add(comboBoxLW2);
            WeaponBoxes.Add(comboBoxRW2);

            AmmoBoxes.Add(comboBoxArrow1);
            AmmoBoxes.Add(comboBoxBolt1);
            AmmoBoxes.Add(comboBoxArrow2);
            AmmoBoxes.Add(comboBoxBolt2);

            RingBoxes.Add(comboBoxRing1);
            RingBoxes.Add(comboBoxRing2);

            TabControl1.SelectedTab = TabPage1;
        }

        public void ToolStripButton3_Click(Object sender, EventArgs e)
        {
            if (ItemTextLists.Count > 0)
            {
                var x = new ItemAdder(ItemTextLists);
                x.ShowDialog();
            }
        }

        private void CopyB_Click(object sender, EventArgs e)
        {
            if (Xfile == null)
                return;
            try
            {
                SlotCopy slot;
                switch (platform)
                {
                    case Platform.None:
                        return;

                    case Platform.PC:

                        if (ReadPCBlocks())
                        {
                            slot = new SlotCopy(XPCEntries.Select(item => item.Name).ToArray());
                            if (slot.ShowDialog() != DialogResult.OK)
                                return;
                            var SourceData = ExtractPCBlock(slot.Source.Text);
                            ReplaceBlock(slot.Destination.Text, SourceData, Xfile);
                        }
                        break;

                    case Platform.XBOX360:

                        var stfs = new Initialize(Xfile);
                        slot = new SlotCopy(stfs.EmbeddedFileNames);
                        if (slot.ShowDialog() == DialogResult.OK)
                        {
                            var SourceData = stfs.Extract(slot.Source.Text);
                            stfs.Replace(SourceData, slot.Destination.Text);
                            stfs.Finish();
                            stfs.Close();
                        }
                        else
                        {
                            stfs.Close();
                            return;
                        }
                        break;

                    case Platform.PS3:
                        //TODO This
                        var ps3 = new Ps3SaveManager(Xfile, Ps3Key);

                        var files = new List<ComboboxItem>();
                        for (var i = 0; i < ps3.Files.Count(); i++)
                        {
                            if (ps3.Files[i].PFDEntry.file_name.EndsWith("USER.DAT"))
                            {
                                files.Add(new ComboboxItem { Text = ps3.Files[i].PFDEntry.file_name, Value = i });
                            }
                        }
                        slot = new SlotCopy(files.ToArray());
                        if (slot.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(ps3.RootPath + @"\\" + ps3.Files[slot.Source.Value].PFDEntry.file_name,
                                ps3.RootPath + @"\\" + ps3.Files[slot.Destination.Value].PFDEntry.file_name, true);
                        }
                        break;
                }
                MessageBox.Show("Slot copied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Copy Save!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SwapB_Click(object sender, EventArgs e)
        {
            if (Xfile == null)
                return;
            try
            {
                var success = false;
                SlotSwap slot;
                switch (platform)
                {
                    case Platform.None:
                        return;

                    case Platform.PC:

                        if (ReadPCBlocks())
                        {
                            slot = new SlotSwap(XPCEntries.Select(item => item.Name).ToArray());
                            if (slot.ShowDialog() != DialogResult.OK)
                                return;
                            var Slot1Data = ExtractPCBlock(slot.Slot1.Text);
                            var Slot2Data = ExtractPCBlock(slot.Slot2.Text);
                            ReplaceBlock(slot.Slot1.Text, Slot2Data, Xfile);
                            ReplaceBlock(slot.Slot2.Text, Slot1Data, Xfile);
                            success = true;
                        }
                        break;

                    case Platform.XBOX360:
                        var stfs = new Initialize(Xfile);
                        slot = new SlotSwap(stfs.EmbeddedFileNames);
                        if (slot.ShowDialog() == DialogResult.OK)
                        {
                            var Slot1Data = stfs.Extract(slot.Slot1.Text);
                            var Slot2Data = stfs.Extract(slot.Slot2.Text);
                            stfs.Replace(Slot2Data, slot.Slot1.Text);
                            stfs.Replace(Slot1Data, slot.Slot2.Text);
                            stfs.Finish();
                            stfs.Close();
                            success = true;
                        }
                        else
                        {
                            stfs.Close();
                            return;
                        }
                        break;

                    case Platform.PS3:
                        //TODO This
                        var ps3 = new Ps3SaveManager(Xfile, Ps3Key);

                        var files = new List<ComboboxItem>();
                        for (var i = 0; i < ps3.Files.Count(); i++)
                        {
                            if (ps3.Files[i].PFDEntry.file_name.EndsWith("USER.DAT"))
                            {
                                files.Add(new ComboboxItem { Text = ps3.Files[i].PFDEntry.file_name, Value = i });
                            }
                        }
                        slot = new SlotSwap(files.ToArray());
                        if (slot.ShowDialog() == DialogResult.OK)
                        {
                            //How barbaric!
                            //TODO copy to arrays instead and delete originals.
                            File.Move(ps3.RootPath + @"\\" + ps3.Files[slot.Slot1.Value].PFDEntry.file_name,
                                ps3.RootPath + @"\\" + ps3.Files[slot.Slot1.Value].PFDEntry.file_name + "a");
                            File.Move(ps3.RootPath + @"\\" + ps3.Files[slot.Slot2.Value].PFDEntry.file_name,
                                ps3.RootPath + @"\\" + ps3.Files[slot.Slot1.Value].PFDEntry.file_name);
                            File.Move(ps3.RootPath + @"\\" + ps3.Files[slot.Slot1.Value].PFDEntry.file_name + "a",
                                ps3.RootPath + @"\\" + ps3.Files[slot.Slot2.Value].PFDEntry.file_name);
                            success = true;
                        }

                        break;
                }
                if (success)
                    MessageBox.Show("Slots swapped.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Swap Saves!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class PCEntries
        {
            public PCEntries(string name, UInt32 offset, UInt32 length)
            {
                Name = name;
                Offset = offset;
                this.Length = length;
            }

            public string Name { get; set; }
            public UInt32 Offset { get; set; }
            public UInt32 Length { get; set; }
        }

        #region Variables

        public List<ItemDBList> ItemTextLists = new List<ItemDBList>();
        public List<Items> RemovedItems = new List<Items>();
        public List<Items> ItemList = new List<Items>();
        public string Xfile;
        public string XSelectedSave;
        public byte[] XSave;
        public List<PCEntries> XPCEntries = new List<PCEntries>();
        public Platform platform = Platform.None;

        private static readonly byte[] Ps3Key =
        {
            0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98,
            0x76, 0x54, 0x32, 0x10
        };

        private float HealthMultiplier = 1;
        private float StaminaMultiplier = 1;
        private readonly List<ComboBox> AttunementBoxes = new List<ComboBox>();
        private readonly List<NumericUpDown> CountBoxes = new List<NumericUpDown>();
        private readonly List<ComboBox> UsableItemBoxes = new List<ComboBox>();
        private readonly List<ComboBox> ArmorBoxes = new List<ComboBox>();
        private readonly List<ComboBox> WeaponBoxes = new List<ComboBox>();
        private readonly List<ComboBox> AmmoBoxes = new List<ComboBox>();
        private readonly List<ComboBox> RingBoxes = new List<ComboBox>();

        #endregion Variables

        #region Some Functions

        public bool ValidateSave(string File)
        {
            if (platform == Platform.None) return false;
            if (platform != Platform.PS3)
            {
                using (
                    var reader =
                        new BinaryReader(new FileStream(File, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    //We multi-plat now!
                    switch (platform)
                    {
                        case Platform.PC:
                            byte[] magic = { 0x42, 0x4e, 0x44, 0x34 };
                            for (var i = 0; i <= magic.Length - 1; i++)
                            {
                                if (reader.ReadByte() != magic[i])
                                    goto Thing;
                            }
                            return true;
                        //stfs magic
                        case Platform.XBOX360:
                            Thing:
                            magic = new byte[] { 0x43, 0x4f, 0x4e, 0x20 };
                            reader.BaseStream.Position = 0;
                            for (var i = 0; i <= magic.Length - 1; i++)
                            {
                                if (reader.ReadByte() != magic[i])
                                    return false;
                            }
                            reader.BaseStream.Position = 0x360;
                            //titleid
                            magic = new byte[] { 0x4e, 0x4d, 0x8, 0x3a };
                            for (var i = 0; i <= magic.Length - 1; i++)
                            {
                                if (reader.ReadByte() != magic[i])
                                    return false;
                            }
                            break;
                    }
                    reader.Close();
                }
                return true;
            }
            //PS3 Section
            //TODO additional checks
            var ps3 = new Ps3SaveManager(File, Ps3Key);
            //We determine if this save folder is actually dark souls based on the titleid.
            string[] ps3ids =
            {
                "BLUS30782",
                "BLUS30807", "BLES01396", "BLES01402", "BLES01765", "BLJM60993", "BLAS50387", "BLJM60517", "BLAS50528",
                "BLAS50397"
            };
            return (ps3ids.Any(s => s.Equals(ps3.Param_SFO.TitleID.Substring(0, 9))));
        }

        public void SetNumericValue(NumericUpDown field, int value)
        {
            field.Value = value > field.Maximum ? field.Maximum : ((value < field.Minimum ? field.Minimum : value));
        }

        public string GetNameByID(string ID, ref string section)
        {
            if (ID == "FFFFFFFFFFFFFFFF")
            {
                section = "Empty";
                return "EmptySlot";
            }
            for (var i = 0; i <= ItemTextLists.Count - 1; i++)
            {
                if (ItemTextLists[i].ID == ID)
                {
                    section = ItemTextLists[i].Section;
                    return ItemTextLists[i].Name;
                }
            }
            section = "Unknown";
            return "Unknown";
        }

        public byte[] GetItemDBArray(string section)
        {
            byte[] Buffer;
            using (var mem = new MemoryStream())
            {
                using (var writer = new BinaryWriter(mem))
                {
                    writer.Write(Encoding.UTF8.GetByteCount(section));
                    writer.Write(Encoding.UTF8.GetBytes(section.Replace("\0", "")));
                    var temp = new MemoryStream();
                    using (var w = new BinaryWriter(temp))
                    {
                        w.BaseStream.Position = 0;
                        for (var i = 0; i <= ItemTextLists.Count - 1; i++)
                        {
                            if (ItemTextLists[i].Section == section)
                            {
                                w.Write(Encoding.UTF8.GetBytes(ItemTextLists[i].ID));
                                w.Write(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(ItemTextLists[i].Name)));
                                w.Write(Encoding.UTF8.GetBytes(ItemTextLists[i].Name));
                                w.Write(BitConverter.GetBytes(ItemTextLists[i].Durability));
                                w.Write(Encoding.UTF8.GetBytes(ItemTextLists[i].SortValue));
                            }
                        }
                        writer.Write((int)temp.Length);
                        writer.Write(temp.ToArray());
                        w.Close();
                    }
                    writer.Close();
                }
                Buffer = mem.ToArray();
                mem.Dispose();
                mem.Close();
            }
            return Buffer;
        }

        public bool FixSaveHash()
        {
            try
            {
                using (var fs = new FileStream(XSelectedSave, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(XSave, 0, XSave.Length);
                }

                var x = new MD5CryptoServiceProvider();
                var buffer = new byte[1];
                if (platform == Platform.PC)
                {
                    var length = (int)BitConverter.ToUInt32(XSave, 16);
                    Array.Resize(ref buffer, length - 16);
                    Array.Copy(XSave, 20, buffer, 0, buffer.Length);
                    Array.Copy(x.ComputeHash(buffer), 0, XSave, length + 4, 16);
                    if (XSave.Length == length + 36)
                    {
                        Array.Resize(ref buffer, length);
                        Array.Copy(XSave, 20, buffer, 0, buffer.Length);
                        Array.Copy(x.ComputeHash(buffer), 0, XSave, length + 20, 16);
                    }
                    Array.Resize(ref buffer, XSave.Length - 16);
                    Array.Copy(XSave, 16, buffer, 0, buffer.Length);
                    Array.Copy(x.ComputeHash(buffer), 0, XSave, 0, 16);
                    buffer = null;
                    return true;
                }
                Array.Resize(ref buffer, XSave.Length - 16);
                Array.Copy(XSave, 0, buffer, 0, buffer.Length);
                Array.Copy(x.ComputeHash(buffer), 0, XSave, XSave.Length - 16, 16);
                buffer = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidHexString(string value)
        {
            char[] hex =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c',
                'd', 'e', 'f'
            };
            var hexvalues = new List<char>(hex);
            return value.All(s => hexvalues.Contains(s));
        }

        public bool ValidNRString(string value)
        {
            char[] hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var hexvalues = new List<char>(hex);
            return value.All(s => hexvalues.Contains(s));
        }

        public void SortMyListView(ListView ListViewToSort, int ColumnNumber, bool Resort = false,
            bool ForceSort = false)
        {
            SortOrder SortOrder;
            if (Resort)
            {
                SortOrder = LastSortOrder;
            }
            else
            {
                if (LastSortColumn == ColumnNumber)
                {
                    SortOrder = LastSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
                else
                {
                    SortOrder = SortOrder.Ascending;
                }
            }
            if (ListViewToSort.Columns[ColumnNumber].Tag == null ||
                string.IsNullOrEmpty(ListViewToSort.Columns[ColumnNumber].Tag.ToString()))
            {
                if (ForceSort)
                {
                    ListViewToSort.Columns[ColumnNumber].Tag = "String";
                }
                else
                {
                    return;
                }
            }

            switch (ListViewToSort.Columns[ColumnNumber].Tag.ToString())
            {
                case "NumericDec":
                    ListViewToSort.ListViewItemSorter = new ListViewNumericSort(ColumnNumber, SortOrder, false);
                    break;

                case "NumericHex":
                    ListViewToSort.ListViewItemSorter = new ListViewNumericSort(ColumnNumber, SortOrder, true);
                    break;

                case "Date":
                    ListViewToSort.ListViewItemSorter = new ListViewDateSort(ColumnNumber, SortOrder);
                    break;

                case "String":
                    ListViewToSort.ListViewItemSorter = new ListViewStringSort(ColumnNumber, SortOrder);
                    break;
            }
            LastSortColumn = ColumnNumber;
            LastSortOrder = SortOrder;
            ListViewToSort.ListViewItemSorter = null;
        }

        public bool GetSections(ItemStorage x)
        {
            switch (x)
            {
                case ItemStorage.Save:
                    if (ItemList == null || ItemList.Count == 0)
                        return false;
                    SectionContainer1.Items.Clear();
                    SectionContainer1.Items.Add("All");
                    for (var i = 0; i <= ItemList.Count - 1; i++)
                    {
                        if (!SectionContainer1.Items.Contains(ItemList[i].Section))
                            SectionContainer1.Items.Add(ItemList[i].Section);
                    }
                    break;

                case ItemStorage.Database:
                    if (ItemTextLists == null || ItemTextLists.Count == 0)
                        return false;
                    SectionContainer2.Items.Clear();
                    ItemSection.Items.Clear();
                    for (var i = 0; i <= ItemTextLists.Count - 1; i++)
                    {
                        if (!SectionContainer2.Items.Contains(ItemTextLists[i].Section))
                            SectionContainer2.Items.Add(ItemTextLists[i].Section);
                        if (!ItemSection.Items.Contains(ItemTextLists[i].Section))
                            ItemSection.Items.Add(ItemTextLists[i].Section);
                    }
                    break;
            }
            return true;
        }

        public string Getstatustext()
        {
            var keys = 0;
            var items = 0;
            var empty = 0;
            var unknown = 0;
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].Section.ToLower() == "empty")
                {
                    if (i >= 64) empty += 1;
                    continue;
                }
                if (ItemList[i].Section.ToLower() == "unknown")
                {
                    unknown += 1;
                    continue;
                }
                if (i < 64)
                    keys++;
                else
                    items += 1;
            }
            return keys + " Keys | " + items + " Known Items | " + unknown + " Unknown Items | " + empty +
                   " Empty Slots" + " | " + ListView1.Items.Count + " Viewed Items";
        }

        public string GetDBAmount(string section)
        {
            var items = 0;
            for (var i = 0; i <= ItemTextLists.Count - 1; i++)
            {
                if (section == "All")
                {
                    items += 1;
                    continue;
                }
                if (ItemTextLists[i].Section == section)
                    items += 1;
            }
            return items + " " + (section == "All" ? "Total Items" : section);
        }

        public void ViewSection(string section, ItemStorage x)
        {
            switch (x)
            {
                case ItemStorage.Save:
                    if (ItemList == null || ItemList.Count == 0)
                        return;
                    ListView1.Items.Clear();
                    ListView1.BeginUpdate();
                    foreach (var item in ItemList)
                    {
                        if (!section.ToLower().Contains("empty"))
                        {
                            if (item.Section.ToLower().Contains("empty"))
                                continue;
                        }
                        Application.DoEvents();
                        AddLV(item, ListView1, section);
                    }

                    ListView1.EndUpdate();
                    Status.Text = Getstatustext();
                    break;

                case ItemStorage.Database:
                    if (ItemTextLists == null || ItemTextLists.Count == 0)
                        return;
                    ListView2.Items.Clear();
                    foreach (var item in ItemTextLists)
                    {
                        //Application.DoEvents();
                        AddLV1(item, ListView2, section);
                    }

                    DBAmount.Text = GetDBAmount(section);
                    break;
            }
        }

        public void AddLV(Items item, ListView lv, string section = "All")
        {
            ListViewItem x = null;
            if (section == "All" || item.Section.ToLower() == section.ToLower())
            {
                x = new ListViewItem(item.Name) { Checked = item.Unlocked != 0 };
                x.SubItems.Add(item.ID);
                x.SubItems.Add(item.Quantity.ToString());
                x.SubItems.Add(item.Durability.ToString());
                x.SubItems.Add(item.Index.ToString());
                x.SubItems.Add(item.Section);
                x.SubItems.Add("0x" + item.Offset.ToString("X"));
                x.Tag = item;
            }

            if (x != null)
                lv.Items.Add(x);
        }

        public void ReplaceLV(Items item, int index)
        {
            if (index > ListView1.Items.Count)
                return;
            ListView1.Items[index].SubItems[0].Text = item.Name;
            ListView1.Items[index].SubItems[1].Text = item.ID;
            ListView1.Items[index].SubItems[2].Text = item.Quantity.ToString();
            ListView1.Items[index].SubItems[3].Text = item.Durability.ToString();
            ListView1.Items[index].SubItems[4].Text = item.Index.ToString();
            ListView1.Items[index].SubItems[5].Text = item.Section;
            ListView1.Items[index].SubItems[6].Text = "0x" + item.Offset.ToString("X");
        }

        public void AddLV1(ItemDBList item, ListView lv, string section = "All")
        {
            ListViewItem x = null;
            if (section == "All" || item.Section.ToLower() == section.ToLower())
            {
                lv.BeginUpdate();
                x = new ListViewItem(item.Name);
                x.SubItems.Add(item.ID);
                x.SubItems.Add(item.Durability.ToString());
                x.SubItems.Add(item.SortValue);
                x.SubItems.Add(item.Section);
                x.Tag = item;
                lv.Items.Add(x);
                lv.EndUpdate();
            }
        }

        public void FindInItemList(string text)
        {
            if (ItemList == null || ItemList.Count == 0)
                return;
            if (searchBox.Text == "")
            {
                MessageBox.Show("Enter something to look for");
                return;
            }
            var x = searchBox.Text;
            var result = new List<int>();
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].Name.ToLower().Contains(x.ToLower()) || ItemList[i].ID.ToLower().Contains(x.ToLower()) ||
                    ItemList[i].Index.ToString() == x || ItemList[i].Section.ToLower().Contains(x.ToLower()))
                    result.Add(i);
            }
            if (result.Count > 0)
            {
                ListView1.Items.Clear();
                for (var i = 0; i <= result.Count - 1; i++)
                {
                    AddLV(ItemList[result[i]], ListView1);
                }
                MessageBox.Show(result.Count + " Result(s) Found !", "Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing Found !", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void FindInItemDB(string text)
        {
            if (ItemTextLists == null || ItemTextLists.Count == 0)
                return;
            if (text == "")
            {
                MessageBox.Show("Enter something to look for");
                return;
            }
            var result = new List<int>();
            for (var i = 0; i <= ItemTextLists.Count - 1; i++)
            {
                if (ItemTextLists[i].Name.ToLower().Contains(text.ToLower()) ||
                    ItemTextLists[i].ID.ToLower().Contains(text.ToLower()) ||
                    ItemTextLists[i].Section.ToLower().Contains(text.ToLower()))
                    result.Add(i);
            }
            if (result.Count > 0)
            {
                ListView2.Items.Clear();
                for (var i = 0; i <= result.Count - 1; i++)
                {
                    AddLV1(ItemTextLists[result[i]], ListView2);
                }
                MessageBox.Show(result.Count + " Result(s) Found !", "Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing Found !", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public int GetAvailibleSpot(bool key)
        {
            var value = 0;
            if (!key)
                value = 64;
            for (var i = value; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].Section.ToLower().Contains("empty"))
                    return i;
            }
            return -1;
        }

        public void RemoveItem(string id)
        {
            Items empty;
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                empty = new Items("FFFFFFFFFFFFFFFF", "Empty Slot", 0, "0", 0, 0, 0, 0, ItemList[i].Offset, "Empty");
                if (ItemList[i].ID.ToLower() == id.ToLower())
                {
                    ItemList[i] = empty;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        public void RemoveItemDB(string id, string section)
        {
            for (var i = 0; i <= ItemTextLists.Count - 1; i++)
            {
                if (ItemTextLists[i].ID.ToLower() == id.ToLower() &&
                    ItemTextLists[i].Section.ToLower() == section.ToLower())
                {
                    ItemTextLists.RemoveAt(i);
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        public void ReplaceItem(Items item, int value = -1)
        {
            if (ItemList == null || ItemList.Count == 0)
                return;
            if (item == null)
                return;
            var index = (value == -1
                ? (item.Index >= 0 && item.Index < 2048
                    ? item.Index
                    : (uint)GetAvailibleSpot(item.Section.ToLower().Contains("keys")))
                : (uint)value);
            item.Index = index;
            ItemList[(int)index] = item;
            GetSections(ItemStorage.Save);
        }

        public void RepaceItemDB(ItemDBList item, string id, string section)
        {
            if (ItemTextLists == null || ItemTextLists.Count == 0)
                return;
            if (item == null)
                return;
            for (var i = 0; i <= ItemTextLists.Count - 1; i++)
            {
                if (ItemTextLists[i].ID.ToLower() == id.ToLower() &&
                    ItemTextLists[i].Section.ToLower() == section.ToLower())
                {
                    ItemTextLists[i] = item;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        public void AddItemDB(ItemDBList item)
        {
            if (ItemTextLists == null || item == null)
                return;
            ItemTextLists.Add(item);
        }

        public int GetItemIndexByID(string id)
        {
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].ID == id)
                    return i;
            }
            return -1;
        }

        public bool IDExist(string id, string section, ItemStorage type)
        {
            switch (type)
            {
                case ItemStorage.Database:
                    if (ItemTextLists == null || ItemTextLists.Count == 0)
                        return false;
                    for (var i = 0; i <= ItemTextLists.Count - 1; i++)
                    {
                        if (ItemTextLists[i].ID.ToLower() == id.ToLower() &&
                            ItemTextLists[i].Section.ToLower() == section.ToLower())
                            return true;
                    }
                    break;

                case ItemStorage.Save:
                    if (ItemList == null || ItemList.Count == 0)
                        return false;
                    for (var i = 0; i <= ItemList.Count - 1; i++)
                    {
                        if (ItemList[i].ID.ToLower() == id.ToLower() &&
                            ItemList[i].Section.ToLower() == section.ToLower())
                            return true;
                    }
                    break;
            }
            return false;
        }

        public void Refresh(ItemStorage type)
        {
            ListViewItem lv;
            switch (type)
            {
                case ItemStorage.Database:
                    if (ItemTextLists == null || ItemTextLists.Count == 0)
                        return;
                    ListView2.Items.Clear();
                    ListView2.BeginUpdate();
                    for (var i = 0; i <= ItemTextLists.Count - 1; i++)
                    {
                        lv = new ListViewItem(ItemTextLists[i].Name);
                        lv.SubItems.Add(ItemTextLists[i].Name);
                        lv.SubItems.Add(ItemTextLists[i].Durability.ToString());
                        lv.SubItems.Add(ItemTextLists[i].SortValue);
                        lv.SubItems.Add(ItemTextLists[i].Section);
                        lv.Tag = ItemTextLists[i];
                        ListView2.Items.Add(lv);
                    }

                    ListView2.EndUpdate();
                    break;

                case ItemStorage.Save:
                    if (ItemList == null || ItemList.Count == 0)
                        return;
                    ListView1.Items.Clear();
                    ListView1.BeginUpdate();
                    for (var i = 0; i <= ItemList.Count - 1; i++)
                    {
                        if (ItemList[i].Section.ToLower().Contains("empty"))
                            continue;
                        lv = new ListViewItem(ItemList[i].Name);
                        lv.SubItems.Add(ItemTextLists[i].ID);
                        lv.SubItems.Add(ItemTextLists[i].Durability.ToString());
                        lv.SubItems.Add(ItemTextLists[i].SortValue);
                        lv.SubItems.Add(ItemTextLists[i].Section);
                        lv.Tag = ItemTextLists[i];
                        ListView2.Items.Add(lv);
                    }

                    ListView1.EndUpdate();
                    break;
            }
            GetSections(type);
        }

        public int GetSectionCount(string section)
        {
            var count = 0;
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].Section.ToLower() == section.ToLower())
                    count += 1;
            }
            return count;
        }

        public int GetFreeSpaceCount()
        {
            var count = 0;
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (ItemList[i].Section.ToLower() == "empty")
                    count += 1;
            }
            return count;
        }

        #endregion Some Functions

        #region for some parsing and closing

        public void Close(bool file)
        {
            if (file)
                Xfile = null;
            platform = Platform.None;
            XSave = null;
            ClearUI(file);
        }

        public void ClearUI(bool all)
        {
            var nrcontrolls = new List<Control>();
            foreach (Control ctr in TabControl1.TabPages[0].Controls)
            {
                if (ctr.AccessibleRole == AccessibleRole.Chart)
                    nrcontrolls.Add(ctr);
            }
            foreach (NumericUpDown nr in nrcontrolls)
            {
                nr.Value = 0;
            }
            CharacterName.Text = "";
            ListView1.Items.Clear();
            if (all)
            {
                ListView2.Items.Clear();
                SectionContainer2.Items.Clear();
                ItemSection.Items.Clear();
                ItemName.Text = "";
                ItemDurability.Value = 0;
                ItemID.Text = "";
                ItemTextLists = null;
            }
            SectionContainer1.Items.Clear();
            ToolStripButton3.Visible = false;
            ToolStripSeparator16.Visible = false;
            ItemList = null;
        }

        public void ParseSaveFile(string File)
        {
            try
            {
                if (!System.IO.File.Exists(Application.StartupPath + "\\DataBase.db"))
                    throw new FileNotFoundException();
                SlotSelector slot;
                switch (platform)
                {
                    case Platform.PC:

                        if (ReadPCBlocks())
                        {
                            slot = new SlotSelector(XPCEntries.Select(item => item.Name).ToArray());
                            if (slot.ShowDialog() != DialogResult.OK)
                                return;
                            XSelectedSave = slot.SelectedSave;
                            XSave = ExtractPCBlock(XSelectedSave);
                        }
                        break;

                    case Platform.XBOX360:
                        var stfs = new Initialize(File);
                        slot = new SlotSelector(stfs.EmbeddedFileNames);
                        if (slot.ShowDialog() == DialogResult.OK)
                        {
                            XSelectedSave = slot.SelectedSave;
                            XSave = stfs.Extract(XSelectedSave);
                            stfs.Close();
                        }
                        else
                        {
                            stfs.Close();
                            return;
                        }
                        break;

                    case Platform.PS3:
                        //TODO Fix this shit
                        var ps3 = new Ps3SaveManager(File, Ps3Key);
                        var files = new List<ComboboxItem>();
                        for (var i = 0; i < ps3.Files.Count(); i++)
                        {
                            if (ps3.Files[i].PFDEntry.file_name.EndsWith("USER.DAT"))
                            {
                                files.Add(new ComboboxItem { Text = ps3.Files[i].PFDEntry.file_name, Value = i });
                            }
                        }

                        slot = new SlotSelector(files.ToArray());
                        if (slot.ShowDialog() != DialogResult.OK) return;
                        XSelectedSave = slot.SelectedSave;
                        XSave = ps3.Param_PFD.DecryptToBytes(ps3.Files[slot.SelectedIndex].FilePath);
                        break;
                }
                if (XSave != null)
                {
                    ReadItemDB(Application.StartupPath + "\\DataBase.db");
                    ReadItems();
                    if (!ReadStatistics())
                    {
                        if (
                            MessageBox.Show("Save slot is empty!, Do you wish to repick?", "Invalid Slot",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            Close(false);
                            return;
                        }
                        ParseSaveFile(File);
                    }
                    if (ItemTextLists.Count > 0)
                    {
                        ToolStripButton3.Visible = true;
                        ToolStripSeparator16.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Parse Save!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion for some parsing and closing

        #region Reading/Writing Subs

        #region Reading

        public void ReadItemDB(string Database)
        {
            if (string.IsNullOrEmpty(Database))
                return;
            if (!File.Exists(Database))
                throw new Exception("Item DataBase is not Found !");
            using (var reader = new BinaryReader(new FileStream(Database, FileMode.Open)))
            {
                ItemTextLists = new List<ItemDBList>();
                string Name;
                string ID;
                string sort;
                string Section;
                UInt32 Dura;
                Int32 length;
                Int32 namelength;
                Int32 Last;
                ItemDBList item;
                ListView2.Items.Clear();
                ListView2.BeginUpdate();
                while (reader.BaseStream.Position < reader.BaseStream.Length - 1)
                {
                    namelength = reader.ReadInt32();
                    Section = Encoding.UTF8.GetString(reader.ReadBytes(namelength));

                    length = reader.ReadInt32();
                    Last = (int)reader.BaseStream.Position;
                    while (reader.BaseStream.Position < Last + length - 1)
                    {
                        var buffer = reader.ReadBytes(16);
                        ID = Encoding.UTF8.GetString(buffer);
                        namelength = reader.ReadInt32();
                        Name = Encoding.UTF8.GetString(reader.ReadBytes(namelength));
                        Dura = reader.ReadUInt32();
                        sort = Encoding.UTF8.GetString(reader.ReadBytes(6));
                        item = new ItemDBList(Name, ID.ToUpper(), Dura, sort, Section);
                        AddLV1(item, ListView2, Section);
                        ItemTextLists.Add(item);
                    }
                }
                reader.Close();
                ListView2.EndUpdate();
                GetSections(ItemStorage.Database);
                DBAmount.Text =
                    GetDBAmount(SectionContainer2.SelectedIndex == -1
                        ? "All"
                        : SectionContainer2.SelectedItem.ToString());
            }
        }

        public bool ReadStatistics()
        {
            try
            {
                var buffer = new byte[1];
                if (platform == Platform.PC)
                {
                    Array.Resize(ref buffer, XSave.Length - 20);
                    Array.Copy(XSave, 20, buffer, 0, buffer.Length);
                }
                else
                {
                    buffer = XSave;
                }
                var Reader = new Reader(buffer, (platform != Platform.PC));

                ReadNew(Reader);
                ReadEquipment(Reader);

                var count = 0;
                Reader.Position = 0xec;
                while (Reader.ReadUInt16() != 0)
                {
                    count += 2;
                }
                Reader.Position = 0xec;
                var x = (Reader.ReadBytes(count));
                if (platform == Platform.PC)
                    Array.Reverse(x);
                CharacterName.Text = (platform == Platform.PC)
                    ? Encoding.Unicode.GetString(x)
                    : Encoding.BigEndianUnicode.GetString(x);
                CharacterName.Enabled = (platform != Platform.PC);
                Reader.Position = 0x10e;
                ComboBoxGender.SelectedIndex = Reader.ReadInt8();
                Reader.Position = 0x112;
                ComboBoxClass.SelectedIndex = Reader.ReadInt8();
                Reader.Position = 0x114;
                ComboBoxGift.SelectedIndex = Reader.ReadInt8();
                Reader.Position = 0x113;
                ComboBoxPhysique.SelectedIndex = Reader.ReadInt8();
                Reader.Position = 0x157;
                ComboBoxCovenant.SelectedIndex = Reader.ReadInt8();
                Reader.Position = 0xd8;
                SetNumericValue(Souls, (int)Reader.ReadUInt32());
                Reader.Position = 0xd4;
                SetNumericValue(Level, (int)Reader.ReadUInt32());
                Reader.Position = 0x58;
                SetNumericValue(HP1, (int)Reader.ReadUInt32());
                Reader.Position = 0x60;
                SetNumericValue(HP2, (int)Reader.ReadUInt32());

                Reader.Position = 0x5C;
                if (HP2.Value != 0)
                    HealthMultiplier = (float)(Reader.ReadUInt32() / HP2.Value);
                else
                    HealthMultiplier = 1;

                Reader.Position = 0x74;
                SetNumericValue(Stamina1, (int)Reader.ReadUInt32());
                Reader.Position = 0x7C;
                SetNumericValue(Stamina2, (int)Reader.ReadUInt32());

                Reader.Position = 0x78;
                if (Stamina2.Value != 0)
                    StaminaMultiplier = (float)(Reader.ReadUInt32() / Stamina2.Value);
                else
                    StaminaMultiplier = 1;

                Reader.Position = 0x84;
                SetNumericValue(Vitality, (int)Reader.ReadUInt32());
                Reader.Position = 0x8c;
                SetNumericValue(Attunement, (int)Reader.ReadUInt32());
                Reader.Position = 0x94;
                SetNumericValue(Endurance, (int)Reader.ReadUInt32());
                Reader.Position = 0x9c;
                SetNumericValue(Strength, (int)Reader.ReadUInt32());
                Reader.Position = 0xa4;
                SetNumericValue(Dexterity, (int)Reader.ReadUInt32());
                Reader.Position = 0xcc;
                SetNumericValue(Resistance, (int)Reader.ReadUInt32());
                Reader.Position = 0xac;
                SetNumericValue(Intelligence, (int)Reader.ReadUInt32());
                Reader.Position = 0xb4;
                SetNumericValue(Faith, (int)Reader.ReadUInt32());
                Reader.Position = 0xc8;
                SetNumericValue(Humanity, (int)Reader.ReadUInt32());
                Reader.Close();
                buffer = null;
                if (CharacterName.Text == "" & Level.Value == 0 & HP2.Value == 0 & Stamina2.Value == 0)
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ReadPCBlocks()
        {
            if (!File.Exists(Xfile))
                throw new FileNotFoundException(Xfile);
            if (Xfile == null)
                return false;
            try
            {
                XPCEntries = new List<PCEntries>();
                UInt32 length;
                UInt32 offset;
                string name;
                using (
                    var reader = new BinaryReader(new FileStream(Xfile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    )
                {
                    reader.BaseStream.Position = 0x40;
                    for (var i = 0; i <= 10 - 1; i++)
                    {
                        name = "UserData" + i.ToString().PadLeft(3, '0');
                        reader.BaseStream.Position += 8;
                        length = reader.ReadUInt32();
                        reader.BaseStream.Position += 4;
                        offset = reader.ReadUInt32();
                        reader.BaseStream.Position += 0xc;
                        XPCEntries.Add(new PCEntries(name, offset, length));
                    }
                    reader.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] ExtractPCBlock(string savename)
        {
            byte[] buffer = null;
            foreach (var item in XPCEntries)
            {
                if (item.Name == savename)
                {
                    using (var reader = new BinaryReader(new FileStream(Xfile, FileMode.Open)))
                    {
                        reader.BaseStream.Position = item.Offset;
                        buffer = reader.ReadBytes((int)item.Length);
                        reader.Close();
                    }
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return buffer;
        }

        public bool ReplaceBlock(string savename, byte[] data, string file)
        {
            if (Xfile == null)
                return false;
            try
            {
                foreach (var item in XPCEntries)
                {
                    if (item.Name == savename)
                    {
                        using (
                            var writer =
                                new BinaryWriter(new FileStream(file, FileMode.Open, FileAccess.Write, FileShare.Write))
                            )
                        {
                            writer.BaseStream.Position = item.Offset;
                            writer.Write(data);
                            writer.Close();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadItems()
        {
            if (XSave == null)
                return;
            var buffer = new byte[1];
            if (platform == Platform.PC)
            {
                Array.Resize(ref buffer, XSave.Length - 20);
                Array.Copy(XSave, 20, buffer, 0, buffer.Length);
            }
            else
            {
                buffer = XSave;
            }
            var reader = new Reader(buffer, (platform != Platform.PC));
            ItemList = new List<Items>();
            RemovedItems = new List<Items>();
            string id;
            string Name;
            string Sortvalue;
            Int32 Ammount;
            Int32 durability;
            Int32 PartialDurabilityLoss;
            uint index;
            uint enabled;
            long offset;
            string section = null;
            reader.Position = 0x2cc;
            ListViewItem lvi;
            Items item;
            ListView1.Items.Clear();
            ListView1.BeginUpdate();
            for (var i = 0; i < 2048; i++)
            {
                Application.DoEvents();
                ToolStripProgressBar1.Value = (int)Math.Round(new decimal((i / (2048f - 1)) * 100), 0);
                Application.DoEvents();
                Status.Text = "Reading items.. (" + Math.Round(new decimal((i / (2048f - 1)) * 100), 0) + "%)";
                offset = reader.Position;
                id = BitConverter.ToString(reader.ReadBytes(4)).Replace("-", "");
                id = id + BitConverter.ToString(reader.ReadBytes(4)).Replace("-", "");
                Name = GetNameByID(id, ref section);

                lvi = new ListViewItem(Name);
                Ammount = reader.ReadInt32();

                index = reader.ReadUInt32();
                Sortvalue = (index >> 12).ToString("X5");
                index &= 0xFFF;
                if (id != "FFFFFFFFFFFFFFFF" && index != i)
                {
                }

                enabled = reader.ReadUInt32(false);
                if (id != "FFFFFFFFFFFFFFFF" && enabled > 1)
                {
                }
                durability = reader.ReadInt32();
                if (id != "FFFFFFFFFFFFFFFF" && durability < 0 || durability > 999)
                {
                }
                PartialDurabilityLoss = reader.ReadInt32();
                item = new Items(id, Name, Ammount, Sortvalue, index, durability, PartialDurabilityLoss, enabled, offset,
                    section);
                ItemList.Add(item);
                if (section.ToLower().Contains("empty"))
                    continue;
                AddLV(item, ListView1);
            }
            reader.Close();
            buffer = null;
            ListView1.EndUpdate();
            GetSections(ItemStorage.Save);
            ToolStripProgressBar1.Value = 0;
            Status.Text = Getstatustext();
        }

        #endregion Reading

        public void ReadEquipment(Reader reader)
        {
            var AttunedMagic = new uint[12];
            var MagicCounts = new uint[12];
            reader.Position = 0xE2D0;
            for (var i = 0; i < 12; i++)
            {
                AttunedMagic[i] = reader.ReadUInt32();
                MagicCounts[i] = reader.ReadUInt32();
            }

            var EquippedUsableItems = new uint[5];
            reader.Position = 0xE334;
            for (var i = 0; i < 5; i++)
            {
                EquippedUsableItems[i] = reader.ReadUInt32();
            }

            for (var i = 0; i < AttunedMagic.Length && i < AttunementBoxes.Count; i++)
            {
                CountBoxes[i].Value = MagicCounts[i] / 3m;

                AttunementBoxes[i].Items.Clear();
                AttunementBoxes[i].Items.Add("None");
                AttunementBoxes[i].SelectedIndex = 0;
                AttunementBoxes[i].Items.AddRange(ItemTextLists.FindAll(x => x.Section.ToLower() == "magic").ToArray());

                foreach (var o in AttunementBoxes[i].Items)
                {
                    if (o.GetType() != typeof(ItemDBList))
                        continue;

                    var item = (ItemDBList)o;
                    if (Convert.ToUInt32(item.ID.Substring(8), 16) == AttunedMagic[i])
                    {
                        AttunementBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            for (var i = 0; i < EquippedUsableItems.Length && i < UsableItemBoxes.Count; i++)
            {
                UsableItemBoxes[i].Items.Clear();
                UsableItemBoxes[i].Items.Add("None");
                UsableItemBoxes[i].SelectedIndex = 0;

                var items =
                    ItemList.FindAll(x => x.Section.ToLower() == "usable items" || x.Section.ToLower() == "unknown");
                items.Sort(
                    (x, y) =>
                        ((Convert.ToUInt32(x.SortValue, 16) << 12) + x.Index).CompareTo(
                            (Convert.ToUInt32(y.SortValue, 16) << 12) + y.Index));

                UsableItemBoxes[i].Items.AddRange(items.ToArray());

                foreach (var o in UsableItemBoxes[i].Items)
                {
                    if (o.GetType() != typeof(Items))
                        continue;

                    var item = (Items)o;
                    if (item.Index == EquippedUsableItems[i])
                    {
                        UsableItemBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            var Armor = new uint[4];
            reader.Position = 0x224;
            for (var i = 0; i < 4; i++)
            {
                Armor[i] = reader.ReadUInt32();
            }

            for (var i = 0; i < Armor.Length && i < ArmorBoxes.Count; i++)
            {
                ArmorBoxes[i].Items.Clear();
                ArmorBoxes[i].Items.Add("None");
                ArmorBoxes[i].SelectedIndex = 0;

                var items = ItemList.FindAll(x => x.Section.ToLower() == "armor" || x.Section.ToLower() == "unknown");
                items.Sort(
                    (x, y) =>
                        ((Convert.ToUInt32(x.SortValue, 16) << 12) + x.Index).CompareTo(
                            (Convert.ToUInt32(y.SortValue, 16) << 12) + y.Index));

                ArmorBoxes[i].Items.AddRange(items.ToArray());

                foreach (var o in ArmorBoxes[i].Items)
                {
                    if (o.GetType() != typeof(Items))
                        continue;

                    var item = (Items)o;
                    if (item.Index == Armor[i])
                    {
                        ArmorBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            var Weapons = new uint[4];
            reader.Position = 0x204;
            for (var i = 0; i < 4; i++)
            {
                Weapons[i] = reader.ReadUInt32();
            }

            for (var i = 0; i < Weapons.Length && i < WeaponBoxes.Count; i++)
            {
                WeaponBoxes[i].Items.Clear();
                WeaponBoxes[i].Items.Add("None");
                WeaponBoxes[i].SelectedIndex = 0;

                var items =
                    ItemList.FindAll(
                        x =>
                            x.Section.ToLower() == "weapons" || x.Section.ToLower() == "shields" ||
                            x.Section.ToLower() == "unknown");
                items.Sort(
                    (x, y) =>
                        ((Convert.ToUInt32(x.SortValue, 16) << 12) + x.Index).CompareTo(
                            (Convert.ToUInt32(y.SortValue, 16) << 12) + y.Index));

                WeaponBoxes[i].Items.AddRange(items.ToArray());

                foreach (var o in WeaponBoxes[i].Items)
                {
                    if (o.GetType() != typeof(Items))
                        continue;

                    var item = (Items)o;
                    if (item.Index == Weapons[i])
                    {
                        WeaponBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            var Ammo = new uint[4];
            reader.Position = 0x214;
            for (var i = 0; i < 4; i++)
            {
                Ammo[i] = reader.ReadUInt32();
            }

            for (var i = 0; i < Ammo.Length && i < AmmoBoxes.Count; i++)
            {
                AmmoBoxes[i].Items.Clear();
                AmmoBoxes[i].Items.Add("None");
                AmmoBoxes[i].SelectedIndex = 0;

                var items =
                    ItemList.FindAll(
                        x =>
                            x.Section.ToLower() == "ammo" || x.Section.ToLower() == "weapons" ||
                            x.Section.ToLower() == "shields" || x.Section.ToLower() == "unknown");
                items.Sort(
                    (x, y) =>
                        ((Convert.ToUInt32(x.SortValue, 16) << 12) + x.Index).CompareTo(
                            (Convert.ToUInt32(y.SortValue, 16) << 12) + y.Index));

                AmmoBoxes[i].Items.AddRange(items.ToArray());

                foreach (var o in AmmoBoxes[i].Items)
                {
                    if (o.GetType() != typeof(Items))
                        continue;

                    var item = (Items)o;
                    if (item.Index == Ammo[i])
                    {
                        AmmoBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            var Rings = new uint[2];
            reader.Position = 0x238;
            for (var i = 0; i < 2; i++)
            {
                Rings[i] = reader.ReadUInt32();
            }

            for (var i = 0; i < Rings.Length && i < RingBoxes.Count; i++)
            {
                RingBoxes[i].Items.Clear();
                RingBoxes[i].Items.Add("None");
                RingBoxes[i].SelectedIndex = 0;

                var items = ItemList.FindAll(x => x.Section.ToLower() == "rings" || x.Section.ToLower() == "unknown");
                items.Sort(
                    (x, y) =>
                        ((Convert.ToUInt32(x.SortValue, 16) << 12) + x.Index).CompareTo(
                            (Convert.ToUInt32(y.SortValue, 16) << 12) + y.Index));

                RingBoxes[i].Items.AddRange(items.ToArray());

                foreach (var o in RingBoxes[i].Items)
                {
                    if (o.GetType() != typeof(Items))
                        continue;

                    var item = (Items)o;
                    if (item.Index == Rings[i])
                    {
                        RingBoxes[i].SelectedItem = item;
                        break;
                    }
                }
            }

            var HairStyleID = new uint();
            reader.Position = 0x2A0;
            HairStyleID = reader.ReadUInt32();

            {
                comboBoxHSID.Items.Clear();
                comboBoxHSID.Items.Add("None");
                comboBoxHSID.Items.Add("Default");
                comboBoxHSID.SelectedIndex = 1;
                comboBoxHSID.Items.AddRange(ItemTextLists.FindAll(x => x.Section.ToLower() == "armor").ToArray());

                foreach (var o in comboBoxHSID.Items)
                {
                    if (o.GetType() != typeof(ItemDBList))
                        continue;

                    var item = (ItemDBList)o;
                    if (Convert.ToUInt32(item.ID.Substring(8), 16) == HairStyleID)
                    {
                        comboBoxHSID.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public void ReadNew(Reader reader)
        {
            reader.Position = 0x138;
            numericUpDownSin.Value = reader.ReadUInt32();

            reader.Position = 0x159;
            comboBoxHairStyle.SelectedIndex = reader.ReadUInt8();
            comboBoxColor.SelectedIndex = reader.ReadUInt8();

            reader.Position = 0xE370;
            var HairR = reader.ReadSingle();
            var HairG = reader.ReadSingle();
            var HairB = reader.ReadSingle();
            var HairA = reader.ReadSingle();
            var EyeR = reader.ReadSingle();
            var EyeG = reader.ReadSingle();
            var EyeB = reader.ReadSingle();
            var EyeA = reader.ReadSingle();

            textBoxHC.Text = HairR.ToString("0.###") + "," + HairG.ToString("0.###") + "," + HairB.ToString("0.###") +
                             "," + HairA.ToString("0.###");
            textBoxEC.Text = EyeR.ToString("0.###") + "," + EyeG.ToString("0.###") + "," + EyeB.ToString("0.###") + "," +
                             EyeA.ToString("0.###");

            reader.Position = 0xE3C2;
            numericUpDownSkinBrightness.Value = reader.ReadUInt8();

            reader.Position = 0x1E514;
            numericUpDownPlaythrough.Value = reader.ReadUInt16() + 1;
        }

        public void WriteEquipment(Writer writer)
        {
            writer.Position = 0xE2D0;
            for (var i = 0; i < AttunementBoxes.Count; i++)
            {
                var o = AttunementBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(ItemDBList))
                    writer.WriteUInt32(0xFFFFFFFF);
                else
                {
                    var item = (ItemDBList)o;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
                writer.WriteUInt32((uint)Math.Round(CountBoxes[i].Value * 3));
            }

            for (var i = 0; i < UsableItemBoxes.Count; i++)
            {
                var o = UsableItemBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(Items))
                {
                    writer.Position = 0x240 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF);

                    writer.Position = 0x2AC + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe 0?

                    writer.Position = 0xE334 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe 0?
                }
                else
                {
                    var item = (Items)o;

                    writer.Position = 0x240 + i * 4;
                    writer.WriteUInt32(item.Index);

                    writer.Position = 0x2AC + i * 4;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));

                    writer.Position = 0xE334 + i * 4;
                    writer.WriteUInt32(item.Index);
                }
            }

            for (var i = 0; i < ArmorBoxes.Count; i++)
            {
                var o = ArmorBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(Items))
                {
                    writer.Position = 0x224 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe the index of the "nothing equipped" item?

                    writer.Position = 0x290 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe the ID of the nothing equipped" item?
                }
                else
                {
                    var item = (Items)o;
                    writer.Position = 0x224 + i * 4;
                    writer.WriteUInt32(item.Index);

                    writer.Position = 0x290 + i * 4;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
            }

            for (var i = 0; i < WeaponBoxes.Count; i++)
            {
                var o = WeaponBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(Items))
                {
                    writer.Position = 0x204 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe the index of the "nothing equipped" item?

                    writer.Position = 0x270 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF); //maybe the ID of the nothing equipped" item?
                }
                else
                {
                    var item = (Items)o;
                    writer.Position = 0x204 + i * 4;
                    writer.WriteUInt32(item.Index);

                    writer.Position = 0x270 + i * 4;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
            }

            for (var i = 0; i < AmmoBoxes.Count; i++)
            {
                var o = AmmoBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(Items))
                {
                    writer.Position = 0x214 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF);

                    writer.Position = 0x280 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF);
                }
                else
                {
                    var item = (Items)o;
                    writer.Position = 0x214 + i * 4;
                    writer.WriteUInt32(item.Index);

                    writer.Position = 0x280 + i * 4;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
            }

            for (var i = 0; i < RingBoxes.Count; i++)
            {
                var o = RingBoxes[i].SelectedItem;
                if (o == null || o.GetType() != typeof(Items))
                {
                    writer.Position = 0x238 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF);

                    writer.Position = 0x2A4 + i * 4;
                    writer.WriteUInt32(0xFFFFFFFF);
                }
                else
                {
                    var item = (Items)o;
                    writer.Position = 0x238 + i * 4;
                    writer.WriteUInt32(item.Index);

                    writer.Position = 0x2A4 + i * 4;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
            }

            {
                var o = comboBoxHSID.SelectedItem;
                if (o == null || o.GetType() != typeof(ItemDBList))
                {
                    uint[] HairStyleIDs =
                    {
                        0x000003E8, 0x0000044C, 0x000004B0, 0x00000514, 0x00000578, 0x000005DC,
                        0x00000640, 0x000006A4, 0x00000708, 0x0000076C
                    };
                    writer.Position = 0x2A0;

                    if (o.ToString() == "None")
                        writer.WriteUInt32(0xFFFFFFFF);
                    else
                        writer.WriteUInt32(HairStyleIDs[comboBoxHairStyle.SelectedIndex]);
                }
                else
                {
                    var item = (ItemDBList)o;
                    writer.Position = 0x2A0;
                    writer.WriteUInt32(Convert.ToUInt32(item.ID.Substring(8), 16));
                }
            }
        }

        public void WriteNew(Writer writer)
        {
            writer.Position = 0x138;
            writer.WriteUInt32((uint)numericUpDownSin.Value);

            writer.Position = 0x159;
            writer.WriteUInt8((byte)comboBoxHairStyle.SelectedIndex);
            writer.WriteUInt8((byte)comboBoxColor.SelectedIndex);

            writer.Position = 0xE370;

            var HairArray = textBoxHC.Text.Split(',');
            writer.WriteSingle(float.Parse(HairArray[0]));
            writer.WriteSingle(float.Parse(HairArray[1]));
            writer.WriteSingle(float.Parse(HairArray[2]));
            writer.WriteSingle(float.Parse(HairArray[3]));

            var EyeArray = textBoxEC.Text.Split(',');
            writer.WriteSingle(float.Parse(EyeArray[0]));
            writer.WriteSingle(float.Parse(EyeArray[1]));
            writer.WriteSingle(float.Parse(EyeArray[2]));
            writer.WriteSingle(float.Parse(EyeArray[3]));

            writer.Position = 0xE3C2;
            writer.WriteUInt8((byte)numericUpDownSkinBrightness.Value);

            //writer.Position = 0xE390;
            //writer.WriteHexString("8E6C9A94787B7C8DA84C74918E598A6A5B9D5B5877776B92789D76728736649D93745FAC8978658D75647B8F8A6971B6858B");

            writer.Position = 0x1E514;
            writer.WriteUInt16((ushort)(numericUpDownPlaythrough.Value - 1));
        }

        #region Writing

        public bool Writestatics()
        {
            try
            {
                if (XSave == null)
                    return false;
                var buffer = new byte[1];
                if (platform == Platform.PC)
                {
                    Array.Resize(ref buffer, XSave.Length - 20);
                    Array.Copy(XSave, 20, buffer, 0, buffer.Length);
                }
                else
                {
                    buffer = XSave;
                }
                var writer = new Writer(buffer)
                {
                    IsBigEndian = (platform != Platform.PC)
                };
                if ((platform != Platform.PC))
                {
                    var x = new byte[0x1a];
                    writer.Position = 0xec;
                    writer.WriteBytes(x);
                    x = null;
                    writer.Position = 0xec;
                    x = (platform == Platform.PC)
                        ? Encoding.Unicode.GetBytes(CharacterName.Text)
                        : Encoding.BigEndianUnicode.GetBytes(CharacterName.Text);
                    if (platform == Platform.PC)
                        Array.Reverse(x);
                    writer.WriteBytes(x);
                    x = null;
                }

                WriteNew(writer);
                WriteEquipment(writer);

                writer.Position = 0x10e;
                writer.WriteInt8((sbyte)ComboBoxGender.SelectedIndex);
                writer.Position = 0x112;
                writer.WriteInt8((sbyte)ComboBoxClass.SelectedIndex);
                writer.Position = 0x114;
                writer.WriteInt8((sbyte)ComboBoxGift.SelectedIndex);
                writer.Position = 0x113;
                writer.WriteInt8((sbyte)ComboBoxPhysique.SelectedIndex);
                writer.Position = 0x157;
                writer.WriteInt8((sbyte)ComboBoxCovenant.SelectedIndex);
                writer.Position = 0xd8;
                writer.WriteUInt32((uint)Souls.Value);
                writer.Position = 0xe0;
                writer.WriteUInt32((uint)Souls.Value);
                writer.Position = 0xd4;
                writer.WriteUInt32((uint)Level.Value);
                writer.Position = 0x58;
                writer.WriteUInt32((uint)HP1.Value);
                writer.Position = 0x5c;
                writer.WriteUInt32((uint)((float)HP2.Value * HealthMultiplier));
                writer.Position = 0x60;
                writer.WriteUInt32((uint)HP2.Value);
                writer.Position = 0x74;
                writer.WriteUInt32((uint)Stamina1.Value);
                writer.Position = 0x78;
                writer.WriteUInt32((uint)((float)Stamina2.Value * StaminaMultiplier));
                writer.Position = 0x7c;
                writer.WriteUInt32((uint)Stamina2.Value);
                writer.Position = 0x84;
                writer.WriteUInt32((uint)Vitality.Value);
                writer.Position = 0x8c;
                writer.WriteUInt32((uint)Attunement.Value);
                writer.Position = 0x94;
                writer.WriteUInt32((uint)Endurance.Value);
                writer.Position = 0x9c;
                writer.WriteUInt32((uint)Strength.Value);
                writer.Position = 0xa4;
                writer.WriteUInt32((uint)Dexterity.Value);
                writer.Position = 0xcc;
                writer.WriteUInt32((uint)Resistance.Value);
                writer.Position = 0xac;
                writer.WriteUInt32((uint)Intelligence.Value);
                writer.Position = 0xb4;
                writer.WriteUInt32((uint)Faith.Value);
                writer.Position = 0xc8;
                writer.WriteUInt32((uint)Humanity.Value);
                if (CheckBox1.Checked)
                {
                    writer.Position = 0x1f13e;
                    writer.WriteBytes(new byte[] { 0xff, 0xff });
                }
                writer.Flush();
                writer.Close();
                Array.Copy(buffer, 0, XSave, (platform == Platform.PC) ? 20 : 0, buffer.Length);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteItems()
        {
            try
            {
                if (XSave == null)
                    return false;
                var buffer = new byte[1];
                if (platform == Platform.PC)
                {
                    Array.Resize(ref buffer, XSave.Length - 20);
                    Array.Copy(XSave, 20, buffer, 0, buffer.Length);
                }
                else
                {
                    buffer = XSave;
                }
                var writer = new Writer(new MemoryStream(buffer)) { IsBigEndian = (platform != Platform.PC) };
                for (var i = 0; i <= ItemList.Count - 1; i++)
                {
                    writer.Position = ItemList[i].Offset;
                    if (ItemList[i].Section.ToLower().Contains("empty"))
                    {
                        var temp = ToByteArray.HexToBytes("FFFFFFFFFFFFFFFF00000000FFFFFFFF00000000FFFFFFFF00000000");
                        if (platform == Platform.PC)
                            Array.Reverse(temp);
                        writer.WriteBytes(temp);
                        continue;
                    }
                    var x = new StringBuilder();
                    x.Append(ItemList[i].SortValue);
                    if (x.Length > 5)
                        x.Remove(5, 1);
                    x.Append(i.ToString("X3"));
                    if (platform == Platform.PC)
                    {
                        writer.IsBigEndian = true;
                        var temp = ToByteArray.HexToBytes(ItemList[i].ID);
                        Array.Reverse(temp, 0, 4);
                        Array.Reverse(temp, 4, 4);
                        writer.WriteBytes(temp);
                    }
                    else
                    {
                        writer.WriteHexString(ItemList[i].ID);
                    }
                    writer.IsBigEndian = (platform != Platform.PC);
                    writer.WriteUInt32((uint)ItemList[i].Quantity);
                    if (platform == Platform.PC)
                    {
                        var x2 = ToByteArray.HexToBytes(x.ToString());
                        for (var j = x2.Length - 1; j >= 0; j += -1)
                        {
                            writer.WriteUInt8(x2[j]);
                        }
                        x2 = null;
                    }
                    else
                    {
                        writer.WriteHexString(x.ToString());
                    }
                    writer.WriteUInt32(ItemList[i].Unlocked, false);
                    writer.WriteInt32(ItemList[i].Durability);
                    writer.WriteInt32(ItemList[i].PartialDurabilityLoss);
                }

                var NumItems = ItemList.FindAll(i => i.Index >= 64 && i.Section.ToLower() != "empty").Count;
                var NumKeys = ItemList.FindAll(i => i.Index < 64 && i.Section.ToLower() != "empty").Count;
                uint LastIndex = 0;
                foreach (var item in ItemList.FindAll(i => i.Section.ToLower() != "empty"))
                    if (item.Index > LastIndex)
                        LastIndex = item.Index;

                writer.Position = 0x2C0;
                writer.WriteInt32(NumItems);
                writer.WriteInt32(NumKeys);

                writer.Position = 0xE2CC;
                writer.WriteUInt32(LastIndex);

                writer.Flush();
                writer.Close();
                Array.Copy(buffer, 0, XSave, (platform == Platform.PC) ? 20 : 0, buffer.Length);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Writing

        #endregion Reading/Writing Subs

        #region Events

        public void ToolStripButton1_Click(Object sender, EventArgs e)
        {
            if ((ToolStripMenuItem)sender == xbox360ToolStripMenuItem)
            {
                var open = new OpenFileDialog
                {
                    Title = "Load your Xbox 360 savegame file",
                    Filter = "DRAKS0005(xbox360)|DRAKS0005*"
                };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Xfile = open.FileName;
                    platform = Platform.XBOX360;
                }
            }
            else if ((ToolStripMenuItem)sender == PCToolStripMenuItem)
            {
                var open = new OpenFileDialog
                {
                    Title = "Load your PC savegame file",
                    Filter = "DRAKS0005.sl2(PC)|DRAKS0005*.sl2"
                };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Xfile = open.FileName;
                    platform = Platform.PC;
                }
            }
            else
            {
                //PS3
                var open = new FolderBrowserDialog
                {
                    Description = "Load your PS3 savegame folder",
                    ShowNewFolderButton = false
                };
                if (open.ShowDialog() != DialogResult.OK) return;

                Xfile = open.SelectedPath;
                platform = Platform.PS3;
            }

            if (Xfile != null && ValidateSave(Xfile)) ParseSaveFile(Xfile);
            else
            {
                platform = Platform.None;
            }
        }

        public void Button3_Click(object sender, EventArgs e)
        {
            if (XSave == null)
                return;
            foreach (var nr in TabPage1.Controls.OfType<NumericUpDown>())
            {
                nr.Value = nr.Maximum;
            }
        }

        public void ToolStripButton4_Click(Object sender, EventArgs e)
        {
            FindInItemList(searchBox.Text.Replace("\0", ""));
        }

        public void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortMyListView(ListView1, e.Column, false, true);
        }

        public void SectionContainer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSection(SectionContainer1.Text, ItemStorage.Save);
        }

        public void ToolStripButton2_Click(Object sender, EventArgs e)
        {
            if (Xfile == null)
                return;
            if (XSave == null)
                return;
            if (platform != Platform.PS3 && !File.Exists(Xfile))
                throw new FileNotFoundException();
            try
            {
                if (XSave == null)
                {
                    if (
                        MessageBox.Show("There is not Saveslot Loaded.. Do u wish to load one ?", "Empty Save",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ParseSaveFile(Xfile);
                        return;
                    }
                }
                if (XSelectedSave == null)
                    throw new Exception("No slot is selected");
                if (!Writestatics())
                    throw new Exception("Failed writing Statistics");
                if (!WriteItems())
                    throw new Exception("Failed writing Items");
                if (!FixSaveHash())
                    throw new Exception("Failed Fixing Security");
                switch (platform)
                {
                    case Platform.PC:

                        if (!ReplaceBlock(XSelectedSave, XSave, Xfile))
                        {
                            MessageBox.Show("Failed to write savedata!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        break;

                    case Platform.XBOX360:
                        try
                        {
                            var stfs = new Initialize(Xfile);
                            if (!stfs.Replace(XSave, XSelectedSave))
                            {
                                stfs.Close();
                                throw new Exception("Failed to fix STFS File");
                            }

                            stfs.Finish();
                            stfs.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case Platform.PS3:
                        var ps3 = new Ps3SaveManager(Xfile, Ps3Key);
                        ps3.Param_PFD.Encrypt(XSave, ps3.Files.Single(i => i.PFDEntry.file_name == XSelectedSave));
                        //ps3.Param_SFO.Tables[1].Value = "0";
                        ps3.ReBuildChanges(false);
                        break;
                }
                MessageBox.Show(
                    "Succesfully Saved" + ((platform != Platform.XBOX360) ? "." : " , and Rehashed/Resigned."), "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SectionContainer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSection(SectionContainer2.SelectedItem.ToString(), ItemStorage.Database);
        }

        public void Findbutton2_Click(Object sender, EventArgs e)
        {
            FindInItemDB(Searchbox2.Text.Replace("\0", ""));
        }

        public void RefreshItems_Click(Object sender, EventArgs e)
        {
            ViewSection((string)(SectionContainer1.SelectedIndex == -1 ? "All" : SectionContainer1.SelectedItem),
                ItemStorage.Save);
        }

        public void RefreshItemList_Click(Object sender, EventArgs e)
        {
            ViewSection((string)(SectionContainer2.SelectedIndex == -1 ? "All" : SectionContainer2.SelectedItem),
                ItemStorage.Database);
        }

        public void ListView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortMyListView(ListView2, e.Column, false, true);
        }

        public void SearchBox_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FindInItemList(searchBox.Text.Replace("\0", ""));
            }
        }

        public void Searchbox2_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FindInItemDB(Searchbox2.Text.Replace("\0", ""));
            }
        }

        public void SaveItems_Click(Object sender, EventArgs e)
        {
            if (XSave == null || ItemList == null || ItemList.Count == 0)
                return;
            if (!WriteItems())
                MessageBox.Show("Failed to save items!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(
                    "Changes to the inventory have been succesfully saved.\nRemember to click Save All when you are done with all intended changes.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AddB_Click(Object sender, EventArgs e)
        {
            if (ItemTextLists == null)
                return;
            if (ItemName.Text == "")
            {
                MessageBox.Show("Enter the item name.");
                return;
            }
            if (ItemSection.Text == "")
            {
                MessageBox.Show("Select the item section.");
                return;
            }
            if (!ValidHexString(ItemID.Text) || ItemID.Text.Length != 16)
            {
                MessageBox.Show("Enter a valid ID.");
                return;
            }
            if (!ValidHexString(Itemsort.Text) || Itemsort.Text.Length != 6)
            {
                MessageBox.Show("Enter a valid Sort Value.");
                return;
            }
            if (IDExist(ItemID.Text, ItemSection.Text, ItemStorage.Database))
            {
                MessageBox.Show("Item Already Exists !");
                return;
            }

            var AutoUpgrades = false;
            if (AutoUpgrades)
            {
                var Suffix = " (AotA)";
                var Upgrades = new List<string>
                {
                    "",
                    "Crystal ",
                    "Lightning ",
                    "Raw ",
                    "Magic ",
                    "Enchanted ",
                    "Divine ",
                    "Occult ",
                    "Fire ",
                    "Chaos "
                };
                var Levels = new List<int>
                {
                    15,
                    5,
                    5,
                    5,
                    10,
                    5,
                    10,
                    5,
                    10,
                    5
                };

                var CurrentID = Convert.ToUInt64(ItemID.Text, 16);

                for (var i = 0; i < Upgrades.Count; i++)
                {
                    for (var j = 0; j <= Levels[i]; j++)
                    {
                        var NewName = Upgrades[i] + ItemName.Text + (j == 0 ? "" : " + " + j) + Suffix;
                        var NewID = (CurrentID + (ulong)j).ToString("X16");

                        var x = new ItemDBList(NewName, NewID,
                            (uint)(Upgrades[i].Contains("Crystal") ? ItemDurability.Value / 10 : ItemDurability.Value),
                            Itemsort.Text, ItemSection.Text);
                        AddItemDB(x);

                        var item = new ListViewItem(x.Name);
                        item.SubItems.Add(x.ID);
                        item.SubItems.Add(x.Durability.ToString());
                        item.SubItems.Add(x.SortValue);
                        item.SubItems.Add(x.Section);
                        item.Tag = x;
                        ListView2.Items.Add(item);
                    }
                    CurrentID += 0x64;
                }

                SectionContainer2.SelectedItem = ItemSection.SelectedItem;
                if (!ItemSection.Items.Contains(ItemSection.Text))
                    ItemSection.Items.Add(ItemSection.Text);
                DBAmount.Text =
                    GetDBAmount(SectionContainer2.SelectedIndex == -1
                        ? "All"
                        : SectionContainer2.SelectedItem.ToString());
            }
            else
            {
                var x = new ItemDBList(ItemName.Text, ItemID.Text, (uint)ItemDurability.Value, Itemsort.Text,
                    ItemSection.Text);
                AddItemDB(x);
                SectionContainer2.SelectedItem = ItemSection.SelectedItem;

                DBAmount.Text =
                    GetDBAmount(SectionContainer2.SelectedIndex == -1
                        ? "All"
                        : SectionContainer2.SelectedItem.ToString());
                if (!ItemSection.Items.Contains(ItemSection.Text))
                    ItemSection.Items.Add(ItemSection.Text);

                var item = new ListViewItem(x.Name);
                item.SubItems.Add(x.ID);
                item.SubItems.Add(x.Durability.ToString());
                item.SubItems.Add(x.SortValue);
                item.SubItems.Add(x.Section);
                item.Tag = x;
                ListView2.Items.Add(item);
            }
            foreach (ListViewItem it in ListView2.SelectedItems)
                it.Selected = false;

            ListView2.Items[ListView2.Items.Count - 1].EnsureVisible();
            ListView2.Items[ListView2.Items.Count - 1].Selected = true;

            MessageBox.Show("Added >>" + ItemName.Text + "<< in Section >>" + ItemSection.SelectedItem + "<<");
        }

        public void SlotB_Click(Object sender, EventArgs e)
        {
            if (Xfile == null)
                return;
            ParseSaveFile(Xfile);
        }

        public void Saveitemlist_Click(Object sender, EventArgs e)
        {
            if (ItemTextLists == null || ItemTextLists.Count == 0)
                return;
            try
            {
                using (var ms = new MemoryStream())
                {
                    byte[] buffer;
                    foreach (string item in SectionContainer2.Items)
                    {
                        if (item.ToLower().Contains("all"))
                            continue;
                        buffer = GetItemDBArray(item);
                        ms.Write(buffer, 0, buffer.Length);
                    }
                    buffer = null;
                    File.WriteAllBytes(Application.StartupPath + "\\DataBase.db", ms.ToArray());
                    ms.Dispose();
                    ms.Close();
                }
                MessageBox.Show("Item database has been saved.", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReplaceB_Click(Object sender, EventArgs e)
        {
            if (ListView2.SelectedItems.Count == 0)
                return;
            var item = ListView2.SelectedItems[0];
            if (ItemName.Text == "")
            {
                MessageBox.Show("Enter the item name.");
                return;
            }
            if (ItemSection.Text == "")
            {
                MessageBox.Show("Select the item section.");
                return;
            }
            if (!ValidHexString(ItemID.Text) || ItemID.Text.Length != 16)
            {
                MessageBox.Show("Enter a valid ID.");
                return;
            }
            if (!ValidHexString(Itemsort.Text) || (Itemsort.Text.Length != 5 && Itemsort.Text.Length != 6))
            {
                MessageBox.Show("Enter a valid sort value.");
                return;
            }

            var old = item.Text;
            item.Text = ItemName.Text;
            item.SubItems[1].Text = ItemID.Text;
            item.SubItems[2].Text = ItemDurability.Value.ToString();
            item.SubItems[3].Text = Itemsort.Text;
            item.SubItems[4].Text = ItemSection.Text;

            var it = (ItemDBList)item.Tag;
            it.Name = ItemName.Text;
            it.ID = ItemID.Text;
            it.Durability = (uint)ItemDurability.Value;
            it.SortValue = Itemsort.Text.Length == 5 ? Itemsort.Text + "0" : Itemsort.Text;
            it.Section = ItemSection.Text;

            DBAmount.Text =
                GetDBAmount((SectionContainer2.SelectedIndex == -1 ? "All" : SectionContainer2.SelectedItem.ToString()));
            MessageBox.Show("Replaced >>'" + old + "'<< with >>'" + ItemName.Text + "'");
        }

        private void ListView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DeleteB.Text = "Delete Item" + (ListView2.SelectedItems.Count > 1 ? "s" : "");

            DeleteB.Enabled = ListView2.SelectedItems.Count > 0;
            ReplaceB.Enabled = ListView2.SelectedItems.Count == 1;
        }

        public void ListView2_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ListView2.SelectedItems.Count > 0)
            {
                var x = ListView2.SelectedItems[0];
                ItemName.Text = x.Text;
                ItemID.Text = x.SubItems[1].Text;
                ItemDurability.Value = int.Parse(x.SubItems[2].Text);
                Itemsort.Text = x.SubItems[3].Text;
                ItemSection.SelectedItem = x.SubItems[4].Text;
            }
        }

        public void DeleteB_Click(Object sender, EventArgs e)
        {
            if (ListView2.SelectedItems.Count == 0)
                return;

            var NumItems = ListView2.SelectedItems.Count;
            var Name = ListView2.SelectedItems[0].SubItems[0].Text;

            foreach (ListViewItem item in ListView2.SelectedItems)
            {
                RemoveItemDB(item.SubItems[1].Text, item.SubItems[4].Text);

                item.Remove();
            }
            DBAmount.Text =
                GetDBAmount(SectionContainer2.SelectedIndex == -1 ? "All" : SectionContainer2.SelectedItem.ToString());
            if (NumItems == 1)
                MessageBox.Show("Removed >>" + Name + "<<");
            else
                MessageBox.Show("Removed >>" + NumItems + "<< items");
        }

        public void SetValue_Click(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            if (!ValidNRString(ammount.Text))
            {
                MessageBox.Show("Invalid Quantity Nummeric value");
                return;
            }
            if (!ValidNRString(dura.Text))
            {
                MessageBox.Show("Invalid Durability Nummeric value");
                return;
            }

            if (ammount.Text != "")
                foreach (ListViewItem item in ListView1.SelectedItems)
                {
                    item.SubItems[2].Text = ammount.Text;
                    var i = (Items)item.Tag;
                    i.Quantity = int.Parse(ammount.Text);
                }
            if (dura.Text != "")
                foreach (ListViewItem item in ListView1.SelectedItems)
                {
                    item.SubItems[3].Text = dura.Text;
                    var i = (Items)item.Tag;
                    i.Durability = int.Parse(dura.Text);
                }
        }

        public void ListView1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            ammount.Text = ListView1.SelectedItems[0].SubItems[2].Text;
            dura.Text = ListView1.SelectedItems[0].SubItems[3].Text;
        }

        public void CheckItemToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView2.SelectedItems.Count == 0)
                return;
            ListView2.SelectedItems[0].Checked = true;
        }

        public void CheckAllItemsToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView2.Items.Count == 0)
                return;
            foreach (ListViewItem item in ListView2.Items)
            {
                item.Checked = true;
            }
        }

        public void UncheckItemToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView2.SelectedItems.Count == 0)
                return;
            ListView2.SelectedItems[0].Checked = false;
        }

        public void UncheckAllItemsToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView2.Items.Count == 0)
                return;
            foreach (ListViewItem item in ListView2.Items)
            {
                item.Checked = false;
            }
        }

        public void AddSelectedItemsToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ItemList == null || ListView2.CheckedItems.Count == 0)
                return;
            var value = 0;
            var i = 0;
            foreach (ListViewItem item in ListView2.CheckedItems)
            {
                Application.DoEvents();
                ToolStripProgressBar1.Value = (int)(Math.Round(new Decimal((i / (ListView2.CheckedItems.Count)) * 100), 0));
                Application.DoEvents();
                Status.Text = "Adding >>" + item.Text;
                value = GetAvailibleSpot(item.SubItems[4].Text.ToLower().Contains("keys"));
                if (value == -1)
                {
                    MessageBox.Show("Inventory limit reached !");
                    break;
                }
                var x = new Items(item.SubItems[1].Text, item.Text, 1, item.SubItems[3].Text, (uint)value,
                    int.Parse(item.SubItems[2].Text), 0, 1, ItemList[value].Offset, item.SubItems[4].Text);
                i += 1;
                ReplaceItem(x);
            }
            ToolStripProgressBar1.Value = 0;
            Refresh(ItemStorage.Save);
            Status.Text = Getstatustext();
            MessageBox.Show(i + " Items Added");
        }

        public void MaxSection_Click(Object sender, EventArgs e)
        {
            if (ItemList == null || ItemList.Count == 0)
                return;
            if (SectionContainer1.SelectedIndex == -1)
            {
                MessageBox.Show("Select section to max out");
                return;
            }

            var unwanted = new List<string>
            {
                "Empty",
                "Rings",
                "Armor",
                "Weapons",
                "Shields",
                "Maxed Armor",
                "Maxed Weapons",
                "Maxed Shields"
            };

            if (unwanted.Contains(SectionContainer1.SelectedItem.ToString()))
            {
                MessageBox.Show("You Cannot max the " + SectionContainer1.SelectedItem + " slots.");
                return;
            }
            uint total = 0;
            for (var i = 0; i <= ItemList.Count - 1; i++)
            {
                if (SectionContainer1.SelectedItem.ToString() != "All")
                {
                    if (ItemList[i].Section.Contains(SectionContainer1.SelectedItem.ToString()))
                    {
                        ItemList[i].Quantity = ItemList[i].Section.ToLower().Contains("ammo") ? 999 : 99;
                        total++;
                    }
                }
                else
                {
                    if (!unwanted.Contains(ItemList[i].Section))
                    {
                        ItemList[i].Quantity = ItemList[i].Section.ToLower().Contains("ammo") ? 999 : 99;
                        total++;
                    }
                }
            }
            ViewSection(SectionContainer1.SelectedItem.ToString(), ItemStorage.Save);
            MessageBox.Show("Total >>" + total + "<< Items Maxed");
        }

        public void DeleteItemToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            var index = 0;
            var count = 0;
            foreach (ListViewItem item in ListView1.SelectedItems)
            {
                if (item.SubItems[5].Text.ToLower().Contains("empty"))
                {
                    MessageBox.Show("You cannot delete an empty slot.");
                    return;
                }
                index = GetItemIndexByID(item.SubItems[1].Text);
                RemovedItems.Add(ItemList[index]);
                RemoveItem(item.SubItems[1].Text);
                item.Remove();
                count += 1;
            }
            Status.Text = Getstatustext();
            MessageBox.Show("Total >>" + count + "<< Item(s) Removed");
        }

        public void ToolStripButton2_Click_1(Object sender, EventArgs e)
        {
            if (ItemList == null)
                return;
            if (RemovedItems == null || RemovedItems.Count == 0)
            {
                MessageBox.Show("Trash is empty");
                return;
            }
            var name = new List<string>();
            var id = new List<string>();
            for (var i = 0; i <= RemovedItems.Count - 1; i++)
            {
                name.Add(RemovedItems[i].Name);
                id.Add(RemovedItems[i].ID);
            }
            var form = new DeletedItems(RemovedItems);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ViewSection((string)(SectionContainer1.SelectedIndex == -1 ? "All" : SectionContainer1.SelectedItem),
                    ItemStorage.Save);
                Status.Text = Getstatustext();
            }
        }

        public void QuantityToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            if (ListView1.SelectedItems[0].Text.ToLower().Contains("empty"))
            {
                MessageBox.Show("You cannot max an empty slot.");
                return;
            }
            foreach (ListViewItem item in ListView1.SelectedItems)
            {
                item.SubItems[2].Text = "99";
                ItemList[GetItemIndexByID(item.SubItems[1].Text)].Quantity = 99;
            }
        }

        public void DurabilityToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            if (ListView1.SelectedItems[0].Text.ToLower().Contains("empty"))
            {
                MessageBox.Show("You cannot max an empty slot.");
                return;
            }
            foreach (ListViewItem item in ListView1.SelectedItems)
            {
                item.SubItems[3].Text = "999";
                ItemList[GetItemIndexByID(item.SubItems[1].Text)].Durability = 999;
            }
        }

        public void RenameItemToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 0)
                return;
            if (ListView1.SelectedItems[0].Text.ToLower().Contains("empty"))
            {
                MessageBox.Show("You cannot rename an empty slot.");
                return;
            }
            var sections = SectionContainer2.Items.Cast<string>().Where(item => item != "All").ToList();
            var x = new Rename(ListView1.SelectedItems[0].Text, sections, ListView1.SelectedItems[0].SubItems[5].Text);
            if (ListView1.SelectedItems[0].Text == "Unknown")
            {
                x.ComboBox1.Enabled = true;
            }
            else
            {
                x.ComboBox1.Enabled = false;
            }
            if (x.ShowDialog() == DialogResult.OK)
            {
                var index = GetItemIndexByID(ListView1.SelectedItems[0].SubItems[1].Text);
                var item = new ItemDBList(x.TextBox1.Text, ItemList[index].ID, (uint)ItemList[index].Durability,
                    ItemList[index].SortValue, x.ComboBox1.Text);

                if (!SectionContainer1.Items.Contains(x.ComboBox1.Text))
                    SectionContainer1.Items.Add(x.ComboBox1.Text);
                if (!SectionContainer2.Items.Contains(x.ComboBox1.Text))
                    SectionContainer2.Items.Add(x.ComboBox1.Text);
                if (!ItemSection.Items.Contains(x.ComboBox1.Text))
                    ItemSection.Items.Add(x.ComboBox1.Text);

                if (ListView1.SelectedItems[0].Text == "Unknown")
                {
                    AddItemDB(item);
                }
                else
                {
                    RepaceItemDB(item, ItemList[index].ID, ItemList[index].Section);
                }
                foreach (var it in ItemList.Where(it => it.ID == item.ID))
                {
                    it.Name = x.TextBox1.Text;
                    it.Section = x.ComboBox1.Text;
                }
                foreach (var it in ListView1.Items.Cast<ListViewItem>().Where(it => it.SubItems[1].Text == item.ID))
                {
                    it.Text = x.TextBox1.Text;
                    it.SubItems[5].Text = x.ComboBox1.Text;
                }
                var section = SectionContainer2.Text;
                if (section == "")
                    section = "All";
                ViewSection(section, ItemStorage.Database);
            }
        }

        public void ToolStripButton4_Click_1(Object sender, EventArgs e)
        {
            var s = new StringBuilder();
            s.AppendLine("Dark Souls Save Editor");
            s.AppendLine("Version : " + ProductVersion + " PS3 Edition");
            s.AppendLine("Author : Jappi88. Converted to C# and fixed/improved by Mr Nukealizer");
            s.AppendLine("\nSpecial Thanks Goes to : ");
            s.AppendLine("PureIso");
            s.AppendLine("absurdlyobfuscated");
            s.AppendLine("Magnus Hydra & Turk645");
            s.AppendLine("\nwww.360Haven.com");
            MessageBox.Show(s.ToString(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ToolStripButton5_Click(Object sender, EventArgs e)
        {
            var s = new StringBuilder();
            s.AppendLine("1) Open your DRAKS0005 Savegame.");
            s.AppendLine("2)Edit the statistics to your desires.");
            s.AppendLine("3)Edit The inventory to your desires.");
            s.AppendLine("4)Click Save inside the inventory tab to save the changes.");
            s.AppendLine("5)Click Save All at top to save changes and and fix the stfs package.");
            s.AppendLine("\nAfter your done, insert the save back on your MU Device and profit!");
            s.AppendLine("\nRead The ReadMe for more info or Visit " + "www.360haven.com.");
            MessageBox.Show(s.ToString(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ToolStripButton1_Click_1(Object sender, EventArgs e)
        {
            Close();
        }

        public void SaveAsB_Click(Object sender, EventArgs e)
        {
            if (Xfile == null)
                return;
            if (XSave == null)
                return;
            if (!File.Exists(Xfile))
                throw new FileNotFoundException(Xfile);
            var x = new SaveFileDialog
            {
                FileName = "DRAKS0005",
                Title = "Save as",
                Filter = (platform == Platform.PC) ? "DRAKS0005.sl2|*.sl2" : "DRAKS0005|*.*"
            };
            if (x.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (XSave == null)
                    {
                        if (
                            MessageBox.Show("There is not Saveslot Loaded.. Do u wish to load one ?", "Empty Save",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ParseSaveFile(Xfile);
                            return;
                        }
                    }
                    string path;
                    if (Xfile == x.FileName)
                    {
                        path = Xfile;
                    }
                    else
                    {
                        File.Copy(Xfile, x.FileName);
                        path = x.FileName;
                    }
                    if (XSelectedSave == null)
                        throw new Exception("No slot is selected");
                    if (!Writestatics())
                        throw new Exception("Failed writing Statistics");
                    if (!WriteItems())
                        throw new Exception("Failed writing Items");
                    if (!FixSaveHash())
                        throw new Exception("Failed Fixing Security");
                    switch (platform)
                    {
                        case Platform.PC:

                            if (!ReplaceBlock(XSelectedSave, XSave, path))
                            {
                                MessageBox.Show("Failed Writing savedata!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }
                            break;

                        case Platform.XBOX360:
                            try
                            {
                                var stfs = new Initialize(path);
                                if (!stfs.Replace(XSave, XSelectedSave))
                                {
                                    stfs.Close();
                                    throw new Exception("Failed Fixing stfs File");
                                }
                                stfs.Finish();
                                stfs.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                    MessageBox.Show(
                        "Succesfully Saved" + ((platform != Platform.XBOX360) ? "." : ", and Rehashed/Resigned."),
                        "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ToolStripLabel12_Click(Object sender, EventArgs e)
        {
            Process.Start("http://www.360haven.com");
        }

        public void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var x = (string[])e.Data.GetData("FileDrop", false);
            if (ValidateSave(x[0]))
            {
                Xfile = x[0];
                ParseSaveFile(Xfile);
            }
        }

        public void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion Events
    }

    public enum ItemStorage
    {
        Save,
        Database
    }

    public enum Platform
    {
        None,
        XBOX360,
        PC,
        PS3
    }

    #region Item Class

    public class Items
    {
        private Int32 XDurability;
        private string XName;
        private Int32 XPartialDurabilityLoss;

        public Items(string id, string name, Int32 ammount, string sortvalue, uint index, Int32 dura,
            Int32 PartialDurabilityLoss, uint enabled, long offset, string type)
        {
            ID = id;
            XName = name;
            Quantity = ammount;
            SortValue = sortvalue;
            Index = index;
            XDurability = dura;
            XPartialDurabilityLoss = PartialDurabilityLoss;
            Unlocked = enabled;
            Offset = offset;
            Section = type;
        }

        public string Name
        {
            get { return XName; }
            set
            {
                if (value == null || value.Replace("\0", "") == "")
                    return;
                XName = value;
            }
        }

        public string ID { get; set; }
        public Int32 Quantity { get; set; }
        public string SortValue { get; set; }
        public uint Index { get; set; }
        public uint Unlocked { get; set; }

        public Int32 Durability
        {
            get { return XDurability == -1 ? 0 : XDurability; }
            set { XDurability = value; }
        }

        public Int32 PartialDurabilityLoss
        {
            get { return XDurability == -1 ? 0 : XPartialDurabilityLoss; }
            set { XPartialDurabilityLoss = value; }
        }

        public string Section { get; set; }
        public long Offset { get; }

        public override string ToString()
        {
            var ReturnVal = string.Empty;
            if (Quantity > 1)
                ReturnVal += "(" + Quantity + ") ";
            ReturnVal += Name;
            if (Name == "Unkown")
                ReturnVal += " (" + ID + ")";
            return ReturnVal;
        }
    }

    #endregion Item Class

    //Class for holding the loaded items from  textfile
    public class ItemDBList
    {
        private string _ID;
        private string _Name;

        public ItemDBList(string name, string id, UInt32 dura, string Sort, string sec)
        {
            _Name = name;
            _ID = id;
            Durability = dura;
            SortValue = Sort;
            if (SortValue.Length == 5)
                SortValue += "0";
            Section = sec;
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _Name = value;
            }
        }

        public string ID
        {
            get { return _ID; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _ID = value;
            }
        }

        public UInt32 Durability { get; set; }
        public string SortValue { get; set; }
        public string Section { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    //some stuff for sorting the listview items
    public class ListViewColumnSorter : IComparer
    {
        public enum SortOrder
        {
            Ascending,
            Descending
        }

        public int mSortColumn;
        public SortOrder mSortOrder;

        public ListViewColumnSorter(int sortColumn, SortOrder sortOrder)
        {
            mSortColumn = sortColumn;
            mSortOrder = sortOrder;
        }

        int IComparer.Compare(object x, object y)
        {
            int Result;
            ListViewItem ItemX;
            ListViewItem ItemY;
            ItemX = (ListViewItem)x;
            ItemY = (ListViewItem)y;
            if (mSortColumn == 0)
            {
                Result = DateTime.Compare(DateTime.Parse(ItemX.Text), DateTime.Parse(ItemY.Text));
            }
            else
            {
                Result = DateTime.Compare(DateTime.Parse(ItemX.SubItems[mSortColumn].Text),
                    DateTime.Parse(ItemY.SubItems[mSortColumn].Text));
            }

            if (mSortOrder == SortOrder.Descending)
            {
                Result = -Result;
            }
            return Result;
        }
    }

    public class ListViewStringSort : IComparer
    {
        public int mSortColumn;
        public SortOrder mSortOrder;

        public ListViewStringSort(int sortColumn, SortOrder sortOrder)
        {
            mSortColumn = sortColumn;
            mSortOrder = sortOrder;
        }

        int IComparer.Compare(object x, object y)
        {
            int Result;
            ListViewItem ItemX;
            ListViewItem ItemY;
            ItemX = (ListViewItem)x;
            ItemY = (ListViewItem)y;
            if (mSortColumn == 0)
            {
                Result = ItemX.Text.Replace("0x", "").CompareTo(ItemY.Text.Replace("0x", ""));
            }
            else
            {
                Result =
                    ItemX.SubItems[mSortColumn].Text.Replace("0x", "")
                        .CompareTo(ItemY.SubItems[mSortColumn].Text.Replace("0x", ""));
            }
            if (mSortOrder == SortOrder.Descending)
            {
                Result = -Result;
            }
            return Result;
        }
    }

    public class ListViewNumericSort : IComparer
    {
        public bool mHex;
        public int mSortColumn;
        public SortOrder mSortOrder;

        public ListViewNumericSort(int sortColumn, SortOrder sortOrder, bool hex)
        {
            mSortColumn = sortColumn;
            mSortOrder = sortOrder;
            mHex = hex;
        }

        int IComparer.Compare(object x, object y)
        {
            int Result;
            ListViewItem ItemX;
            ListViewItem ItemY;
            ItemX = (ListViewItem)x;
            ItemY = (ListViewItem)y;
            if (mSortColumn == 0)
            {
                Result = !mHex
                    ? decimal.Compare(decimal.Parse(ItemX.Text.Replace("0x", "")),
                        decimal.Parse(ItemY.Text.Replace("0x", "")))
                    : Convert.ToUInt64(ItemX.Text.Replace("0x", ""), 16)
                        .CompareTo(Convert.ToUInt64(ItemY.Text.Replace("0x", ""), 16));
            }
            else
            {
                Result = !mHex
                    ? decimal.Compare(decimal.Parse(ItemX.SubItems[mSortColumn].Text.Replace("0x", "")),
                        decimal.Parse(ItemY.SubItems[mSortColumn].Text.Replace("0x", "")))
                    : Convert.ToUInt64(ItemX.SubItems[mSortColumn].Text.Replace("0x", ""), 16)
                        .CompareTo(Convert.ToUInt64(ItemY.SubItems[mSortColumn].Text.Replace("0x", ""), 16));
            }
            if (mSortOrder == SortOrder.Descending)
            {
                Result = -Result;
            }
            return Result;
        }
    }

    public class ListViewDateSort : IComparer
    {
        public int mSortColumn;
        public SortOrder mSortOrder;

        public ListViewDateSort(int sortColumn, SortOrder sortOrder)
        {
            mSortColumn = sortColumn;
            mSortOrder = sortOrder;
        }

        int IComparer.Compare(object x, object y)
        {
            var ItemX = (ListViewItem)x;
            var ItemY = (ListViewItem)y;
            var Result = mSortColumn == 0
                ? DateTime.Compare(DateTime.Parse(ItemX.Text), DateTime.Parse(ItemY.Text))
                : DateTime.Compare(DateTime.Parse(ItemX.SubItems[mSortColumn].Text),
                    DateTime.Parse(ItemY.SubItems[mSortColumn].Text));
            if (mSortOrder == SortOrder.Descending)
            {
                Result = -Result;
            }
            return Result;
        }
    }
}