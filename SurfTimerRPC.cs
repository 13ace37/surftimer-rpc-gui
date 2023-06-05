using System;
using System.Windows.Forms;

namespace surftimer_rpc_gui
{
    internal static class SurfTimerRPC
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SurfTimerRPC_Form());
        }
    }
}
