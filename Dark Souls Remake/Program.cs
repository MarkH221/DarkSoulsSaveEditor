using System;
using System.Windows.Forms;

namespace DSSE
{
    internal static class Program
    {
        public static MainForm mainForm;

        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}