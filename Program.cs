using Movies.View;
using System;
using System.Windows.Forms;

namespace Movies.Run {
    static class Program {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MovieForm());
        }
    }
}