using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSSE
{
    static class SlotFunctions
    {
        public static void SlotMagic(string[] names, ComboBox a, ComboBox b)
        {
            foreach (var name in names.Where(n => !n.ToLower().EndsWith("0a")))
            {
                a.Items.Add(name);
                b.Items.Add(name);
            }
            ResetIndex(a);
        }

        public static void SlotMagic(ComboboxItem[] names, ComboBox a, ComboBox b)
        {
            foreach (var t in names.Where(t => !t.Text.ToLower().EndsWith("0a")))
            {
                a.Items.Add(t);
                b.Items.Add(t);
            }
            ResetIndex(a,false);
            ResetIndex(b,false);
        }

        public static void ResetIndex(ComboBox c, bool isString = true)
        {
            //isstring is for determining if the original source is using comboboxitem or string[]
            var i = isString ? 0 : -1;
            if (c.Items.Count > i)
                c.SelectedIndex = 0;
        }
    }
}
