using System;
using System.Windows.Forms;

namespace Elec
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new Main();
            Application.Run(main);
        }

        internal static Main main;
    }
}
